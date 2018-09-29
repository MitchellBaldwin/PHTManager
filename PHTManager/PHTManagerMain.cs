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
using ArduinoUploader;
using System.Reflection;
using System.Diagnostics;

namespace PHTManager
{
    public partial class PHTManagerMain : Form
    {
        // Test comment

        #region Message type definitions
        public const Byte CommFramingByte = 0x00;           // Identifies the end of a serial message

        public const Byte TextMsgMsgType = 0x00;            // The packet contains a text message (bi-directional)
        public const Byte SetModeMsgType = 0x01;            // The packet is a Set Mode command (Host to PHTMD)
        public const Byte StartDataSave = 0x02;             // Start the serial data stream from the PHTM device (Host to PHTMD)
        public const Byte EndDataSave = 0x03;               // Stop the serial data stream from the PHTM device (Host to PHTMD)
        public const Byte LS1ONMsgType = 0x04;              // Connect cuff to manifold
        public const Byte LS1OFFMsgType = 0x05;             // Isolate cuff
        public const Byte LS2ONMsgType = 0x06;              // Open bleed valve
        public const Byte LS2OFFMsgType = 0x07;             // Close bleed valve
        public const Byte LS3ONMsgType = 0x08;              // Open vent valve
        public const Byte LS3OFFMsgType = 0x09;             // Close vent valve

        public const Byte SetLoopPeriodMsgType = 0x0E;      // Sets the main loop delay time (Host to PHTMD)

        public const Byte ToggleHRCalculation = 0x0F;       // Toggle calculation & display of heart rate (BPM) and IBI
        
        public const Byte FillCuffMsgType = 0x10;           // Set valves and pump to fill cuff to target pressure; command packet includes (initial) 
                                                            // pump speed setting (Host to PHTMD)
        public const Byte HoldCuffMsgType = 0x11;           // Set valves to hold cuff pressure (Host to PHTMD)
        public const Byte BleedCuffMsgType = 0x12;          // Set valves to bleed (to target pressure?) cuff (Host to PHTMD)
        public const Byte VentCuffMsgType = 0x13;           // Set valves to vent cuff (Host to PHTMD)

        public const Byte SensorDataMsgType = 0x18;         // Packet containing PPG & pressure sensor measurements (PHTMD to Host)

        public const Byte GetFirmwareVersionMsgType = 0x20; // Retrieve firmware version from STAT device

        #endregion Message type definitions

        // Buffers for serial communication with the PHTM device
        public const Byte PACKET_SIZE = 30;
        public const Byte ENCODED_PACKET_SIZE = PACKET_SIZE + 1;
        public const Byte COMM_BUFFER_SIZE = ENCODED_PACKET_SIZE + 1;

        Byte[] packetBuffer = new Byte[PACKET_SIZE];
        Byte[] encodedPacketBuffer = new Byte[ENCODED_PACKET_SIZE];
        Byte[] inBuffer = new Byte[COMM_BUFFER_SIZE];
        Byte[] outBuffer = new Byte[COMM_BUFFER_SIZE];
        Byte[] dummy = new Byte[1];

        Byte receivedMessageType = 0xFF;

        // Structures to hold dynamic measurements from PHTM device
        PHTMDataPoint curDataPoint = new PHTMDataPoint(0.0, 0, 0, 0, 0);
        PHTMDataPoints dataPointList = new PHTMDataPoints();
        PHTMDataPoint staticDataPoint = new PHTMDataPoint();
        
        // Objects used to graph data
        ZedGraph.PointPairList PPG1List = new ZedGraph.PointPairList();
        ZedGraph.LineItem PPG1Line;
        ZedGraph.PointPairList PPG2List = new ZedGraph.PointPairList();
        ZedGraph.LineItem PPG2Line;
        ZedGraph.PointPairList CPList = new ZedGraph.PointPairList();
        ZedGraph.LineItem CPLine;
        ZedGraph.PointPairList CuffPIDList = new ZedGraph.PointPairList();
        ZedGraph.LineItem CuffPIDLine;

        string fwVersionString = "x.x.x.x";
        public string FwVersionString { get => fwVersionString; set => fwVersionString = value; }

        #region Flags
        // Flag indicating whether the data feed from the embedded system is active
        //(set in the DataReceived event handler)
        Boolean dataSaveActive = false;
        public Boolean DataSaveActive
        {
            get { return dataSaveActive; }
            set { dataSaveActive = value; }
        }

        // Switch for displaying contents of commands sent to the PHM Main Controller
        Boolean showAllPHMCommandBufferUpdates = true;
        public Boolean ShowAllPHMCommandBufferUpdates
        {
            get { return showAllPHMCommandBufferUpdates; }
            set { showAllPHMCommandBufferUpdates = value; }
        }

        // Switch or displaying contents of the communications buffer incoming from the PHM Main Controller
        Boolean showInBufferUpdates = false;
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
        #endregion Flags

        #region Form level methods
        public PHTManagerMain()
        {
            InitializeComponent();
        }

        private void PHTManagerMain_Load(object sender, EventArgs e)
        {
            string assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            AssemblyVersionDisplayLabel.Text = assemblyVersion;
            string fileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            FileVersionDisplayLabel.Text = fileVersion;
            string productVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
            ProductVersionDisplayLabel.Text = productVersion;

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

        private void PHTManagerMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.LastCOMPortSetting = COMPortToolStripComboBox.Text;
            Properties.Settings.Default.Save();
        }

        #endregion Form level methods

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
            PPG2Line = phmMainPain.AddCurve("PPG2", PPG2List, Color.Purple, ZedGraph.SymbolType.None);

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
        
        #region Display functions
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
        private void DisplayInBufferToConsole()
        {
            String CommBufStr = "IN:  ";
            for (int i = 0; i < COMM_BUFFER_SIZE; ++i)
            {
                CommBufStr += inBuffer[i].ToString("X2");
                if (i < inBuffer.Length) CommBufStr += " ";
            }
            //inBufferDisplayLabel.Text = CommBufStr;
            Console.WriteLine(CommBufStr);
        }

        // Display contents of the serial outBuffer
        private void DisplayOutBufferToConsole()
        {
            String CommBufStr = "OUT: ";
            for (int i = 0; i < COMM_BUFFER_SIZE; ++i)
            {
                CommBufStr += outBuffer[i].ToString("X2");
                if (i < outBuffer.Length) CommBufStr += " ";
            }
            //outBufferDisplayLabel.Text = CommBufStr;
            Console.WriteLine(CommBufStr);
        }
        #endregion Display functions

        // Main display loop timer - update displays
        private void PHMMainTimer_Tick(object sender, EventArgs e)
        {
            if (showAllPHMCommandBufferUpdates)
            {
                DisplayCommBuffers();
            }

            ZedGraph.GraphPane phmMainPain = phmDataZedGraph.GraphPane;
            //
            // TODO: Should use time stamp created for the curDataPoint
            //
            ZedGraph.XDate currentDataXTime = new ZedGraph.XDate(DateTime.Now);
            PPG1List.Add(currentDataXTime, curDataPoint.PPG1);
            CPList.Add(currentDataXTime, curDataPoint.CP);
            CuffPIDList.Add(currentDataXTime, curDataPoint.CuffPID);
            PPG2List.Add(currentDataXTime, curDataPoint.PPG2);

            // Check if right graph margin has been reached; if so, scroll graph
            if (currentDataXTime > phmMainPain.XAxis.Scale.Max) 
            {
                phmMainPain.XAxis.Scale.Max = currentDataXTime;
                phmMainPain.XAxis.Scale.Min = new ZedGraph.XDate(DateTime.Now.AddSeconds(-30.0));
            }
            
            phmMainPain.AxisChange();
            phmDataZedGraph.Invalidate();

            cuffPressureDisplayLabel.Text = curDataPoint.CP.ToString();
            //cuffPressureDisplayLabel.Text = curDataPoint.CPRaw.ToString();
            targetPressureDisplayLabel.Text = staticDataPoint.TargetCuffPressure.ToString();
            //targetPressureDisplayLabel.Text = curDataPoint.TargetCuffPressure.ToString();
            cuffPressureADCDisplayLabel.Text = curDataPoint.CPRaw.ToString();

            pulseRateDisplayLabel.Text = curDataPoint.BPM.ToString();
            pulsePeriodDisplayLabel.Text = curDataPoint.IBI.ToString();

            if (PHMMessageReceived)     // Handle other messages received from STAT device
            {
                FirmwareVersionDisplayLabel.Text = FwVersionString;
            }

        }

        #region Serial communications methods
        // Serial port callback function to handle the receipt of messages from the PHM device
        private void PHMSerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (PHMSerialPort.BytesToRead < COMM_BUFFER_SIZE)
            {
                // DEBUG: Uncomment the following line to log reports of calls to this handler when the serial receive buffer has fewer
                // than COMM_BUFFER_SIZE bytes
                //Console.WriteLine("False call to DataReceived: " + PHMSerialPort.BytesToRead.ToString() + " bytes in receive buffer");
                return;
            }
            try
            {
                PHMSerialPort.Read(inBuffer, 0, COMM_BUFFER_SIZE);
                commTimeoutErrorFlag = false;      // If no exception was thrown then we should have receiced a complete buffer (COMM_BUFFER_SIZE bits)

                // Check that the first byte contains the CommStartByte
                if (inBuffer[COMM_BUFFER_SIZE - 1] != CommFramingByte)
                {
                    commFramingErrorFlag = true;
                    Console.WriteLine("Serial port framing error");
                    return;
                }
                else
                {
                    commFramingErrorFlag = false;
                }

                // A properly framed serial packet has arrived, so decode it
                for (int i = 0; i < ENCODED_PACKET_SIZE; ++i)
                {
                    encodedPacketBuffer[i] = inBuffer[i];
                }
                packetBuffer = COBSCodec.decode(encodedPacketBuffer);

                // Check that the checksums match
                Byte checkSum = 0;
                for (int i = 0; i < PACKET_SIZE - 1; ++i)
                {
                    checkSum += packetBuffer[i];
                }
                if (checkSum == packetBuffer[PACKET_SIZE - 1])
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
                receivedMessageType = packetBuffer[0x00];

                if (receivedMessageType == SensorDataMsgType)
                {
                    curDataPoint = new PHTMDataPoint();
                    curDataPoint.DataTime = new ZedGraph.XDate(DateTime.Now).XLDate;
                    curDataPoint.PPG1 = packetBuffer[0x01] + packetBuffer[0x02] * 256;
                    curDataPoint.CPRaw = (ushort)(packetBuffer[0x03] + packetBuffer[0x04] * 256);
                    //curDataPoint.TargetCuffPressure = Int32.Parse(targetPressureDisplayLabel.Text);

                    curDataPoint.CuffPID = packetBuffer[0x05];
                    curDataPoint.BPM = packetBuffer[0x06] + packetBuffer[0x07] * 256;
                    curDataPoint.IBI = packetBuffer[0x08] + packetBuffer[0x09] * 256;
                    curDataPoint.PPG2 = packetBuffer[0x0A] + packetBuffer[0x0B] * 256;
                    curDataPoint.DataTimeMS = packetBuffer[0x0C]
                                              + packetBuffer[0x0D] * 256
                                              + packetBuffer[0x0E] * 65536
                                              + packetBuffer[0x0F] * 16777216;

                    if (DataSaveActive)
                    {
                        dataPointList.Add(curDataPoint);
                    }
                }

                if (receivedMessageType == GetFirmwareVersionMsgType)
                {
                    fwVersionString = string.Format("{0}.{1}.0.0", packetBuffer[0x01], packetBuffer[0x02]);
                    PHMMessageReceived = true;
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
            }

        }

        // Helper function to format the outBuffer with a PHTMD message / command
        private void BuildCommMessage(Byte msgType, Byte[] buffer)
        {
            Byte checkSum = 0;

            for (int i = 0; i < PACKET_SIZE; ++i)
            {
                packetBuffer[i] = 0;
            }

            packetBuffer[0] = msgType;
            for (int i = 0; i < buffer.Length; ++i)
            {
                packetBuffer[1 + i] = buffer[i];
            }

            checkSum = 0x00;
            for (int i = 0; i < PACKET_SIZE - 1; ++i)
            {
                checkSum += packetBuffer[i];
            }
            packetBuffer[PACKET_SIZE - 1] = checkSum;

            encodedPacketBuffer = COBSCodec.encode(packetBuffer);
            for (int i = 0; i < COMM_BUFFER_SIZE - 1; ++i)
            {
                outBuffer[i] = encodedPacketBuffer[i];
            }
            outBuffer[COMM_BUFFER_SIZE - 1] = 0x00;
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
                DisplayOutBufferToConsole();
            }
        }

        private void BuildAndSendCommandMessage(Byte msgType, Byte[] buffer)
        {
            BuildCommMessage(msgType, buffer);
            SendCommandMessage();
        }
        #endregion Serial communications methods

        #region Menu, toolbar and control event handlers
        // The primary means of connecting to the PHTM device via the serial port is to check the "Connect" check box
        private void connectButton_Click(object sender, EventArgs e)
        {
            if (!PHMSerialPort.IsOpen)
            {
                try
                {
                    PHMSerialPort.Open();
                    PHMMainTimer.Enabled = true;
                    testModeCheckBox.Enabled = true;
                    commErrorDisplayLabel.Text = "Connected";
                    connectButton.Text = "Disconnect";

                    PHMSerialPort.DiscardInBuffer();
                    
                }
                catch (IOException ioe)
                {
                    Console.WriteLine(ioe.GetType().Name + ": " + ioe.Message);
                }
            }
            else
            {
                if (PHMSerialPort.IsOpen)
                {
                    // Give the serial port and embedded system time to process the message to stop the data feed
                    //System.Threading.Thread.Sleep(1000);
                    PHMSerialPort.Close();
                }
                PHMMainTimer.Enabled = false;
                testModeCheckBox.Enabled = false;
                commErrorDisplayLabel.Text = "Not connected";
                connectButton.Text = "Connect";
            }
        }

        private void COMPortToolStripComboBox_TextChanged(object sender, EventArgs e)
        {
            Boolean wasOpen = false;

            if (PHMSerialPort.IsOpen)
            {
                wasOpen = true;
                PHMSerialPort.Close();
            }
            PHMSerialPort.PortName = COMPortToolStripComboBox.Text;
            if (wasOpen)
            {
                PHMSerialPort.Open();
            }
        }

        private void showAllBufferUpdatesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            showAllPHMCommandBufferUpdates = showAllBufferUpdatesCheckBox.Checked;
            if (showAllPHMCommandBufferUpdates)
            {
                inBufferDisplayLabel.Visible = true;
                outBufferDisplayLabel.Visible = true;
                //packetDisplayLabel.Visible = true;
                DisplayCommBuffers();
            }
            else
            {
                inBufferDisplayLabel.Visible = false;
                outBufferDisplayLabel.Visible = false;
                //packetDisplayLabel.Visible = false;
            }

        }
        
        private void testModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (testModeCheckBox.Checked)
            {
                // Place PHM device in test mode:
                //dummy[0] = 0x00;
                //BuildCommMessage(SetModeMsgType, dummy);
                //SendCommandMessage();
                TestControlPanel.Enabled = true;
                //pulseLS1ONButton.Enabled = true;
                //pulseLS1OFFButton.Enabled = true;
                //pulseLS2ONButton.Enabled = true;
                //pulseLS2OFFButton.Enabled = true;
            }
            else
            {
                // Place PHM device in normal mode:
                //dummy[0] = 0x01;
                //BuildCommMessage(SetModeMsgType, dummy);
                //SendCommandMessage();
                TestControlPanel.Enabled = false;
                //pulseLS1ONButton.Enabled = false;
                //pulseLS1OFFButton.Enabled = false;
                //pulseLS2ONButton.Enabled = false;
                //pulseLS2OFFButton.Enabled = false;
            }
        }

        private void saveDataButton_Click(object sender, EventArgs e)
        {
            if (DataSaveActive)
            {
                BuildCommMessage(EndDataSave, dummy);
                SendCommandMessage();
                DataSaveActive = false;
                saveDataButton.Text = "Start Save Segment";

                String PHTMHostPath = Application.StartupPath;
                PHTMSaveDataFileDialog.InitialDirectory = PHTMHostPath;
                Console.WriteLine("Executable path: {0}", PHTMHostPath);

                if (PHTMSaveDataFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        using (CSVFileWriter writer = new CSVFileWriter(PHTMSaveDataFileDialog.FileName))
                        {
                            dataPointList.RemoveAt(0);                  // Drop first data point
                            foreach (PHTMDataPoint dp in dataPointList)
                            {
                                CSVRow row = new CSVRow();
                                ZedGraph.XDate time = new ZedGraph.XDate(dp.DataTime);
                                // Try creating a .NET DateTime object from the saved data point time stamp field:
                                //DateTime time = new DateTime(dp.DataTime);
                                row.Add(time.DateTime.ToString("mm:ss") + "." + time.DateTime.Millisecond.ToString("000"));
                                row.Add(dp.DataTimeMS.ToString());
                                row.Add(dp.PPG1.ToString());
                                row.Add(dp.PPG2.ToString());
                                row.Add(dp.CP.ToString());
                                writer.WriteRow(row);
                            }
                        }
                        Console.WriteLine("Data saved to: {0}", PHTMSaveDataFileDialog.FileName);
                        dataPointList.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not save file to disk; original error: " + ex.Message);
                    }
                }
            }
            else
            {
                BuildCommMessage(StartDataSave, dummy);
                SendCommandMessage();
                DataSaveActive = true;
                saveDataButton.Text = "End Save Segment";
                dataPointList.Clear();

            }

        }

        private void showPumpPIDOnGraphCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CuffPIDLine.IsVisible = showPumpPIDOnGraphCheckBox.Checked;
        }

        private void targetPressureIncreaseButton_Click(object sender, EventArgs e)
        {
            staticDataPoint.TargetCuffPressure += 5;
            targetPressureDisplayLabel.Text = staticDataPoint.TargetCuffPressure.ToString();
            rawTargetPressureDisplayLabel.Text = staticDataPoint.TargetCuffPressureToRaw().ToString();
        }

        private void targetPressureDecreaseButton_Click(object sender, EventArgs e)
        {
            staticDataPoint.TargetCuffPressure -= 5;
            targetPressureDisplayLabel.Text = staticDataPoint.TargetCuffPressure.ToString();
            rawTargetPressureDisplayLabel.Text = staticDataPoint.TargetCuffPressureToRaw().ToString();
        }

        private void fillCuffButton_Click(object sender, EventArgs e)
        {
            Byte[] buf = new Byte[3];
            buf[0] = (Byte)pumpPIDNumericUpDown.Value;                          // Initial pump speed (PWM) setting
            buf[1] = (Byte)(staticDataPoint.TargetCuffPressureToRaw() % 256);   // Target cuff pressure low byte
            buf[2] = (Byte)(staticDataPoint.TargetCuffPressureToRaw() / 256);   // Target cuff pressure high byte
            BuildCommMessage(FillCuffMsgType, buf);
            SendCommandMessage();
        }

        private void maintainCuffPressureButton_Click(object sender, EventArgs e)
        {
            BuildCommMessage(HoldCuffMsgType, dummy);
            SendCommandMessage();
        }

        private void bleedCuffPressureButton_Click(object sender, EventArgs e)
        {
            Byte[] buf = new Byte[3];
            buf[0] = 0xFF;                                                      // Turn pump OFF
            buf[1] = (Byte)(staticDataPoint.TargetCuffPressureToRaw() % 256);   // Target cuff pressure low byte
            buf[2] = (Byte)(staticDataPoint.TargetCuffPressureToRaw() / 256);   // Target cuff pressure high byte
            BuildCommMessage(BleedCuffMsgType, buf);
            SendCommandMessage();
        }

        private void reperfuseButton_Click(object sender, EventArgs e)
        {
            BuildCommMessage(VentCuffMsgType, dummy);
            SendCommandMessage();
        }

        private void pulseLS1ONButton_Click(object sender, EventArgs e)
        {
            BuildCommMessage(LS1ONMsgType, dummy);
            SendCommandMessage();
        }

        private void pulseLS1OFFButton_Click(object sender, EventArgs e)
        {
            BuildCommMessage(LS1OFFMsgType, dummy);
            SendCommandMessage();
        }

        private void pulseLS2ONButton_Click(object sender, EventArgs e)
        {
            BuildCommMessage(LS2ONMsgType, dummy);
            SendCommandMessage();
        }

        private void pulseLS2OFFButton_Click(object sender, EventArgs e)
        {
            BuildCommMessage(LS2OFFMsgType, dummy);
            SendCommandMessage();
        }

        private void pulseLS3ONButton_Click(object sender, EventArgs e)
        {
            BuildCommMessage(LS3ONMsgType, dummy);
            SendCommandMessage();
        }

        private void pulseLS3OFFButton_Click(object sender, EventArgs e)
        {
            BuildCommMessage(LS3OFFMsgType, dummy);
            SendCommandMessage();
        }

        private void pumpPIDNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            curDataPoint.CuffPID = (int)pumpPIDNumericUpDown.Value;
        }

        private void calculatePulseRateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BuildCommMessage(ToggleHRCalculation, dummy);
            SendCommandMessage();
        }

        #endregion Menu, toolbar and control event handlers

        private void uploadFirmwareButton_Click(object sender, EventArgs e)
        {
            String PHTMHostPath = Application.StartupPath;
            String STATFirmwareHexFileName = "PTHMD.hex";
            openHexFileDialog.FileName = STATFirmwareHexFileName;
            openHexFileDialog.InitialDirectory = PHTMHostPath;

            if (openHexFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DialogResult result = MessageBox.Show("Are you sure you wish to update the STAT firmware from file: " +
                                                       openHexFileDialog.FileName,
                                                       "Confirm firmware update",
                                                       MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    var uploader = new ArduinoSketchUploader(
                    new ArduinoSketchUploaderOptions()
                    {
                        FileName = openHexFileDialog.FileName,
                        PortName = PHMSerialPort.PortName,
                        ArduinoModel = ArduinoUploader.Hardware.ArduinoModel.UnoR3
                    });
                    try
                    {
                        uploader.UploadSketch();
                        string successString = string.Format(format: "Successfully updated STAT firmware from file: {0}", arg0: openHexFileDialog.FileName);
                        Console.WriteLine(successString);
                        MessageBox.Show(successString, "Success");
                    }
                    catch (Exception ex)
                    {
                        string errorString = "Cycle power to STAT device and try again\n\n" + ex.Message;
                        MessageBox.Show(errorString, "Error updating STAT firmware");
                    }
                    
                }
            }
        }

        private void GetFirmwareVersionButton_Click(object sender, EventArgs e)
        {
            BuildCommMessage(GetFirmwareVersionMsgType, dummy);
            SendCommandMessage();
            if (PHMSerialPort.IsOpen)
            {
                FirmwareVersionDisplayLabel.Text = "Reading";
            }
            else
            {
                FirmwareVersionDisplayLabel.Text = "Not connected";
            }
        }
    }
}
