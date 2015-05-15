namespace PHTManager
{
    partial class PHTManagerMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PHTManagerMain));
            this.cuffPressureDisplayPanel = new System.Windows.Forms.Panel();
            this.currentCuffPressureLabel = new System.Windows.Forms.Label();
            this.cuffPressureDisplayLabel = new System.Windows.Forms.Label();
            this.systolicPressurePanel = new System.Windows.Forms.Panel();
            this.lastSystolicPressureLabel = new System.Windows.Forms.Label();
            this.lastSystolicPressureDisplayLabel = new System.Windows.Forms.Label();
            this.pulseRatePanel = new System.Windows.Forms.Panel();
            this.pulseRateLebel = new System.Windows.Forms.Label();
            this.pulseRateDisplayLabel = new System.Windows.Forms.Label();
            this.targeyPressurePanel = new System.Windows.Forms.Panel();
            this.targetPressureDecreaseButton = new System.Windows.Forms.Button();
            this.targetPressureIncreaseButton = new System.Windows.Forms.Button();
            this.targetPressureLabel = new System.Windows.Forms.Label();
            this.targetPressureDisplayLabel = new System.Windows.Forms.Label();
            this.systemPanel = new System.Windows.Forms.Panel();
            this.testModeCheckBox = new System.Windows.Forms.CheckBox();
            this.phmspStopBitsDisplayLabel = new System.Windows.Forms.Label();
            this.commErrorDisplayLabel = new System.Windows.Forms.Label();
            this.showAllBufferUpdatesCheckBox = new System.Windows.Forms.CheckBox();
            this.bytePositionLabel = new System.Windows.Forms.Label();
            this.inBufferDisplayLabel = new System.Windows.Forms.Label();
            this.outBufferDisplayLabel = new System.Windows.Forms.Label();
            this.phmspConnectCheckBox = new System.Windows.Forms.CheckBox();
            this.phmspDataBitsDisplayLabel = new System.Windows.Forms.Label();
            this.phmspParityDisplayLabel = new System.Windows.Forms.Label();
            this.phmspBaudRateDisplayLabel = new System.Windows.Forms.Label();
            this.phmspPortDisplayLabel = new System.Windows.Forms.Label();
            this.phmspLabel = new System.Windows.Forms.Label();
            this.ppgSensitivityDisplayLabel = new System.Windows.Forms.Label();
            this.ppgSensitivityLabel = new System.Windows.Forms.Label();
            this.ppgSensitivityUnitsLabel = new System.Windows.Forms.Label();
            this.cuffInflationRateUnitsLabel = new System.Windows.Forms.Label();
            this.cuffInflationRateLabel = new System.Windows.Forms.Label();
            this.cuffInflationRateDisplayLabel = new System.Windows.Forms.Label();
            this.cuffDeflationRateUnitsLabel = new System.Windows.Forms.Label();
            this.cuffDeflationRateLabel = new System.Windows.Forms.Label();
            this.cuffDeflationRateDisplayLabel = new System.Windows.Forms.Label();
            this.reperfuseButton = new System.Windows.Forms.Button();
            this.maintainCuffPressureButton = new System.Windows.Forms.Button();
            this.findSystolicPressureButton = new System.Windows.Forms.Button();
            this.ppgPowerOnOffButton = new System.Windows.Forms.Button();
            this.fillCuffButton = new System.Windows.Forms.Button();
            this.PHMSerialPort = new System.IO.Ports.SerialPort(this.components);
            this.PHMMainTimer = new System.Windows.Forms.Timer(this.components);
            this.phmDataZedGraph = new ZedGraph.ZedGraphControl();
            this.showPumpPIDOnGraphCheckBox = new System.Windows.Forms.CheckBox();
            this.pulsePeriodUnitsLabel = new System.Windows.Forms.Label();
            this.pulsePeriodLabel = new System.Windows.Forms.Label();
            this.pulsePeriodDisplayLabel = new System.Windows.Forms.Label();
            this.PHTMMainToolStrip = new System.Windows.Forms.ToolStrip();
            this.COMPortToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.startStopDataToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveDataToFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.PHTMSaveDataFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.pulseLS1ONButton = new System.Windows.Forms.Button();
            this.pulseLS1OFFButton = new System.Windows.Forms.Button();
            this.pulseLS2OFFButton = new System.Windows.Forms.Button();
            this.pulseLS2ONButton = new System.Windows.Forms.Button();
            this.cuffPressureDisplayPanel.SuspendLayout();
            this.systolicPressurePanel.SuspendLayout();
            this.pulseRatePanel.SuspendLayout();
            this.targeyPressurePanel.SuspendLayout();
            this.systemPanel.SuspendLayout();
            this.PHTMMainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cuffPressureDisplayPanel
            // 
            this.cuffPressureDisplayPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cuffPressureDisplayPanel.Controls.Add(this.currentCuffPressureLabel);
            this.cuffPressureDisplayPanel.Controls.Add(this.cuffPressureDisplayLabel);
            this.cuffPressureDisplayPanel.Location = new System.Drawing.Point(524, 18);
            this.cuffPressureDisplayPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cuffPressureDisplayPanel.Name = "cuffPressureDisplayPanel";
            this.cuffPressureDisplayPanel.Size = new System.Drawing.Size(339, 154);
            this.cuffPressureDisplayPanel.TabIndex = 0;
            // 
            // currentCuffPressureLabel
            // 
            this.currentCuffPressureLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.currentCuffPressureLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentCuffPressureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentCuffPressureLabel.Location = new System.Drawing.Point(0, 0);
            this.currentCuffPressureLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentCuffPressureLabel.Name = "currentCuffPressureLabel";
            this.currentCuffPressureLabel.Size = new System.Drawing.Size(339, 49);
            this.currentCuffPressureLabel.TabIndex = 1;
            this.currentCuffPressureLabel.Text = "Current Cuff Pressure (mmHg)";
            this.currentCuffPressureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cuffPressureDisplayLabel
            // 
            this.cuffPressureDisplayLabel.BackColor = System.Drawing.Color.Black;
            this.cuffPressureDisplayLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cuffPressureDisplayLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cuffPressureDisplayLabel.Font = new System.Drawing.Font("Courier New", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuffPressureDisplayLabel.ForeColor = System.Drawing.Color.Lime;
            this.cuffPressureDisplayLabel.Location = new System.Drawing.Point(0, 49);
            this.cuffPressureDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cuffPressureDisplayLabel.Name = "cuffPressureDisplayLabel";
            this.cuffPressureDisplayLabel.Size = new System.Drawing.Size(339, 105);
            this.cuffPressureDisplayLabel.TabIndex = 0;
            this.cuffPressureDisplayLabel.Text = "95";
            this.cuffPressureDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // systolicPressurePanel
            // 
            this.systolicPressurePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.systolicPressurePanel.Controls.Add(this.lastSystolicPressureLabel);
            this.systolicPressurePanel.Controls.Add(this.lastSystolicPressureDisplayLabel);
            this.systolicPressurePanel.Location = new System.Drawing.Point(524, 182);
            this.systolicPressurePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.systolicPressurePanel.Name = "systolicPressurePanel";
            this.systolicPressurePanel.Size = new System.Drawing.Size(339, 154);
            this.systolicPressurePanel.TabIndex = 2;
            // 
            // lastSystolicPressureLabel
            // 
            this.lastSystolicPressureLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lastSystolicPressureLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lastSystolicPressureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastSystolicPressureLabel.Location = new System.Drawing.Point(0, 0);
            this.lastSystolicPressureLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastSystolicPressureLabel.Name = "lastSystolicPressureLabel";
            this.lastSystolicPressureLabel.Size = new System.Drawing.Size(339, 49);
            this.lastSystolicPressureLabel.TabIndex = 1;
            this.lastSystolicPressureLabel.Text = "Last Systolic Pressure (mmHg)";
            this.lastSystolicPressureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lastSystolicPressureDisplayLabel
            // 
            this.lastSystolicPressureDisplayLabel.BackColor = System.Drawing.Color.Black;
            this.lastSystolicPressureDisplayLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lastSystolicPressureDisplayLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lastSystolicPressureDisplayLabel.Font = new System.Drawing.Font("Courier New", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastSystolicPressureDisplayLabel.ForeColor = System.Drawing.Color.Aqua;
            this.lastSystolicPressureDisplayLabel.Location = new System.Drawing.Point(0, 49);
            this.lastSystolicPressureDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastSystolicPressureDisplayLabel.Name = "lastSystolicPressureDisplayLabel";
            this.lastSystolicPressureDisplayLabel.Size = new System.Drawing.Size(339, 105);
            this.lastSystolicPressureDisplayLabel.TabIndex = 0;
            this.lastSystolicPressureDisplayLabel.Text = "92";
            this.lastSystolicPressureDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pulseRatePanel
            // 
            this.pulseRatePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pulseRatePanel.Controls.Add(this.pulseRateLebel);
            this.pulseRatePanel.Controls.Add(this.pulseRateDisplayLabel);
            this.pulseRatePanel.Location = new System.Drawing.Point(524, 345);
            this.pulseRatePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pulseRatePanel.Name = "pulseRatePanel";
            this.pulseRatePanel.Size = new System.Drawing.Size(339, 154);
            this.pulseRatePanel.TabIndex = 5;
            // 
            // pulseRateLebel
            // 
            this.pulseRateLebel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pulseRateLebel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pulseRateLebel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pulseRateLebel.Location = new System.Drawing.Point(0, 0);
            this.pulseRateLebel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pulseRateLebel.Name = "pulseRateLebel";
            this.pulseRateLebel.Size = new System.Drawing.Size(339, 49);
            this.pulseRateLebel.TabIndex = 1;
            this.pulseRateLebel.Text = "Pulse Rate (BPM)";
            this.pulseRateLebel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pulseRateDisplayLabel
            // 
            this.pulseRateDisplayLabel.BackColor = System.Drawing.Color.Black;
            this.pulseRateDisplayLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pulseRateDisplayLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pulseRateDisplayLabel.Font = new System.Drawing.Font("Courier New", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pulseRateDisplayLabel.ForeColor = System.Drawing.Color.Red;
            this.pulseRateDisplayLabel.Location = new System.Drawing.Point(0, 49);
            this.pulseRateDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pulseRateDisplayLabel.Name = "pulseRateDisplayLabel";
            this.pulseRateDisplayLabel.Size = new System.Drawing.Size(339, 105);
            this.pulseRateDisplayLabel.TabIndex = 0;
            this.pulseRateDisplayLabel.Text = "NP";
            this.pulseRateDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // targeyPressurePanel
            // 
            this.targeyPressurePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.targeyPressurePanel.Controls.Add(this.targetPressureDecreaseButton);
            this.targeyPressurePanel.Controls.Add(this.targetPressureIncreaseButton);
            this.targeyPressurePanel.Controls.Add(this.targetPressureLabel);
            this.targeyPressurePanel.Controls.Add(this.targetPressureDisplayLabel);
            this.targeyPressurePanel.Location = new System.Drawing.Point(902, 18);
            this.targeyPressurePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.targeyPressurePanel.Name = "targeyPressurePanel";
            this.targeyPressurePanel.Size = new System.Drawing.Size(339, 154);
            this.targeyPressurePanel.TabIndex = 9;
            // 
            // targetPressureDecreaseButton
            // 
            this.targetPressureDecreaseButton.Image = global::PHTManager.Properties.Resources.down;
            this.targetPressureDecreaseButton.Location = new System.Drawing.Point(0, 100);
            this.targetPressureDecreaseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.targetPressureDecreaseButton.Name = "targetPressureDecreaseButton";
            this.targetPressureDecreaseButton.Size = new System.Drawing.Size(63, 54);
            this.targetPressureDecreaseButton.TabIndex = 3;
            this.targetPressureDecreaseButton.UseVisualStyleBackColor = true;
            this.targetPressureDecreaseButton.Click += new System.EventHandler(this.targetPressureDecreaseButton_Click);
            // 
            // targetPressureIncreaseButton
            // 
            this.targetPressureIncreaseButton.Image = global::PHTManager.Properties.Resources.up;
            this.targetPressureIncreaseButton.Location = new System.Drawing.Point(0, 49);
            this.targetPressureIncreaseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.targetPressureIncreaseButton.Name = "targetPressureIncreaseButton";
            this.targetPressureIncreaseButton.Size = new System.Drawing.Size(63, 54);
            this.targetPressureIncreaseButton.TabIndex = 2;
            this.targetPressureIncreaseButton.UseVisualStyleBackColor = true;
            this.targetPressureIncreaseButton.Click += new System.EventHandler(this.targetPressureIncreaseButton_Click);
            // 
            // targetPressureLabel
            // 
            this.targetPressureLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.targetPressureLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.targetPressureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetPressureLabel.Location = new System.Drawing.Point(0, 0);
            this.targetPressureLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.targetPressureLabel.Name = "targetPressureLabel";
            this.targetPressureLabel.Size = new System.Drawing.Size(339, 49);
            this.targetPressureLabel.TabIndex = 1;
            this.targetPressureLabel.Text = "Target Pressure (mmHg)";
            this.targetPressureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // targetPressureDisplayLabel
            // 
            this.targetPressureDisplayLabel.BackColor = System.Drawing.Color.Black;
            this.targetPressureDisplayLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.targetPressureDisplayLabel.Font = new System.Drawing.Font("Courier New", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetPressureDisplayLabel.ForeColor = System.Drawing.Color.Lime;
            this.targetPressureDisplayLabel.Location = new System.Drawing.Point(60, 49);
            this.targetPressureDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.targetPressureDisplayLabel.Name = "targetPressureDisplayLabel";
            this.targetPressureDisplayLabel.Size = new System.Drawing.Size(279, 105);
            this.targetPressureDisplayLabel.TabIndex = 0;
            this.targetPressureDisplayLabel.Text = "90";
            this.targetPressureDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // systemPanel
            // 
            this.systemPanel.Controls.Add(this.testModeCheckBox);
            this.systemPanel.Controls.Add(this.phmspStopBitsDisplayLabel);
            this.systemPanel.Controls.Add(this.commErrorDisplayLabel);
            this.systemPanel.Controls.Add(this.showAllBufferUpdatesCheckBox);
            this.systemPanel.Controls.Add(this.bytePositionLabel);
            this.systemPanel.Controls.Add(this.inBufferDisplayLabel);
            this.systemPanel.Controls.Add(this.outBufferDisplayLabel);
            this.systemPanel.Controls.Add(this.phmspConnectCheckBox);
            this.systemPanel.Controls.Add(this.phmspDataBitsDisplayLabel);
            this.systemPanel.Controls.Add(this.phmspParityDisplayLabel);
            this.systemPanel.Controls.Add(this.phmspBaudRateDisplayLabel);
            this.systemPanel.Controls.Add(this.phmspPortDisplayLabel);
            this.systemPanel.Controls.Add(this.phmspLabel);
            this.systemPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.systemPanel.Location = new System.Drawing.Point(0, 1048);
            this.systemPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.systemPanel.Name = "systemPanel";
            this.systemPanel.Size = new System.Drawing.Size(1266, 123);
            this.systemPanel.TabIndex = 10;
            // 
            // testModeCheckBox
            // 
            this.testModeCheckBox.AutoSize = true;
            this.testModeCheckBox.Location = new System.Drawing.Point(916, 14);
            this.testModeCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.testModeCheckBox.Name = "testModeCheckBox";
            this.testModeCheckBox.Size = new System.Drawing.Size(110, 24);
            this.testModeCheckBox.TabIndex = 46;
            this.testModeCheckBox.Text = "Test mode";
            this.testModeCheckBox.UseVisualStyleBackColor = true;
            this.testModeCheckBox.CheckedChanged += new System.EventHandler(this.testModeCheckBox_CheckedChanged);
            // 
            // phmspStopBitsDisplayLabel
            // 
            this.phmspStopBitsDisplayLabel.Location = new System.Drawing.Point(504, 12);
            this.phmspStopBitsDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phmspStopBitsDisplayLabel.Name = "phmspStopBitsDisplayLabel";
            this.phmspStopBitsDisplayLabel.Size = new System.Drawing.Size(56, 20);
            this.phmspStopBitsDisplayLabel.TabIndex = 45;
            this.phmspStopBitsDisplayLabel.Text = "One";
            this.phmspStopBitsDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // commErrorDisplayLabel
            // 
            this.commErrorDisplayLabel.Location = new System.Drawing.Point(568, 14);
            this.commErrorDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.commErrorDisplayLabel.Name = "commErrorDisplayLabel";
            this.commErrorDisplayLabel.Size = new System.Drawing.Size(231, 20);
            this.commErrorDisplayLabel.TabIndex = 44;
            this.commErrorDisplayLabel.Text = "Not connected";
            // 
            // showAllBufferUpdatesCheckBox
            // 
            this.showAllBufferUpdatesCheckBox.AutoSize = true;
            this.showAllBufferUpdatesCheckBox.Location = new System.Drawing.Point(1042, 12);
            this.showAllBufferUpdatesCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.showAllBufferUpdatesCheckBox.Name = "showAllBufferUpdatesCheckBox";
            this.showAllBufferUpdatesCheckBox.Size = new System.Drawing.Size(202, 24);
            this.showAllBufferUpdatesCheckBox.TabIndex = 43;
            this.showAllBufferUpdatesCheckBox.Text = "Show all buffer updates";
            this.showAllBufferUpdatesCheckBox.UseVisualStyleBackColor = true;
            // 
            // bytePositionLabel
            // 
            this.bytePositionLabel.AutoSize = true;
            this.bytePositionLabel.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bytePositionLabel.Location = new System.Drawing.Point(14, 38);
            this.bytePositionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bytePositionLabel.Name = "bytePositionLabel";
            this.bytePositionLabel.Size = new System.Drawing.Size(1210, 22);
            this.bytePositionLabel.TabIndex = 42;
            this.bytePositionLabel.Text = "POS: 00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F 10 11 12 13 14 15 16 17 18 1" +
    "9 1A 1B 1C 1D 1E 1F";
            // 
            // inBufferDisplayLabel
            // 
            this.inBufferDisplayLabel.AutoSize = true;
            this.inBufferDisplayLabel.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inBufferDisplayLabel.Location = new System.Drawing.Point(14, 83);
            this.inBufferDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.inBufferDisplayLabel.Name = "inBufferDisplayLabel";
            this.inBufferDisplayLabel.Size = new System.Drawing.Size(58, 22);
            this.inBufferDisplayLabel.TabIndex = 41;
            this.inBufferDisplayLabel.Text = "IN: ";
            // 
            // outBufferDisplayLabel
            // 
            this.outBufferDisplayLabel.AutoSize = true;
            this.outBufferDisplayLabel.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outBufferDisplayLabel.Location = new System.Drawing.Point(14, 63);
            this.outBufferDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.outBufferDisplayLabel.Name = "outBufferDisplayLabel";
            this.outBufferDisplayLabel.Size = new System.Drawing.Size(70, 22);
            this.outBufferDisplayLabel.TabIndex = 40;
            this.outBufferDisplayLabel.Text = "OUT: ";
            // 
            // phmspConnectCheckBox
            // 
            this.phmspConnectCheckBox.AutoSize = true;
            this.phmspConnectCheckBox.Location = new System.Drawing.Point(808, 12);
            this.phmspConnectCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.phmspConnectCheckBox.Name = "phmspConnectCheckBox";
            this.phmspConnectCheckBox.Size = new System.Drawing.Size(95, 24);
            this.phmspConnectCheckBox.TabIndex = 39;
            this.phmspConnectCheckBox.Text = "Connect";
            this.phmspConnectCheckBox.UseVisualStyleBackColor = true;
            this.phmspConnectCheckBox.CheckedChanged += new System.EventHandler(this.phmspConnectCheckBox_CheckedChanged);
            // 
            // phmspDataBitsDisplayLabel
            // 
            this.phmspDataBitsDisplayLabel.Location = new System.Drawing.Point(388, 14);
            this.phmspDataBitsDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phmspDataBitsDisplayLabel.Name = "phmspDataBitsDisplayLabel";
            this.phmspDataBitsDisplayLabel.Size = new System.Drawing.Size(39, 20);
            this.phmspDataBitsDisplayLabel.TabIndex = 37;
            this.phmspDataBitsDisplayLabel.Text = "8";
            this.phmspDataBitsDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // phmspParityDisplayLabel
            // 
            this.phmspParityDisplayLabel.Location = new System.Drawing.Point(436, 14);
            this.phmspParityDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phmspParityDisplayLabel.Name = "phmspParityDisplayLabel";
            this.phmspParityDisplayLabel.Size = new System.Drawing.Size(58, 20);
            this.phmspParityDisplayLabel.TabIndex = 36;
            this.phmspParityDisplayLabel.Text = "None";
            this.phmspParityDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // phmspBaudRateDisplayLabel
            // 
            this.phmspBaudRateDisplayLabel.Location = new System.Drawing.Point(308, 14);
            this.phmspBaudRateDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phmspBaudRateDisplayLabel.Name = "phmspBaudRateDisplayLabel";
            this.phmspBaudRateDisplayLabel.Size = new System.Drawing.Size(72, 20);
            this.phmspBaudRateDisplayLabel.TabIndex = 35;
            this.phmspBaudRateDisplayLabel.Text = "115200";
            this.phmspBaudRateDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // phmspPortDisplayLabel
            // 
            this.phmspPortDisplayLabel.Location = new System.Drawing.Point(226, 14);
            this.phmspPortDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phmspPortDisplayLabel.Name = "phmspPortDisplayLabel";
            this.phmspPortDisplayLabel.Size = new System.Drawing.Size(72, 20);
            this.phmspPortDisplayLabel.TabIndex = 34;
            this.phmspPortDisplayLabel.Text = "COM1";
            this.phmspPortDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // phmspLabel
            // 
            this.phmspLabel.AutoSize = true;
            this.phmspLabel.Location = new System.Drawing.Point(14, 14);
            this.phmspLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phmspLabel.Name = "phmspLabel";
            this.phmspLabel.Size = new System.Drawing.Size(202, 20);
            this.phmspLabel.TabIndex = 33;
            this.phmspLabel.Text = "PHM Main Controller Serial:";
            // 
            // ppgSensitivityDisplayLabel
            // 
            this.ppgSensitivityDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ppgSensitivityDisplayLabel.Location = new System.Drawing.Point(1085, 456);
            this.ppgSensitivityDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ppgSensitivityDisplayLabel.Name = "ppgSensitivityDisplayLabel";
            this.ppgSensitivityDisplayLabel.Size = new System.Drawing.Size(56, 20);
            this.ppgSensitivityDisplayLabel.TabIndex = 38;
            this.ppgSensitivityDisplayLabel.Text = "50";
            this.ppgSensitivityDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ppgSensitivityLabel
            // 
            this.ppgSensitivityLabel.Location = new System.Drawing.Point(898, 456);
            this.ppgSensitivityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ppgSensitivityLabel.Name = "ppgSensitivityLabel";
            this.ppgSensitivityLabel.Size = new System.Drawing.Size(178, 20);
            this.ppgSensitivityLabel.TabIndex = 45;
            this.ppgSensitivityLabel.Text = "PPG Sensitivity:";
            // 
            // ppgSensitivityUnitsLabel
            // 
            this.ppgSensitivityUnitsLabel.Location = new System.Drawing.Point(1150, 456);
            this.ppgSensitivityUnitsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ppgSensitivityUnitsLabel.Name = "ppgSensitivityUnitsLabel";
            this.ppgSensitivityUnitsLabel.Size = new System.Drawing.Size(92, 20);
            this.ppgSensitivityUnitsLabel.TabIndex = 47;
            this.ppgSensitivityUnitsLabel.Text = "mV";
            // 
            // cuffInflationRateUnitsLabel
            // 
            this.cuffInflationRateUnitsLabel.Location = new System.Drawing.Point(1149, 231);
            this.cuffInflationRateUnitsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cuffInflationRateUnitsLabel.Name = "cuffInflationRateUnitsLabel";
            this.cuffInflationRateUnitsLabel.Size = new System.Drawing.Size(92, 20);
            this.cuffInflationRateUnitsLabel.TabIndex = 50;
            this.cuffInflationRateUnitsLabel.Text = "mmHg/s";
            // 
            // cuffInflationRateLabel
            // 
            this.cuffInflationRateLabel.Location = new System.Drawing.Point(897, 231);
            this.cuffInflationRateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cuffInflationRateLabel.Name = "cuffInflationRateLabel";
            this.cuffInflationRateLabel.Size = new System.Drawing.Size(178, 20);
            this.cuffInflationRateLabel.TabIndex = 49;
            this.cuffInflationRateLabel.Text = "Cuff Inflation Rate:";
            // 
            // cuffInflationRateDisplayLabel
            // 
            this.cuffInflationRateDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuffInflationRateDisplayLabel.Location = new System.Drawing.Point(1084, 231);
            this.cuffInflationRateDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cuffInflationRateDisplayLabel.Name = "cuffInflationRateDisplayLabel";
            this.cuffInflationRateDisplayLabel.Size = new System.Drawing.Size(56, 20);
            this.cuffInflationRateDisplayLabel.TabIndex = 48;
            this.cuffInflationRateDisplayLabel.Text = "2.0";
            this.cuffInflationRateDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cuffDeflationRateUnitsLabel
            // 
            this.cuffDeflationRateUnitsLabel.Location = new System.Drawing.Point(1149, 251);
            this.cuffDeflationRateUnitsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cuffDeflationRateUnitsLabel.Name = "cuffDeflationRateUnitsLabel";
            this.cuffDeflationRateUnitsLabel.Size = new System.Drawing.Size(92, 20);
            this.cuffDeflationRateUnitsLabel.TabIndex = 53;
            this.cuffDeflationRateUnitsLabel.Text = "mmHg/s";
            // 
            // cuffDeflationRateLabel
            // 
            this.cuffDeflationRateLabel.Location = new System.Drawing.Point(897, 251);
            this.cuffDeflationRateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cuffDeflationRateLabel.Name = "cuffDeflationRateLabel";
            this.cuffDeflationRateLabel.Size = new System.Drawing.Size(178, 20);
            this.cuffDeflationRateLabel.TabIndex = 52;
            this.cuffDeflationRateLabel.Text = "Cuff Deflation Rate:";
            // 
            // cuffDeflationRateDisplayLabel
            // 
            this.cuffDeflationRateDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuffDeflationRateDisplayLabel.Location = new System.Drawing.Point(1084, 251);
            this.cuffDeflationRateDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cuffDeflationRateDisplayLabel.Name = "cuffDeflationRateDisplayLabel";
            this.cuffDeflationRateDisplayLabel.Size = new System.Drawing.Size(56, 20);
            this.cuffDeflationRateDisplayLabel.TabIndex = 51;
            this.cuffDeflationRateDisplayLabel.Text = "-2.0";
            this.cuffDeflationRateDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // reperfuseButton
            // 
            this.reperfuseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reperfuseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reperfuseButton.Image = global::PHTManager.Properties.Resources.rotate_3d;
            this.reperfuseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reperfuseButton.Location = new System.Drawing.Point(18, 289);
            this.reperfuseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reperfuseButton.Name = "reperfuseButton";
            this.reperfuseButton.Size = new System.Drawing.Size(372, 65);
            this.reperfuseButton.TabIndex = 8;
            this.reperfuseButton.Text = "Reperfuse";
            this.reperfuseButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.reperfuseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.reperfuseButton.UseVisualStyleBackColor = true;
            this.reperfuseButton.Click += new System.EventHandler(this.reperfuseButton_Click);
            // 
            // maintainCuffPressureButton
            // 
            this.maintainCuffPressureButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.maintainCuffPressureButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maintainCuffPressureButton.Image = global::PHTManager.Properties.Resources.disc;
            this.maintainCuffPressureButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.maintainCuffPressureButton.Location = new System.Drawing.Point(18, 142);
            this.maintainCuffPressureButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maintainCuffPressureButton.Name = "maintainCuffPressureButton";
            this.maintainCuffPressureButton.Size = new System.Drawing.Size(372, 65);
            this.maintainCuffPressureButton.TabIndex = 7;
            this.maintainCuffPressureButton.Text = "Maintain cuff pressure";
            this.maintainCuffPressureButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.maintainCuffPressureButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.maintainCuffPressureButton.UseVisualStyleBackColor = true;
            this.maintainCuffPressureButton.Click += new System.EventHandler(this.maintainCuffPressureButton_Click);
            // 
            // findSystolicPressureButton
            // 
            this.findSystolicPressureButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.findSystolicPressureButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findSystolicPressureButton.Image = global::PHTManager.Properties.Resources.forward;
            this.findSystolicPressureButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.findSystolicPressureButton.Location = new System.Drawing.Point(18, 363);
            this.findSystolicPressureButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.findSystolicPressureButton.Name = "findSystolicPressureButton";
            this.findSystolicPressureButton.Size = new System.Drawing.Size(372, 65);
            this.findSystolicPressureButton.TabIndex = 6;
            this.findSystolicPressureButton.Text = "Find systolic pressure";
            this.findSystolicPressureButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.findSystolicPressureButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.findSystolicPressureButton.UseVisualStyleBackColor = true;
            // 
            // ppgPowerOnOffButton
            // 
            this.ppgPowerOnOffButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ppgPowerOnOffButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ppgPowerOnOffButton.Image = global::PHTManager.Properties.Resources.down;
            this.ppgPowerOnOffButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ppgPowerOnOffButton.Location = new System.Drawing.Point(18, 215);
            this.ppgPowerOnOffButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ppgPowerOnOffButton.Name = "ppgPowerOnOffButton";
            this.ppgPowerOnOffButton.Size = new System.Drawing.Size(372, 65);
            this.ppgPowerOnOffButton.TabIndex = 4;
            this.ppgPowerOnOffButton.Text = "Bleed cuff pressure";
            this.ppgPowerOnOffButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ppgPowerOnOffButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ppgPowerOnOffButton.UseVisualStyleBackColor = true;
            this.ppgPowerOnOffButton.Click += new System.EventHandler(this.ppgPowerOnOffButton_Click);
            // 
            // fillCuffButton
            // 
            this.fillCuffButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fillCuffButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fillCuffButton.Image = global::PHTManager.Properties.Resources.up;
            this.fillCuffButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fillCuffButton.Location = new System.Drawing.Point(18, 68);
            this.fillCuffButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fillCuffButton.Name = "fillCuffButton";
            this.fillCuffButton.Size = new System.Drawing.Size(372, 65);
            this.fillCuffButton.TabIndex = 3;
            this.fillCuffButton.Text = "Fill cuff";
            this.fillCuffButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fillCuffButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.fillCuffButton.UseVisualStyleBackColor = true;
            this.fillCuffButton.Click += new System.EventHandler(this.fillCuffButton_Click);
            // 
            // PHMSerialPort
            // 
            this.PHMSerialPort.BaudRate = 115200;
            this.PHMSerialPort.PortName = "COM5";
            this.PHMSerialPort.ReadTimeout = 200;
            this.PHMSerialPort.ReceivedBytesThreshold = 32;
            this.PHMSerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.PHMSerialPort_DataReceived);
            // 
            // PHMMainTimer
            // 
            this.PHMMainTimer.Interval = 50;
            this.PHMMainTimer.Tick += new System.EventHandler(this.PHMMainTimer_Tick);
            // 
            // phmDataZedGraph
            // 
            this.phmDataZedGraph.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.phmDataZedGraph.Location = new System.Drawing.Point(0, 508);
            this.phmDataZedGraph.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.phmDataZedGraph.Name = "phmDataZedGraph";
            this.phmDataZedGraph.ScrollGrace = 0D;
            this.phmDataZedGraph.ScrollMaxX = 0D;
            this.phmDataZedGraph.ScrollMaxY = 0D;
            this.phmDataZedGraph.ScrollMaxY2 = 0D;
            this.phmDataZedGraph.ScrollMinX = 0D;
            this.phmDataZedGraph.ScrollMinY = 0D;
            this.phmDataZedGraph.ScrollMinY2 = 0D;
            this.phmDataZedGraph.Size = new System.Drawing.Size(1266, 540);
            this.phmDataZedGraph.TabIndex = 54;
            // 
            // showPumpPIDOnGraphCheckBox
            // 
            this.showPumpPIDOnGraphCheckBox.AutoSize = true;
            this.showPumpPIDOnGraphCheckBox.Location = new System.Drawing.Point(902, 308);
            this.showPumpPIDOnGraphCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.showPumpPIDOnGraphCheckBox.Name = "showPumpPIDOnGraphCheckBox";
            this.showPumpPIDOnGraphCheckBox.Size = new System.Drawing.Size(218, 24);
            this.showPumpPIDOnGraphCheckBox.TabIndex = 55;
            this.showPumpPIDOnGraphCheckBox.Text = "Show Pump PID on graph";
            this.showPumpPIDOnGraphCheckBox.UseVisualStyleBackColor = true;
            this.showPumpPIDOnGraphCheckBox.CheckedChanged += new System.EventHandler(this.showPumpPIDOnGraphCheckBox_CheckedChanged);
            // 
            // pulsePeriodUnitsLabel
            // 
            this.pulsePeriodUnitsLabel.Location = new System.Drawing.Point(1151, 476);
            this.pulsePeriodUnitsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pulsePeriodUnitsLabel.Name = "pulsePeriodUnitsLabel";
            this.pulsePeriodUnitsLabel.Size = new System.Drawing.Size(92, 20);
            this.pulsePeriodUnitsLabel.TabIndex = 58;
            this.pulsePeriodUnitsLabel.Text = "ms";
            // 
            // pulsePeriodLabel
            // 
            this.pulsePeriodLabel.Location = new System.Drawing.Point(899, 476);
            this.pulsePeriodLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pulsePeriodLabel.Name = "pulsePeriodLabel";
            this.pulsePeriodLabel.Size = new System.Drawing.Size(178, 20);
            this.pulsePeriodLabel.TabIndex = 57;
            this.pulsePeriodLabel.Text = "Pulse period:";
            // 
            // pulsePeriodDisplayLabel
            // 
            this.pulsePeriodDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pulsePeriodDisplayLabel.Location = new System.Drawing.Point(1086, 476);
            this.pulsePeriodDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pulsePeriodDisplayLabel.Name = "pulsePeriodDisplayLabel";
            this.pulsePeriodDisplayLabel.Size = new System.Drawing.Size(56, 20);
            this.pulsePeriodDisplayLabel.TabIndex = 56;
            this.pulsePeriodDisplayLabel.Text = "100";
            this.pulsePeriodDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PHTMMainToolStrip
            // 
            this.PHTMMainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.PHTMMainToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.PHTMMainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.COMPortToolStripComboBox,
            this.startStopDataToolStripButton,
            this.saveDataToFileToolStripButton});
            this.PHTMMainToolStrip.Location = new System.Drawing.Point(18, 443);
            this.PHTMMainToolStrip.Name = "PHTMMainToolStrip";
            this.PHTMMainToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.PHTMMainToolStrip.Size = new System.Drawing.Size(181, 33);
            this.PHTMMainToolStrip.TabIndex = 59;
            this.PHTMMainToolStrip.Text = "toolStrip1";
            // 
            // COMPortToolStripComboBox
            // 
            this.COMPortToolStripComboBox.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.COMPortToolStripComboBox.Name = "COMPortToolStripComboBox";
            this.COMPortToolStripComboBox.Size = new System.Drawing.Size(110, 33);
            this.COMPortToolStripComboBox.Text = global::PHTManager.Properties.Settings.Default.LastCOMPortSetting;
            this.COMPortToolStripComboBox.TextChanged += new System.EventHandler(this.COMPortToolStripComboBox_TextChanged);
            // 
            // startStopDataToolStripButton
            // 
            this.startStopDataToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startStopDataToolStripButton.Image = global::PHTManager.Properties.Resources.on;
            this.startStopDataToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startStopDataToolStripButton.Name = "startStopDataToolStripButton";
            this.startStopDataToolStripButton.Size = new System.Drawing.Size(28, 30);
            this.startStopDataToolStripButton.Text = "Start / Stop";
            this.startStopDataToolStripButton.Click += new System.EventHandler(this.startStopDataToolStripButton_Click);
            // 
            // saveDataToFileToolStripButton
            // 
            this.saveDataToFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveDataToFileToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveDataToFileToolStripButton.Image")));
            this.saveDataToFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveDataToFileToolStripButton.Name = "saveDataToFileToolStripButton";
            this.saveDataToFileToolStripButton.Size = new System.Drawing.Size(28, 30);
            this.saveDataToFileToolStripButton.Text = "Save data to a CSV file";
            this.saveDataToFileToolStripButton.Click += new System.EventHandler(this.saveDataToFileToolStripButton_Click);
            // 
            // PHTMSaveDataFileDialog
            // 
            this.PHTMSaveDataFileDialog.DefaultExt = "csv";
            this.PHTMSaveDataFileDialog.FileName = "PHTMData0000";
            this.PHTMSaveDataFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            // 
            // pulseLS1ONButton
            // 
            this.pulseLS1ONButton.Enabled = false;
            this.pulseLS1ONButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pulseLS1ONButton.Location = new System.Drawing.Point(901, 345);
            this.pulseLS1ONButton.Name = "pulseLS1ONButton";
            this.pulseLS1ONButton.Size = new System.Drawing.Size(104, 23);
            this.pulseLS1ONButton.TabIndex = 60;
            this.pulseLS1ONButton.Text = "Pulse LS1 ON";
            this.pulseLS1ONButton.UseVisualStyleBackColor = true;
            this.pulseLS1ONButton.Click += new System.EventHandler(this.pulseLS1ONButton_Click);
            // 
            // pulseLS1OFFButton
            // 
            this.pulseLS1OFFButton.Enabled = false;
            this.pulseLS1OFFButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pulseLS1OFFButton.Location = new System.Drawing.Point(901, 374);
            this.pulseLS1OFFButton.Name = "pulseLS1OFFButton";
            this.pulseLS1OFFButton.Size = new System.Drawing.Size(104, 23);
            this.pulseLS1OFFButton.TabIndex = 61;
            this.pulseLS1OFFButton.Text = "Pulse LS1 OFF";
            this.pulseLS1OFFButton.UseVisualStyleBackColor = true;
            this.pulseLS1OFFButton.Click += new System.EventHandler(this.pulseLS1OFFButton_Click);
            // 
            // pulseLS2OFFButton
            // 
            this.pulseLS2OFFButton.Enabled = false;
            this.pulseLS2OFFButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pulseLS2OFFButton.Location = new System.Drawing.Point(1011, 374);
            this.pulseLS2OFFButton.Name = "pulseLS2OFFButton";
            this.pulseLS2OFFButton.Size = new System.Drawing.Size(104, 23);
            this.pulseLS2OFFButton.TabIndex = 63;
            this.pulseLS2OFFButton.Text = "Pulse LS2 OFF";
            this.pulseLS2OFFButton.UseVisualStyleBackColor = true;
            this.pulseLS2OFFButton.Click += new System.EventHandler(this.pulseLS2OFFButton_Click);
            // 
            // pulseLS2ONButton
            // 
            this.pulseLS2ONButton.Enabled = false;
            this.pulseLS2ONButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pulseLS2ONButton.Location = new System.Drawing.Point(1011, 345);
            this.pulseLS2ONButton.Name = "pulseLS2ONButton";
            this.pulseLS2ONButton.Size = new System.Drawing.Size(104, 23);
            this.pulseLS2ONButton.TabIndex = 62;
            this.pulseLS2ONButton.Text = "Pulse LS2 ON";
            this.pulseLS2ONButton.UseVisualStyleBackColor = true;
            this.pulseLS2ONButton.Click += new System.EventHandler(this.pulseLS2ONButton_Click);
            // 
            // PHTManagerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 1171);
            this.Controls.Add(this.pulseLS2OFFButton);
            this.Controls.Add(this.pulseLS2ONButton);
            this.Controls.Add(this.pulseLS1OFFButton);
            this.Controls.Add(this.pulseLS1ONButton);
            this.Controls.Add(this.PHTMMainToolStrip);
            this.Controls.Add(this.pulsePeriodUnitsLabel);
            this.Controls.Add(this.pulsePeriodLabel);
            this.Controls.Add(this.pulsePeriodDisplayLabel);
            this.Controls.Add(this.showPumpPIDOnGraphCheckBox);
            this.Controls.Add(this.phmDataZedGraph);
            this.Controls.Add(this.cuffDeflationRateUnitsLabel);
            this.Controls.Add(this.cuffDeflationRateLabel);
            this.Controls.Add(this.cuffDeflationRateDisplayLabel);
            this.Controls.Add(this.cuffInflationRateUnitsLabel);
            this.Controls.Add(this.cuffInflationRateLabel);
            this.Controls.Add(this.cuffInflationRateDisplayLabel);
            this.Controls.Add(this.ppgSensitivityUnitsLabel);
            this.Controls.Add(this.ppgSensitivityLabel);
            this.Controls.Add(this.systemPanel);
            this.Controls.Add(this.targeyPressurePanel);
            this.Controls.Add(this.reperfuseButton);
            this.Controls.Add(this.maintainCuffPressureButton);
            this.Controls.Add(this.ppgSensitivityDisplayLabel);
            this.Controls.Add(this.findSystolicPressureButton);
            this.Controls.Add(this.pulseRatePanel);
            this.Controls.Add(this.ppgPowerOnOffButton);
            this.Controls.Add(this.fillCuffButton);
            this.Controls.Add(this.systolicPressurePanel);
            this.Controls.Add(this.cuffPressureDisplayPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PHTManagerMain";
            this.Text = "Permissive Hypotension Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PHTManagerMain_FormClosing);
            this.Load += new System.EventHandler(this.PHTManagerMain_Load);
            this.Resize += new System.EventHandler(this.PHTManagerMain_Resize);
            this.cuffPressureDisplayPanel.ResumeLayout(false);
            this.systolicPressurePanel.ResumeLayout(false);
            this.pulseRatePanel.ResumeLayout(false);
            this.targeyPressurePanel.ResumeLayout(false);
            this.systemPanel.ResumeLayout(false);
            this.systemPanel.PerformLayout();
            this.PHTMMainToolStrip.ResumeLayout(false);
            this.PHTMMainToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel cuffPressureDisplayPanel;
        private System.Windows.Forms.Label currentCuffPressureLabel;
        private System.Windows.Forms.Label cuffPressureDisplayLabel;
        private System.Windows.Forms.Panel systolicPressurePanel;
        private System.Windows.Forms.Label lastSystolicPressureLabel;
        private System.Windows.Forms.Label lastSystolicPressureDisplayLabel;
        private System.Windows.Forms.Button fillCuffButton;
        private System.Windows.Forms.Button ppgPowerOnOffButton;
        private System.Windows.Forms.Panel pulseRatePanel;
        private System.Windows.Forms.Label pulseRateLebel;
        private System.Windows.Forms.Label pulseRateDisplayLabel;
        private System.Windows.Forms.Button findSystolicPressureButton;
        private System.Windows.Forms.Button maintainCuffPressureButton;
        private System.Windows.Forms.Button reperfuseButton;
        private System.Windows.Forms.Panel targeyPressurePanel;
        private System.Windows.Forms.Button targetPressureIncreaseButton;
        private System.Windows.Forms.Label targetPressureLabel;
        private System.Windows.Forms.Label targetPressureDisplayLabel;
        private System.Windows.Forms.Button targetPressureDecreaseButton;
        private System.Windows.Forms.Panel systemPanel;
        private System.Windows.Forms.Label commErrorDisplayLabel;
        private System.Windows.Forms.CheckBox showAllBufferUpdatesCheckBox;
        private System.Windows.Forms.Label bytePositionLabel;
        private System.Windows.Forms.Label inBufferDisplayLabel;
        private System.Windows.Forms.Label outBufferDisplayLabel;
        private System.Windows.Forms.CheckBox phmspConnectCheckBox;
        private System.Windows.Forms.Label ppgSensitivityDisplayLabel;
        private System.Windows.Forms.Label phmspDataBitsDisplayLabel;
        private System.Windows.Forms.Label phmspParityDisplayLabel;
        private System.Windows.Forms.Label phmspBaudRateDisplayLabel;
        private System.Windows.Forms.Label phmspPortDisplayLabel;
        private System.Windows.Forms.Label phmspLabel;
        private System.Windows.Forms.Label ppgSensitivityLabel;
        private System.Windows.Forms.Label ppgSensitivityUnitsLabel;
        private System.Windows.Forms.Label cuffInflationRateUnitsLabel;
        private System.Windows.Forms.Label cuffInflationRateLabel;
        private System.Windows.Forms.Label cuffInflationRateDisplayLabel;
        private System.Windows.Forms.Label cuffDeflationRateUnitsLabel;
        private System.Windows.Forms.Label cuffDeflationRateLabel;
        private System.Windows.Forms.Label cuffDeflationRateDisplayLabel;
        private System.IO.Ports.SerialPort PHMSerialPort;
        private System.Windows.Forms.Label phmspStopBitsDisplayLabel;
        private System.Windows.Forms.Timer PHMMainTimer;
        private System.Windows.Forms.CheckBox testModeCheckBox;
        private ZedGraph.ZedGraphControl phmDataZedGraph;
        private System.Windows.Forms.CheckBox showPumpPIDOnGraphCheckBox;
        private System.Windows.Forms.Label pulsePeriodUnitsLabel;
        private System.Windows.Forms.Label pulsePeriodLabel;
        private System.Windows.Forms.Label pulsePeriodDisplayLabel;
        private System.Windows.Forms.ToolStrip PHTMMainToolStrip;
        private System.Windows.Forms.ToolStripComboBox COMPortToolStripComboBox;
        private System.Windows.Forms.ToolStripButton startStopDataToolStripButton;
        private System.Windows.Forms.ToolStripButton saveDataToFileToolStripButton;
        private System.Windows.Forms.SaveFileDialog PHTMSaveDataFileDialog;
        private System.Windows.Forms.Button pulseLS1ONButton;
        private System.Windows.Forms.Button pulseLS1OFFButton;
        private System.Windows.Forms.Button pulseLS2OFFButton;
        private System.Windows.Forms.Button pulseLS2ONButton;
    }
}

