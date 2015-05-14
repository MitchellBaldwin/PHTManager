using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PHTManager
{
    public partial class PHTManagerMain : Form
    {
        // Test comment

        // Defines
        public const Byte CommStartByte = 0xF0;             // Identifies the start of a message packet

        public const Byte TextMsgMsgType = 0x00;            // The packet contains a text message (bi-directional)
        public const Byte SetModeMsgType = 0x01;            // The packet is a Set Mode command (Host to PHTMD)
        public const Byte StartDataFeed = 0x02;             // Start the serial data stream from the PHTM device (Host to PHTMD)
        public const Byte StopDataFeed = 0x03;              // Stop the serial data stream from the PHTM device (Host to PHTMD)

        public const Byte SetLoopPeriodMsgType = 0x08;      // Sets the main loop delay time (Host to PHTMD)

        public const Byte FillCuffMsgType = 0x10;           // Set valves and pump to fill cuff to target pressure; command packet includes (initial) 
                                                            // pump speed setting (Host to PHTMD)
        public const Byte HoldCuffMsgType = 0x11;           // Set valves to hold cuff pressure (Host to PHTMD)
        public const Byte BleedCuffMsgType = 0x12;          // Set valves to bleed (to target pressure?) cuff (Host to PHTMD)
        public const Byte VentCuffMsgType = 0x13;           // Set valves to vent cuff (Host to PHTMD)

        public const Byte SensorDataMsgType = 0x18;         // Packet containing PPG & pressure sensor measurements (PHTMD to Host)

        // Buffers for serial communication with the PHTM device
        public const Byte COMM_BUFFER_SIZE = 32;
        Byte[] inBuffer = new Byte[COMM_BUFFER_SIZE];
        Byte[] outBuffer = new Byte[COMM_BUFFER_SIZE];
        Byte[] dummy = new Byte[1];

        // Structures to hold dynamic measurements from PHTM device
        PHTMDataPoint curDataPoint = new PHTMDataPoint(0.0, 0, 0);
        PHTMDataPoints dataPointList = new PHTMDataPoints();
        
        // Objects used to graph data
        ZedGraph.PointPairList PPG1List = new ZedGraph.PointPairList();
        ZedGraph.LineItem PPG1Line;
        ZedGraph.PointPairList CPList = new ZedGraph.PointPairList();
        ZedGraph.LineItem CPLine;
        ZedGraph.PointPairList CuffPIDList = new ZedGraph.PointPairList();
        ZedGraph.LineItem CuffPIDLine;

        // Flag indicating whether the data feed from the embedded system is active
        //(set in the DataReceived event handler)
        Boolean dataFeedActive = false;
        public Boolean DataFeedActive
        {
            get { return dataFeedActive; }
            set { dataFeedActive = value; }
        }

        //int dataTime = 0;

        // Switch for displaying contents of commands sent to the PHM Main Controller
        Boolean showAllPHMCommandBufferUpdates = false;
        public Boolean ShowAllPHMCommandBufferUpdates
        {
            get { return showAllPHMCommandBufferUpdates; }
            set { showAllPHMCommandBufferUpdates = value; }
        }

        // Switch or displaying contents of the communications buffer incoming from the PHM Main Controller
        Boolean showInBufferUpdates = true;
        public Boolean ShowInBufferUpdates
        {
            get { return showInBufferUpdates; }
            set { showInBufferUpdates = value; }
        }

        // Switch or displaying contents of the communications buffer outgoing to the PHM Main Controller
        Boolean showOutBufferUpdates = true;
        public Boolean ShowOutBufferUpdates
        {
            get { return showOutBufferUpdates; }
            set { showOutBufferUpdates = value; }
        }

        // Flag indicating that a new message has been received from the PHM Main Controller
        Boolean phmMessageReceived = false;
        public Boolean PHMMessageReceived
        {
            get { return phmMessageReceived; }
            set { phmMessageReceived = value; }
        }

        // Flag indicating a timeout error occured in the thread handling serial communications with the PHM Main Controller
        Boolean commTimeoutErrorFlag = false;
        public Boolean CommTimeoutErrorFlag
        {
            get { return commTimeoutErrorFlag; }
            set { commTimeoutErrorFlag = value; }
        }

        // Flag indicating a framing error occured in the thread handling serial communications with the PHM Main Controller
        Boolean commFramingErrorFlag = false;
        public Boolean CommFramingErrorFlag
        {
            get { return commFramingErrorFlag; }
            set { commFramingErrorFlag = value; }
        }

        // Flag indicating a framing error occured in the thread handling serial communications with the PHM Main Controller
        Boolean commChecksumErrorFlag = false;
        public Boolean CommChecksumErrorFlag
        {
            get { return commChecksumErrorFlag; }
            set { commChecksumErrorFlag = value; }
        }

        public PHTManagerMain()
        {
            InitializeComponent();
        }

        private void PHTManagerMain_Load(object sender, EventArgs e)
        {
            PHMSerialPort.PortName = COMPortToolStripComboBox.Text;
            phmspPortDisplayLabel.Text = PHMSerialPort.PortName;
            phmspBaudRateDisplayLabel.Text = PHMSerialPort.BaudRate.ToString();
            phmspDataBitsDisplayLabel.Text = PHMSerialPort.DataBits.ToString();
            phmspParityDisplayLabel.Text = PHMSerialPort.Parity.ToString();
            phmspStopBitsDisplayLabel.Text = PHMSerialPort.StopBits.ToString();

            PHMSerialPort.ReceivedBytesThreshold = 32;
            PHMSerialPort.ReadTimeout = 500;
            PHMSerialPort.WriteTimeout = 500;

            CreateGraph(phmDataZedGraph);
            SetSize();
        }

        private void PHTManagerMain_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private void SetSize()
        {
            //phmDataZedGraph.Location = new Point(10, 10);
            //phmDataZedGraph.Size = new Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20);
        }

        private void CreateGraph(ZedGraph.ZedGraphControl zgc)
        {
            ZedGraph.GraphPane phmMainPain = zgc.GraphPane;
            
            phmMainPain.Title.IsVisible = false;
            phmMainPain.Legend.IsVisible = false;
            
            phmMainPain.XAxis.Title.Text = "t (mm:ss)";
            phmMainPain.XAxis.Title.FontSpec.Size = 12;
            phmMainPain.XAxis.Title.FontSpec.IsBold = false;
            phmMainPain.XAxis.Type = ZedGraph.AxisType.Date;
            phmMainPain.XAxis.Scale.FontSpec.Size = 10;
            phmMainPain.XAxis.Scale.FontSpec.IsBold = true;
            phmMainPain.XAxis.Scale.Format = "mm:ss";
            phmMainPain.XAxis.Scale.Min = new ZedGraph.XDate(DateTime.Now);
            phmMainPain.XAxis.Scale.Max = new ZedGraph.XDate(DateTime.Now.AddSeconds(30.0));
            phmMainPain.XAxis.Scale.MinAuto = false;
            phmMainPain.XAxis.Scale.MaxAuto = false;
            phmMainPain.XAxis.MajorGrid.IsVisible = true;

            phmMainPain.YAxis.Title.Text = "PPG (ADC)";
            phmMainPain.YAxis.Title.FontSpec.Size = 14;
            phmMainPain.YAxis.Title.FontSpec.IsBold = false;
            phmMainPain.YAxis.Title.FontSpec.FontColor = Color.Red;
            phmMainPain.YAxis.Scale.FontSpec.Size = 12;
            phmMainPain.YAxis.Scale.FontSpec.IsBold = true;
            phmMainPain.YAxis.Scale.Min = 0;
            phmMainPain.YAxis.Scale.Max = 1023;                 // Largest possible raw PPG measurement
            phmMainPain.YAxis.MajorGrid.IsVisible = true;

            PPG1Line = phmMainPain.AddCurve("PPG1", PPG1List, Color.Red, ZedGraph.SymbolType.None);

            phmMainPain.Y2Axis.Title.Text = "P-cuff (mmHg)";
            phmMainPain.Y2Axis.Title.FontSpec.Size = 14;
            phmMainPain.Y2Axis.Title.FontSpec.IsBold = false;
            phmMainPain.Y2Axis.Title.FontSpec.FontColor = Color.Green;
            phmMainPain.Y2Axis.Scale.FontSpec.Size = 12;
            phmMainPain.Y2Axis.Scale.FontSpec.IsBold = true;
            phmMainPain.Y2Axis.Scale.Min = 0;
            phmMainPain.Y2Axis.Scale.Max = 250;                 // Largest possible Cuff Pressure measurement
            phmMainPain.Y2Axis.MajorGrid.IsVisible = false;
            phmMainPain.Y2Axis.IsVisible = true;

            CPLine = phmMainPain.AddCurve("P-cuff", CPList, Color.Green, ZedGraph.SymbolType.None);
            CPLine.IsY2Axis = true;

            CuffPIDLine = phmMainPain.AddCurve("Cuff PID", CuffPIDList, Color.Aqua, ZedGraph.SymbolType.None);
            CuffPIDLine.IsY2Axis = true;
            CuffPIDLine.IsVisible = false;

            zgc.AxisChange();
        }
        
        // The primary means of connecting to the PHTM device via the serial port is to check the "Connect" check box
        private void phmspConnectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (phmspConnectCheckBox.Checked)
            {
                try
                {
                    PHMSerialPort.Open();
                    PHMMainTimer.Enabled = true;
                    testModeCheckBox.Enabled = true;
                    commErrorDisplayLabel.Text = "Connected";
                }
                catch (IOException ioe)
                {
                    Console.WriteLine(ioe.GetType().Name + ": " + ioe.Message);
                    phmspConnectCheckBox.Checked = false;
                }
            }
            else
            {
                if (PHMSerialPort.IsOpen)
                {
                    // If the serial port is open and the data feed is active then stop the data feed before closing the port
                    BuildCommMessage(StopDataFeed, dummy);
                    SendCommandMessage();
                    // Give the serial port and embedded system time to process the message to stop the data feed
                    System.Threading.Thread.Sleep(1000);

                    PHMSerialPort.Close();
                    PHMMainTimer.Enabled = false;
                    testModeCheckBox.Enabled = false;
                    commErrorDisplayLabel.Text = "Not connected";
                }
            }
        }

        private void testModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (testModeCheckBox.Checked)
            {
                // Place PHM device in test mode:
                dummy[0] = 0x00;
                BuildCommMessage(SetModeMsgType, dummy);
                SendCommandMessage();
            }
            else
            {
                // Place PHM device in normal mode:
                dummy[0] = 0x01;
                BuildCommMessage(SetModeMsgType, dummy);
                SendCommandMessage();
            }
        }

        // Display contents of both serial communiction buffers
        private void DisplayCommBuffers()
        {
            String CommBufStr = "OUT: ";
            for (int i = 0; i < COMM_BUFFER_SIZE; ++i)
            {
                CommBufStr += outBuffer[i].ToString("X2");
                if (i < outBuffer.Length) CommBufStr += " ";
            }
            outBufferDisplayLabel.Text = CommBufStr;

            CommBufStr = "IN:  ";
            for (int i = 0; i < COMM_BUFFER_SIZE; ++i)
            {
                CommBufStr += inBuffer[i].ToString("X2");
                if (i < inBuffer.Length) CommBufStr += " ";
            }
            inBufferDisplayLabel.Text = CommBufStr;
        }

        // Display contents of the serial inBuffer
        private void DisplayInBuffer()
        {
            String CommBufStr = "IN:  ";
            for (int i = 0; i < COMM_BUFFER_SIZE; ++i)
            {
                CommBufStr += inBuffer[i].ToString("X2");
                if (i < inBuffer.Length) CommBufStr += " ";
            }
            inBufferDisplayLabel.Text = CommBufStr;
        }

        // Display contents of the serial outBuffer
        private void DisplayOutBuffer()
        {
            String CommBufStr = "OUT: ";
            for (int i = 0; i < COMM_BUFFER_SIZE; ++i)
            {
                CommBufStr += outBuffer[i].ToString("X2");
                if (i < outBuffer.Length) CommBufStr += " ";
            }
            outBufferDisplayLabel.Text = CommBufStr;
        }

        // Main display loop timer - update displays
        private void PHMMainTimer_Tick(object sender, EventArgs e)
        {
            ZedGraph.GraphPane phmMainPain = phmDataZedGraph.GraphPane;
            ZedGraph.XDate currentDataXTime = new ZedGraph.XDate(DateTime.Now);
            PPG1List.Add(currentDataXTime, curDataPoint.PPG1);
            CPList.Add(currentDataXTime, curDataPoint.CP);
            CuffPIDList.Add(currentDataXTime, curDataPoint.CuffPID);

            if (currentDataXTime > phmMainPain.XAxis.Scale.Max) 
            {
                phmMainPain.XAxis.Scale.Max = currentDataXTime;
                phmMainPain.XAxis.Scale.Min = new ZedGraph.XDate(DateTime.Now.AddSeconds(-30.0));
            }
            
            phmMainPain.AxisChange();
            phmDataZedGraph.Invalidate();

            if (showInBufferUpdates)
            {
                DisplayInBuffer();
            }

            cuffPressureDisplayLabel.Text = curDataPoint.CP.ToString();
            targetPressureDisplayLabel.Text = curDataPoint.TargetCuffPressure.ToString();

            pulseRateDisplayLabel.Text = curDataPoint.BPM.ToString();
            pulsePeriodDisplayLabel.Text = curDataPoint.IBI.ToString();

            if (dataFeedActive)
            {
                this.startStopDataToolStripButton.Image = global::PHTManager.Properties.Resources.on;
            }
            else
            {
                this.startStopDataToolStripButton.Image = global::PHTManager.Properties.Resources.off;
            }
            dataFeedActive = false;

        }

        // Helper function to format the outBuffer with a PHTMD message / command
        private void BuildCommMessage(Byte msgType, Byte[] buffer)
        {
            Byte checkSum = 0;

            for (int i = 0; i < COMM_BUFFER_SIZE; ++i)
            {
                outBuffer[i] = 0;
            }

            outBuffer[0] = CommStartByte;
            outBuffer[1] = msgType;
            checkSum = CommStartByte;
            checkSum += msgType;
            for (int i = 0; i < buffer.Length; ++i)
            {
                outBuffer[2 + i] = buffer[i];
                checkSum += buffer[i];
            }
            outBuffer[COMM_BUFFER_SIZE - 1] = checkSum;
        }

        // Helper function to send the contents of the outBuffer to the PHTM Device
        private void SendCommandMessage()
        {
            try
            {
                PHMSerialPort.Write(outBuffer, 0, COMM_BUFFER_SIZE);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.GetType().Name + ": " + ioe.Message);
            }
            if (ShowOutBufferUpdates)
            {
                DisplayOutBuffer();
            }
        }

        // Serial port callback function to handle the receipt of messages from the PHM device
        private void PHMSerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Byte messageType = 0xFF;
            
            if (PHMSerialPort.BytesToRead < COMM_BUFFER_SIZE)
            {
                Console.WriteLine("False call to DataReceived");
                return;
            }
            try
            {
                PHMSerialPort.Read(inBuffer, 0, COMM_BUFFER_SIZE);
                commTimeoutErrorFlag = false;      // If no exception was thrown then we should have receiced a complete buffer (COMM_BUFFER_SIZE bits)
                dataFeedActive = true;

                // Check that the first byte contains the CommStartByte
                if (inBuffer[0x00] != CommStartByte)
                {
                    commFramingErrorFlag = true;
                    Console.WriteLine("Serial port framing error");
                    //PHMSerialPort.DiscardInBuffer();
                    return;
                }
                else
                {
                    commFramingErrorFlag = false;
                }

                // Check that the checksums match
                Byte checkSum = 0;
                for (int i = 0; i < COMM_BUFFER_SIZE - 1; ++i)
                {
                    checkSum += inBuffer[i];
                }
                if (checkSum == inBuffer[COMM_BUFFER_SIZE - 1])
                {
                    commChecksumErrorFlag = false;
                }
                else
                {
                    commChecksumErrorFlag = true;
                    Console.WriteLine("Serial port checksum error");
                    return;
                }

                // If no errors then set flag indicating that a valid message has been received
                phmMessageReceived = true;
                messageType = inBuffer[0x01];

                if (messageType == SensorDataMsgType)
                {
                    curDataPoint = new PHTMDataPoint();
                    curDataPoint.DataTime = new ZedGraph.XDate(DateTime.Now).XLDate;
                    curDataPoint.PPG1 = inBuffer[0x02] + inBuffer[0x03] * 256;
                    curDataPoint.CPRaw = (ushort)(inBuffer[0x04] + inBuffer[0x05] * 256);

                    dataPointList.Add(curDataPoint);

                    curDataPoint.CuffPID = inBuffer[0x06];
                    curDataPoint.BPM = inBuffer[0x07] + inBuffer[0x08] * 256;
                    curDataPoint.IBI = inBuffer[0x09] + inBuffer[0x0A] * 256;
                }

            }
            catch (System.TimeoutException)
            {
                commTimeoutErrorFlag = true;
                Console.WriteLine("Serial port timeout");
                phmMessageReceived = false;
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.GetType().Name + ": " + ioe.Message);
                phmspConnectCheckBox.Checked = false;
            }

        }

        private void showPumpPIDOnGraphCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CuffPIDLine.IsVisible = showPumpPIDOnGraphCheckBox.Checked;
        }

        private void targetPressureIncreaseButton_Click(object sender, EventArgs e)
        {
            curDataPoint.TargetCuffPressure++;
        }

        private void targetPressureDecreaseButton_Click(object sender, EventArgs e)
        {
            curDataPoint.TargetCuffPressure--;
        }

        private void COMPortToolStripComboBox_TextChanged(object sender, EventArgs e)
        {
            Boolean wasOpen = false;

            if (phmspConnectCheckBox.Checked)
            {
                wasOpen = true;
                phmspConnectCheckBox.Checked = false;
            }
            PHMSerialPort.PortName = COMPortToolStripComboBox.Text;
            if (wasOpen)
            {
                phmspConnectCheckBox.Checked = true;
            }
        }

        private void startStopDataToolStripButton_Click(object sender, EventArgs e)
        {
            if (DataFeedActive)
            {
                BuildCommMessage(StopDataFeed, dummy);
                SendCommandMessage();
                DataFeedActive = false;
            }
            else
            {
                BuildCommMessage(StartDataFeed, dummy);
                SendCommandMessage();
            }
        }

        private void PHTManagerMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.LastCOMPortSetting = COMPortToolStripComboBox.Text;
            Properties.Settings.Default.Save();
        }

        private void saveDataToFileToolStripButton_Click(object sender, EventArgs e)
        {
            String PHTMHostPath = Application.StartupPath;
            PHTMSaveDataFileDialog.InitialDirectory = PHTMHostPath;
            Console.WriteLine("Executable path: {0}", PHTMHostPath);

            if (PHTMSaveDataFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    using (CSVFileWriter writer = new CSVFileWriter(PHTMSaveDataFileDialog.FileName))
                    {
                        foreach (PHTMDataPoint dp in dataPointList)
                        {
                            CSVRow row = new CSVRow();
                            ZedGraph.XDate time = new ZedGraph.XDate(dp.DataTime);
                            row.Add(time.DateTime.ToString("mm:ss") + "." + time.DateTime.Millisecond.ToString("000"));
                            row.Add(dp.PPG1.ToString());
                            row.Add(dp.CP.ToString());
                            writer.WriteRow(row);
                        }
                    }
                    Console.WriteLine("Data saved to: {0}", PHTMSaveDataFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not save file to disk; original error: " + ex.Message);
                }
            }
        }

        private void fillCuffButton_Click(object sender, EventArgs e)
        {
            Byte[] buf = new Byte[3];
            buf[0] = 0x80;                                              // Initial pump speed (PWM) setting
            buf[1] = (Byte)(curDataPoint.TargetCuffPressure % 256);     // Target cuff pressure low byte
            buf[2] = (Byte)(curDataPoint.TargetCuffPressure / 256);     // Target cuff pressure high byte
            BuildCommMessage(FillCuffMsgType, buf);
            SendCommandMessage();
        }

        private void maintainCuffPressureButton_Click(object sender, EventArgs e)
        {
            BuildCommMessage(HoldCuffMsgType, dummy);
            SendCommandMessage();
        }

        private void ppgPowerOnOffButton_Click(object sender, EventArgs e)
        {
            Byte[] buf = new Byte[2];
            buf[0] = (Byte)(curDataPoint.TargetCuffPressure % 256);     // Target cuff pressure low byte
            buf[1] = (Byte)(curDataPoint.TargetCuffPressure / 256);     // Target cuff pressure high byte
            BuildCommMessage(BleedCuffMsgType, buf);
            SendCommandMessage();
        }

        private void reperfuseButton_Click(object sender, EventArgs e)
        {
            BuildCommMessage(VentCuffMsgType, dummy);
            SendCommandMessage();
        }

    }
}
