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
            this.calculatePulseRateCheckBox = new System.Windows.Forms.CheckBox();
            this.pulseRateLebel = new System.Windows.Forms.Label();
            this.pulseRateDisplayLabel = new System.Windows.Forms.Label();
            this.targetPressurePanel = new System.Windows.Forms.Panel();
            this.targetPressureDecreaseButton = new System.Windows.Forms.Button();
            this.targetPressureIncreaseButton = new System.Windows.Forms.Button();
            this.targetPressureLabel = new System.Windows.Forms.Label();
            this.targetPressureDisplayLabel = new System.Windows.Forms.Label();
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
            this.bleedCuffPressureButton = new System.Windows.Forms.Button();
            this.fillCuffButton = new System.Windows.Forms.Button();
            this.PHMSerialPort = new System.IO.Ports.SerialPort(this.components);
            this.PHMMainTimer = new System.Windows.Forms.Timer(this.components);
            this.showPumpPIDOnGraphCheckBox = new System.Windows.Forms.CheckBox();
            this.pulsePeriodUnitsLabel = new System.Windows.Forms.Label();
            this.pulsePeriodLabel = new System.Windows.Forms.Label();
            this.pulsePeriodDisplayLabel = new System.Windows.Forms.Label();
            this.PHTMMainToolStrip = new System.Windows.Forms.ToolStrip();
            this.COMPortToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.PHTMSaveDataFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.TestControlPanel = new System.Windows.Forms.Panel();
            this.pulseLS3OFFButton = new System.Windows.Forms.Button();
            this.pulseLS3ONButton = new System.Windows.Forms.Button();
            this.pulseLS1ONButton = new System.Windows.Forms.Button();
            this.pulseLS2OFFButton = new System.Windows.Forms.Button();
            this.pulseLS1OFFButton = new System.Windows.Forms.Button();
            this.pulseLS2ONButton = new System.Windows.Forms.Button();
            this.rawTargetPressureLabel = new System.Windows.Forms.Label();
            this.rawTargetPressureDisplayLabel = new System.Windows.Forms.Label();
            this.pumpPIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.connectButton = new System.Windows.Forms.Button();
            this.saveDataButton = new System.Windows.Forms.Button();
            this.cuffPressureADCUnitsLabel = new System.Windows.Forms.Label();
            this.cuffPressureADCLabel = new System.Windows.Forms.Label();
            this.cuffPressureADCDisplayLabel = new System.Windows.Forms.Label();
            this.uploadFirmwareButton = new System.Windows.Forms.Button();
            this.openHexFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.GraphTabPage = new System.Windows.Forms.TabPage();
            this.phmDataZedGraph = new ZedGraph.ZedGraphControl();
            this.SettingsTabPage = new System.Windows.Forms.TabPage();
            this.systemPanel = new System.Windows.Forms.Panel();
            this.testModeCheckBox = new System.Windows.Forms.CheckBox();
            this.phmspStopBitsDisplayLabel = new System.Windows.Forms.Label();
            this.commErrorDisplayLabel = new System.Windows.Forms.Label();
            this.showAllBufferUpdatesCheckBox = new System.Windows.Forms.CheckBox();
            this.bytePositionLabel = new System.Windows.Forms.Label();
            this.inBufferDisplayLabel = new System.Windows.Forms.Label();
            this.outBufferDisplayLabel = new System.Windows.Forms.Label();
            this.phmspDataBitsDisplayLabel = new System.Windows.Forms.Label();
            this.phmspParityDisplayLabel = new System.Windows.Forms.Label();
            this.phmspBaudRateDisplayLabel = new System.Windows.Forms.Label();
            this.phmspPortDisplayLabel = new System.Windows.Forms.Label();
            this.phmspLabel = new System.Windows.Forms.Label();
            this.bleedRatePanel = new System.Windows.Forms.Panel();
            this.bleedRateDecreaseButton = new System.Windows.Forms.Button();
            this.bleedRateIncreaseButton = new System.Windows.Forms.Button();
            this.bleedRateLebel = new System.Windows.Forms.Label();
            this.bleedRateDisplayLabel = new System.Windows.Forms.Label();
            this.cuffPressureDisplayPanel.SuspendLayout();
            this.systolicPressurePanel.SuspendLayout();
            this.pulseRatePanel.SuspendLayout();
            this.targetPressurePanel.SuspendLayout();
            this.PHTMMainToolStrip.SuspendLayout();
            this.TestControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pumpPIDNumericUpDown)).BeginInit();
            this.MainTabControl.SuspendLayout();
            this.GraphTabPage.SuspendLayout();
            this.SettingsTabPage.SuspendLayout();
            this.systemPanel.SuspendLayout();
            this.bleedRatePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cuffPressureDisplayPanel
            // 
            this.cuffPressureDisplayPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cuffPressureDisplayPanel.Controls.Add(this.currentCuffPressureLabel);
            this.cuffPressureDisplayPanel.Controls.Add(this.cuffPressureDisplayLabel);
            this.cuffPressureDisplayPanel.Location = new System.Drawing.Point(532, 20);
            this.cuffPressureDisplayPanel.Margin = new System.Windows.Forms.Padding(6);
            this.cuffPressureDisplayPanel.Name = "cuffPressureDisplayPanel";
            this.cuffPressureDisplayPanel.Size = new System.Drawing.Size(452, 192);
            this.cuffPressureDisplayPanel.TabIndex = 0;
            // 
            // currentCuffPressureLabel
            // 
            this.currentCuffPressureLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.currentCuffPressureLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentCuffPressureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentCuffPressureLabel.Location = new System.Drawing.Point(0, 0);
            this.currentCuffPressureLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.currentCuffPressureLabel.Name = "currentCuffPressureLabel";
            this.currentCuffPressureLabel.Size = new System.Drawing.Size(452, 61);
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
            this.cuffPressureDisplayLabel.Location = new System.Drawing.Point(0, 61);
            this.cuffPressureDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.cuffPressureDisplayLabel.Name = "cuffPressureDisplayLabel";
            this.cuffPressureDisplayLabel.Size = new System.Drawing.Size(452, 131);
            this.cuffPressureDisplayLabel.TabIndex = 0;
            this.cuffPressureDisplayLabel.Text = "0";
            this.cuffPressureDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // systolicPressurePanel
            // 
            this.systolicPressurePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.systolicPressurePanel.Controls.Add(this.lastSystolicPressureLabel);
            this.systolicPressurePanel.Controls.Add(this.lastSystolicPressureDisplayLabel);
            this.systolicPressurePanel.Location = new System.Drawing.Point(532, 224);
            this.systolicPressurePanel.Margin = new System.Windows.Forms.Padding(6);
            this.systolicPressurePanel.Name = "systolicPressurePanel";
            this.systolicPressurePanel.Size = new System.Drawing.Size(452, 192);
            this.systolicPressurePanel.TabIndex = 2;
            // 
            // lastSystolicPressureLabel
            // 
            this.lastSystolicPressureLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lastSystolicPressureLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lastSystolicPressureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastSystolicPressureLabel.Location = new System.Drawing.Point(0, 0);
            this.lastSystolicPressureLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lastSystolicPressureLabel.Name = "lastSystolicPressureLabel";
            this.lastSystolicPressureLabel.Size = new System.Drawing.Size(452, 61);
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
            this.lastSystolicPressureDisplayLabel.Location = new System.Drawing.Point(0, 61);
            this.lastSystolicPressureDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lastSystolicPressureDisplayLabel.Name = "lastSystolicPressureDisplayLabel";
            this.lastSystolicPressureDisplayLabel.Size = new System.Drawing.Size(452, 131);
            this.lastSystolicPressureDisplayLabel.TabIndex = 0;
            this.lastSystolicPressureDisplayLabel.Text = "0";
            this.lastSystolicPressureDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pulseRatePanel
            // 
            this.pulseRatePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pulseRatePanel.Controls.Add(this.calculatePulseRateCheckBox);
            this.pulseRatePanel.Controls.Add(this.pulseRateLebel);
            this.pulseRatePanel.Controls.Add(this.pulseRateDisplayLabel);
            this.pulseRatePanel.Location = new System.Drawing.Point(532, 428);
            this.pulseRatePanel.Margin = new System.Windows.Forms.Padding(6);
            this.pulseRatePanel.Name = "pulseRatePanel";
            this.pulseRatePanel.Size = new System.Drawing.Size(452, 192);
            this.pulseRatePanel.TabIndex = 5;
            // 
            // calculatePulseRateCheckBox
            // 
            this.calculatePulseRateCheckBox.AutoSize = true;
            this.calculatePulseRateCheckBox.Location = new System.Drawing.Point(24, 17);
            this.calculatePulseRateCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.calculatePulseRateCheckBox.Name = "calculatePulseRateCheckBox";
            this.calculatePulseRateCheckBox.Size = new System.Drawing.Size(28, 27);
            this.calculatePulseRateCheckBox.TabIndex = 2;
            this.calculatePulseRateCheckBox.UseVisualStyleBackColor = true;
            this.calculatePulseRateCheckBox.CheckedChanged += new System.EventHandler(this.calculatePulseRateCheckBox_CheckedChanged);
            // 
            // pulseRateLebel
            // 
            this.pulseRateLebel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pulseRateLebel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pulseRateLebel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pulseRateLebel.Location = new System.Drawing.Point(0, 0);
            this.pulseRateLebel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.pulseRateLebel.Name = "pulseRateLebel";
            this.pulseRateLebel.Size = new System.Drawing.Size(452, 61);
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
            this.pulseRateDisplayLabel.Location = new System.Drawing.Point(0, 61);
            this.pulseRateDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.pulseRateDisplayLabel.Name = "pulseRateDisplayLabel";
            this.pulseRateDisplayLabel.Size = new System.Drawing.Size(452, 131);
            this.pulseRateDisplayLabel.TabIndex = 0;
            this.pulseRateDisplayLabel.Text = "NP";
            this.pulseRateDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // targetPressurePanel
            // 
            this.targetPressurePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.targetPressurePanel.Controls.Add(this.targetPressureDecreaseButton);
            this.targetPressurePanel.Controls.Add(this.targetPressureIncreaseButton);
            this.targetPressurePanel.Controls.Add(this.targetPressureLabel);
            this.targetPressurePanel.Controls.Add(this.targetPressureDisplayLabel);
            this.targetPressurePanel.Location = new System.Drawing.Point(1202, 23);
            this.targetPressurePanel.Margin = new System.Windows.Forms.Padding(6);
            this.targetPressurePanel.Name = "targetPressurePanel";
            this.targetPressurePanel.Size = new System.Drawing.Size(452, 192);
            this.targetPressurePanel.TabIndex = 9;
            // 
            // targetPressureDecreaseButton
            // 
            this.targetPressureDecreaseButton.Image = global::PHTManager.Properties.Resources.down;
            this.targetPressureDecreaseButton.Location = new System.Drawing.Point(0, 125);
            this.targetPressureDecreaseButton.Margin = new System.Windows.Forms.Padding(6);
            this.targetPressureDecreaseButton.Name = "targetPressureDecreaseButton";
            this.targetPressureDecreaseButton.Size = new System.Drawing.Size(84, 67);
            this.targetPressureDecreaseButton.TabIndex = 3;
            this.targetPressureDecreaseButton.UseVisualStyleBackColor = true;
            this.targetPressureDecreaseButton.Click += new System.EventHandler(this.targetPressureDecreaseButton_Click);
            // 
            // targetPressureIncreaseButton
            // 
            this.targetPressureIncreaseButton.Image = global::PHTManager.Properties.Resources.up;
            this.targetPressureIncreaseButton.Location = new System.Drawing.Point(0, 61);
            this.targetPressureIncreaseButton.Margin = new System.Windows.Forms.Padding(6);
            this.targetPressureIncreaseButton.Name = "targetPressureIncreaseButton";
            this.targetPressureIncreaseButton.Size = new System.Drawing.Size(84, 67);
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
            this.targetPressureLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.targetPressureLabel.Name = "targetPressureLabel";
            this.targetPressureLabel.Size = new System.Drawing.Size(452, 61);
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
            this.targetPressureDisplayLabel.Location = new System.Drawing.Point(80, 61);
            this.targetPressureDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.targetPressureDisplayLabel.Name = "targetPressureDisplayLabel";
            this.targetPressureDisplayLabel.Size = new System.Drawing.Size(372, 131);
            this.targetPressureDisplayLabel.TabIndex = 0;
            this.targetPressureDisplayLabel.Text = "90";
            this.targetPressureDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ppgSensitivityDisplayLabel
            // 
            this.ppgSensitivityDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ppgSensitivityDisplayLabel.Location = new System.Drawing.Point(1437, 230);
            this.ppgSensitivityDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ppgSensitivityDisplayLabel.Name = "ppgSensitivityDisplayLabel";
            this.ppgSensitivityDisplayLabel.Size = new System.Drawing.Size(74, 25);
            this.ppgSensitivityDisplayLabel.TabIndex = 38;
            this.ppgSensitivityDisplayLabel.Text = "50";
            this.ppgSensitivityDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ppgSensitivityLabel
            // 
            this.ppgSensitivityLabel.Location = new System.Drawing.Point(1189, 230);
            this.ppgSensitivityLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ppgSensitivityLabel.Name = "ppgSensitivityLabel";
            this.ppgSensitivityLabel.Size = new System.Drawing.Size(238, 25);
            this.ppgSensitivityLabel.TabIndex = 45;
            this.ppgSensitivityLabel.Text = "PPG Sensitivity:";
            // 
            // ppgSensitivityUnitsLabel
            // 
            this.ppgSensitivityUnitsLabel.Location = new System.Drawing.Point(1525, 230);
            this.ppgSensitivityUnitsLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ppgSensitivityUnitsLabel.Name = "ppgSensitivityUnitsLabel";
            this.ppgSensitivityUnitsLabel.Size = new System.Drawing.Size(122, 25);
            this.ppgSensitivityUnitsLabel.TabIndex = 47;
            this.ppgSensitivityUnitsLabel.Text = "mV";
            // 
            // cuffInflationRateUnitsLabel
            // 
            this.cuffInflationRateUnitsLabel.Location = new System.Drawing.Point(1523, 309);
            this.cuffInflationRateUnitsLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.cuffInflationRateUnitsLabel.Name = "cuffInflationRateUnitsLabel";
            this.cuffInflationRateUnitsLabel.Size = new System.Drawing.Size(122, 25);
            this.cuffInflationRateUnitsLabel.TabIndex = 50;
            this.cuffInflationRateUnitsLabel.Text = "mmHg/s";
            // 
            // cuffInflationRateLabel
            // 
            this.cuffInflationRateLabel.Location = new System.Drawing.Point(1187, 309);
            this.cuffInflationRateLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.cuffInflationRateLabel.Name = "cuffInflationRateLabel";
            this.cuffInflationRateLabel.Size = new System.Drawing.Size(238, 25);
            this.cuffInflationRateLabel.TabIndex = 49;
            this.cuffInflationRateLabel.Text = "Cuff Inflation Rate:";
            // 
            // cuffInflationRateDisplayLabel
            // 
            this.cuffInflationRateDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuffInflationRateDisplayLabel.Location = new System.Drawing.Point(1437, 309);
            this.cuffInflationRateDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.cuffInflationRateDisplayLabel.Name = "cuffInflationRateDisplayLabel";
            this.cuffInflationRateDisplayLabel.Size = new System.Drawing.Size(74, 25);
            this.cuffInflationRateDisplayLabel.TabIndex = 48;
            this.cuffInflationRateDisplayLabel.Text = "2.0";
            this.cuffInflationRateDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cuffDeflationRateUnitsLabel
            // 
            this.cuffDeflationRateUnitsLabel.Location = new System.Drawing.Point(1523, 334);
            this.cuffDeflationRateUnitsLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.cuffDeflationRateUnitsLabel.Name = "cuffDeflationRateUnitsLabel";
            this.cuffDeflationRateUnitsLabel.Size = new System.Drawing.Size(122, 25);
            this.cuffDeflationRateUnitsLabel.TabIndex = 53;
            this.cuffDeflationRateUnitsLabel.Text = "mmHg/s";
            // 
            // cuffDeflationRateLabel
            // 
            this.cuffDeflationRateLabel.Location = new System.Drawing.Point(1187, 334);
            this.cuffDeflationRateLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.cuffDeflationRateLabel.Name = "cuffDeflationRateLabel";
            this.cuffDeflationRateLabel.Size = new System.Drawing.Size(238, 25);
            this.cuffDeflationRateLabel.TabIndex = 52;
            this.cuffDeflationRateLabel.Text = "Cuff Deflation Rate:";
            // 
            // cuffDeflationRateDisplayLabel
            // 
            this.cuffDeflationRateDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuffDeflationRateDisplayLabel.Location = new System.Drawing.Point(1437, 334);
            this.cuffDeflationRateDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.cuffDeflationRateDisplayLabel.Name = "cuffDeflationRateDisplayLabel";
            this.cuffDeflationRateDisplayLabel.Size = new System.Drawing.Size(74, 25);
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
            this.reperfuseButton.Location = new System.Drawing.Point(22, 445);
            this.reperfuseButton.Margin = new System.Windows.Forms.Padding(6);
            this.reperfuseButton.Name = "reperfuseButton";
            this.reperfuseButton.Size = new System.Drawing.Size(496, 81);
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
            this.maintainCuffPressureButton.Location = new System.Drawing.Point(22, 261);
            this.maintainCuffPressureButton.Margin = new System.Windows.Forms.Padding(6);
            this.maintainCuffPressureButton.Name = "maintainCuffPressureButton";
            this.maintainCuffPressureButton.Size = new System.Drawing.Size(496, 81);
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
            this.findSystolicPressureButton.Enabled = false;
            this.findSystolicPressureButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findSystolicPressureButton.Image = global::PHTManager.Properties.Resources.forward;
            this.findSystolicPressureButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.findSystolicPressureButton.Location = new System.Drawing.Point(22, 537);
            this.findSystolicPressureButton.Margin = new System.Windows.Forms.Padding(6);
            this.findSystolicPressureButton.Name = "findSystolicPressureButton";
            this.findSystolicPressureButton.Size = new System.Drawing.Size(496, 81);
            this.findSystolicPressureButton.TabIndex = 6;
            this.findSystolicPressureButton.Text = "Find systolic pressure";
            this.findSystolicPressureButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.findSystolicPressureButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.findSystolicPressureButton.UseVisualStyleBackColor = true;
            // 
            // bleedCuffPressureButton
            // 
            this.bleedCuffPressureButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bleedCuffPressureButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bleedCuffPressureButton.Image = global::PHTManager.Properties.Resources.down;
            this.bleedCuffPressureButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bleedCuffPressureButton.Location = new System.Drawing.Point(22, 353);
            this.bleedCuffPressureButton.Margin = new System.Windows.Forms.Padding(6);
            this.bleedCuffPressureButton.Name = "bleedCuffPressureButton";
            this.bleedCuffPressureButton.Size = new System.Drawing.Size(496, 81);
            this.bleedCuffPressureButton.TabIndex = 4;
            this.bleedCuffPressureButton.Text = "Bleed cuff pressure";
            this.bleedCuffPressureButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bleedCuffPressureButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bleedCuffPressureButton.UseVisualStyleBackColor = true;
            this.bleedCuffPressureButton.Click += new System.EventHandler(this.bleedCuffPressureButton_Click);
            // 
            // fillCuffButton
            // 
            this.fillCuffButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fillCuffButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fillCuffButton.Image = global::PHTManager.Properties.Resources.up;
            this.fillCuffButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fillCuffButton.Location = new System.Drawing.Point(22, 168);
            this.fillCuffButton.Margin = new System.Windows.Forms.Padding(6);
            this.fillCuffButton.Name = "fillCuffButton";
            this.fillCuffButton.Size = new System.Drawing.Size(496, 81);
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
            this.PHMMainTimer.Interval = 10;
            this.PHMMainTimer.Tick += new System.EventHandler(this.PHMMainTimer_Tick);
            // 
            // showPumpPIDOnGraphCheckBox
            // 
            this.showPumpPIDOnGraphCheckBox.AutoSize = true;
            this.showPumpPIDOnGraphCheckBox.Location = new System.Drawing.Point(1196, 85);
            this.showPumpPIDOnGraphCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.showPumpPIDOnGraphCheckBox.Name = "showPumpPIDOnGraphCheckBox";
            this.showPumpPIDOnGraphCheckBox.Size = new System.Drawing.Size(289, 29);
            this.showPumpPIDOnGraphCheckBox.TabIndex = 55;
            this.showPumpPIDOnGraphCheckBox.Text = "Show Pump PID on graph";
            this.showPumpPIDOnGraphCheckBox.UseVisualStyleBackColor = true;
            this.showPumpPIDOnGraphCheckBox.CheckedChanged += new System.EventHandler(this.showPumpPIDOnGraphCheckBox_CheckedChanged);
            // 
            // pulsePeriodUnitsLabel
            // 
            this.pulsePeriodUnitsLabel.Location = new System.Drawing.Point(1525, 255);
            this.pulsePeriodUnitsLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.pulsePeriodUnitsLabel.Name = "pulsePeriodUnitsLabel";
            this.pulsePeriodUnitsLabel.Size = new System.Drawing.Size(122, 25);
            this.pulsePeriodUnitsLabel.TabIndex = 58;
            this.pulsePeriodUnitsLabel.Text = "ms";
            // 
            // pulsePeriodLabel
            // 
            this.pulsePeriodLabel.Location = new System.Drawing.Point(1189, 255);
            this.pulsePeriodLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.pulsePeriodLabel.Name = "pulsePeriodLabel";
            this.pulsePeriodLabel.Size = new System.Drawing.Size(238, 25);
            this.pulsePeriodLabel.TabIndex = 57;
            this.pulsePeriodLabel.Text = "Pulse period:";
            // 
            // pulsePeriodDisplayLabel
            // 
            this.pulsePeriodDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pulsePeriodDisplayLabel.Location = new System.Drawing.Point(1439, 255);
            this.pulsePeriodDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.pulsePeriodDisplayLabel.Name = "pulsePeriodDisplayLabel";
            this.pulsePeriodDisplayLabel.Size = new System.Drawing.Size(74, 25);
            this.pulsePeriodDisplayLabel.TabIndex = 56;
            this.pulsePeriodDisplayLabel.Text = "100";
            this.pulsePeriodDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PHTMMainToolStrip
            // 
            this.PHTMMainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.PHTMMainToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.PHTMMainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.COMPortToolStripComboBox});
            this.PHTMMainToolStrip.Location = new System.Drawing.Point(22, 84);
            this.PHTMMainToolStrip.Name = "PHTMMainToolStrip";
            this.PHTMMainToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.PHTMMainToolStrip.Size = new System.Drawing.Size(161, 40);
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
            this.COMPortToolStripComboBox.Size = new System.Drawing.Size(146, 40);
            this.COMPortToolStripComboBox.Text = global::PHTManager.Properties.Settings.Default.LastCOMPortSetting;
            this.COMPortToolStripComboBox.TextChanged += new System.EventHandler(this.COMPortToolStripComboBox_TextChanged);
            // 
            // PHTMSaveDataFileDialog
            // 
            this.PHTMSaveDataFileDialog.DefaultExt = "csv";
            this.PHTMSaveDataFileDialog.FileName = "PHTMDataForeLeg0000";
            this.PHTMSaveDataFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            // 
            // TestControlPanel
            // 
            this.TestControlPanel.Controls.Add(this.pulseLS3OFFButton);
            this.TestControlPanel.Controls.Add(this.pulseLS3ONButton);
            this.TestControlPanel.Controls.Add(this.pulseLS1ONButton);
            this.TestControlPanel.Controls.Add(this.pulseLS2OFFButton);
            this.TestControlPanel.Controls.Add(this.pulseLS1OFFButton);
            this.TestControlPanel.Controls.Add(this.pulseLS2ONButton);
            this.TestControlPanel.Enabled = false;
            this.TestControlPanel.Location = new System.Drawing.Point(1192, 133);
            this.TestControlPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TestControlPanel.Name = "TestControlPanel";
            this.TestControlPanel.Size = new System.Drawing.Size(470, 75);
            this.TestControlPanel.TabIndex = 64;
            // 
            // pulseLS3OFFButton
            // 
            this.pulseLS3OFFButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pulseLS3OFFButton.Location = new System.Drawing.Point(296, 36);
            this.pulseLS3OFFButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pulseLS3OFFButton.Name = "pulseLS3OFFButton";
            this.pulseLS3OFFButton.Size = new System.Drawing.Size(138, 28);
            this.pulseLS3OFFButton.TabIndex = 69;
            this.pulseLS3OFFButton.Text = "Pulse LS3 OFF";
            this.pulseLS3OFFButton.UseVisualStyleBackColor = true;
            this.pulseLS3OFFButton.Click += new System.EventHandler(this.pulseLS3OFFButton_Click);
            // 
            // pulseLS3ONButton
            // 
            this.pulseLS3ONButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pulseLS3ONButton.Location = new System.Drawing.Point(296, 0);
            this.pulseLS3ONButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pulseLS3ONButton.Name = "pulseLS3ONButton";
            this.pulseLS3ONButton.Size = new System.Drawing.Size(138, 28);
            this.pulseLS3ONButton.TabIndex = 68;
            this.pulseLS3ONButton.Text = "Pulse LS3 ON";
            this.pulseLS3ONButton.UseVisualStyleBackColor = true;
            this.pulseLS3ONButton.Click += new System.EventHandler(this.pulseLS3ONButton_Click);
            // 
            // pulseLS1ONButton
            // 
            this.pulseLS1ONButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pulseLS1ONButton.Location = new System.Drawing.Point(2, 0);
            this.pulseLS1ONButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pulseLS1ONButton.Name = "pulseLS1ONButton";
            this.pulseLS1ONButton.Size = new System.Drawing.Size(138, 28);
            this.pulseLS1ONButton.TabIndex = 64;
            this.pulseLS1ONButton.Text = "Pulse LS1 ON";
            this.pulseLS1ONButton.UseVisualStyleBackColor = true;
            this.pulseLS1ONButton.Click += new System.EventHandler(this.pulseLS1ONButton_Click);
            // 
            // pulseLS2OFFButton
            // 
            this.pulseLS2OFFButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pulseLS2OFFButton.Location = new System.Drawing.Point(150, 36);
            this.pulseLS2OFFButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pulseLS2OFFButton.Name = "pulseLS2OFFButton";
            this.pulseLS2OFFButton.Size = new System.Drawing.Size(138, 28);
            this.pulseLS2OFFButton.TabIndex = 67;
            this.pulseLS2OFFButton.Text = "Pulse LS2 OFF";
            this.pulseLS2OFFButton.UseVisualStyleBackColor = true;
            this.pulseLS2OFFButton.Click += new System.EventHandler(this.pulseLS2OFFButton_Click);
            // 
            // pulseLS1OFFButton
            // 
            this.pulseLS1OFFButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pulseLS1OFFButton.Location = new System.Drawing.Point(2, 36);
            this.pulseLS1OFFButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pulseLS1OFFButton.Name = "pulseLS1OFFButton";
            this.pulseLS1OFFButton.Size = new System.Drawing.Size(138, 28);
            this.pulseLS1OFFButton.TabIndex = 65;
            this.pulseLS1OFFButton.Text = "Pulse LS1 OFF";
            this.pulseLS1OFFButton.UseVisualStyleBackColor = true;
            this.pulseLS1OFFButton.Click += new System.EventHandler(this.pulseLS1OFFButton_Click);
            // 
            // pulseLS2ONButton
            // 
            this.pulseLS2ONButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pulseLS2ONButton.Location = new System.Drawing.Point(150, 0);
            this.pulseLS2ONButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pulseLS2ONButton.Name = "pulseLS2ONButton";
            this.pulseLS2ONButton.Size = new System.Drawing.Size(138, 28);
            this.pulseLS2ONButton.TabIndex = 66;
            this.pulseLS2ONButton.Text = "Pulse LS2 ON";
            this.pulseLS2ONButton.UseVisualStyleBackColor = true;
            this.pulseLS2ONButton.Click += new System.EventHandler(this.pulseLS2ONButton_Click);
            // 
            // rawTargetPressureLabel
            // 
            this.rawTargetPressureLabel.Location = new System.Drawing.Point(1187, 20);
            this.rawTargetPressureLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.rawTargetPressureLabel.Name = "rawTargetPressureLabel";
            this.rawTargetPressureLabel.Size = new System.Drawing.Size(282, 25);
            this.rawTargetPressureLabel.TabIndex = 66;
            this.rawTargetPressureLabel.Text = "Target cuff pressure: ADC:";
            // 
            // rawTargetPressureDisplayLabel
            // 
            this.rawTargetPressureDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rawTargetPressureDisplayLabel.Location = new System.Drawing.Point(1445, 19);
            this.rawTargetPressureDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.rawTargetPressureDisplayLabel.Name = "rawTargetPressureDisplayLabel";
            this.rawTargetPressureDisplayLabel.Size = new System.Drawing.Size(84, 25);
            this.rawTargetPressureDisplayLabel.TabIndex = 65;
            this.rawTargetPressureDisplayLabel.Text = "512";
            this.rawTargetPressureDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pumpPIDNumericUpDown
            // 
            this.pumpPIDNumericUpDown.Location = new System.Drawing.Point(1557, 84);
            this.pumpPIDNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pumpPIDNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.pumpPIDNumericUpDown.Name = "pumpPIDNumericUpDown";
            this.pumpPIDNumericUpDown.Size = new System.Drawing.Size(90, 31);
            this.pumpPIDNumericUpDown.TabIndex = 67;
            this.pumpPIDNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pumpPIDNumericUpDown.Value = new decimal(new int[] {
            192,
            0,
            0,
            0});
            this.pumpPIDNumericUpDown.ValueChanged += new System.EventHandler(this.pumpPIDNumericUpDown_ValueChanged);
            // 
            // connectButton
            // 
            this.connectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectButton.Location = new System.Drawing.Point(22, 20);
            this.connectButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(226, 53);
            this.connectButton.TabIndex = 68;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // saveDataButton
            // 
            this.saveDataButton.Location = new System.Drawing.Point(258, 20);
            this.saveDataButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveDataButton.Name = "saveDataButton";
            this.saveDataButton.Size = new System.Drawing.Size(262, 53);
            this.saveDataButton.TabIndex = 69;
            this.saveDataButton.Text = "Start Save Segment";
            this.saveDataButton.UseVisualStyleBackColor = true;
            this.saveDataButton.Click += new System.EventHandler(this.saveDataButton_Click);
            // 
            // cuffPressureADCUnitsLabel
            // 
            this.cuffPressureADCUnitsLabel.Location = new System.Drawing.Point(1544, 45);
            this.cuffPressureADCUnitsLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.cuffPressureADCUnitsLabel.Name = "cuffPressureADCUnitsLabel";
            this.cuffPressureADCUnitsLabel.Size = new System.Drawing.Size(96, 25);
            this.cuffPressureADCUnitsLabel.TabIndex = 72;
            this.cuffPressureADCUnitsLabel.Text = "counts";
            // 
            // cuffPressureADCLabel
            // 
            this.cuffPressureADCLabel.Location = new System.Drawing.Point(1187, 46);
            this.cuffPressureADCLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.cuffPressureADCLabel.Name = "cuffPressureADCLabel";
            this.cuffPressureADCLabel.Size = new System.Drawing.Size(238, 25);
            this.cuffPressureADCLabel.TabIndex = 71;
            this.cuffPressureADCLabel.Text = "Cuff pressure ADC:";
            // 
            // cuffPressureADCDisplayLabel
            // 
            this.cuffPressureADCDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuffPressureADCDisplayLabel.Location = new System.Drawing.Point(1456, 45);
            this.cuffPressureADCDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.cuffPressureADCDisplayLabel.Name = "cuffPressureADCDisplayLabel";
            this.cuffPressureADCDisplayLabel.Size = new System.Drawing.Size(74, 25);
            this.cuffPressureADCDisplayLabel.TabIndex = 70;
            this.cuffPressureADCDisplayLabel.Text = "29";
            this.cuffPressureADCDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uploadFirmwareButton
            // 
            this.uploadFirmwareButton.AutoSize = true;
            this.uploadFirmwareButton.Location = new System.Drawing.Point(6, 9);
            this.uploadFirmwareButton.Name = "uploadFirmwareButton";
            this.uploadFirmwareButton.Size = new System.Drawing.Size(290, 35);
            this.uploadFirmwareButton.TabIndex = 73;
            this.uploadFirmwareButton.Text = "Upload Firmware";
            this.uploadFirmwareButton.UseVisualStyleBackColor = true;
            this.uploadFirmwareButton.Click += new System.EventHandler(this.uploadFirmwareButton_Click);
            // 
            // openHexFileDialog
            // 
            this.openHexFileDialog.DefaultExt = "hex";
            this.openHexFileDialog.Filter = "HEX files (*.hex)|*.hex|All files (*.*)|*.";
            this.openHexFileDialog.SupportMultiDottedExtensions = true;
            this.openHexFileDialog.Title = "Open firmware file to upload";
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.GraphTabPage);
            this.MainTabControl.Controls.Add(this.SettingsTabPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainTabControl.Location = new System.Drawing.Point(0, 629);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(1688, 835);
            this.MainTabControl.TabIndex = 74;
            // 
            // GraphTabPage
            // 
            this.GraphTabPage.Controls.Add(this.phmDataZedGraph);
            this.GraphTabPage.Location = new System.Drawing.Point(8, 39);
            this.GraphTabPage.Name = "GraphTabPage";
            this.GraphTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GraphTabPage.Size = new System.Drawing.Size(1672, 788);
            this.GraphTabPage.TabIndex = 0;
            this.GraphTabPage.Text = "Graphs";
            this.GraphTabPage.UseVisualStyleBackColor = true;
            // 
            // phmDataZedGraph
            // 
            this.phmDataZedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.phmDataZedGraph.Location = new System.Drawing.Point(3, 3);
            this.phmDataZedGraph.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.phmDataZedGraph.Name = "phmDataZedGraph";
            this.phmDataZedGraph.ScrollGrace = 0D;
            this.phmDataZedGraph.ScrollMaxX = 0D;
            this.phmDataZedGraph.ScrollMaxY = 0D;
            this.phmDataZedGraph.ScrollMaxY2 = 0D;
            this.phmDataZedGraph.ScrollMinX = 0D;
            this.phmDataZedGraph.ScrollMinY = 0D;
            this.phmDataZedGraph.ScrollMinY2 = 0D;
            this.phmDataZedGraph.Size = new System.Drawing.Size(1666, 782);
            this.phmDataZedGraph.TabIndex = 55;
            // 
            // SettingsTabPage
            // 
            this.SettingsTabPage.Controls.Add(this.systemPanel);
            this.SettingsTabPage.Controls.Add(this.rawTargetPressureLabel);
            this.SettingsTabPage.Controls.Add(this.uploadFirmwareButton);
            this.SettingsTabPage.Controls.Add(this.showPumpPIDOnGraphCheckBox);
            this.SettingsTabPage.Controls.Add(this.cuffPressureADCUnitsLabel);
            this.SettingsTabPage.Controls.Add(this.rawTargetPressureDisplayLabel);
            this.SettingsTabPage.Controls.Add(this.TestControlPanel);
            this.SettingsTabPage.Controls.Add(this.cuffDeflationRateUnitsLabel);
            this.SettingsTabPage.Controls.Add(this.pulsePeriodUnitsLabel);
            this.SettingsTabPage.Controls.Add(this.cuffDeflationRateLabel);
            this.SettingsTabPage.Controls.Add(this.cuffPressureADCLabel);
            this.SettingsTabPage.Controls.Add(this.cuffDeflationRateDisplayLabel);
            this.SettingsTabPage.Controls.Add(this.pulsePeriodLabel);
            this.SettingsTabPage.Controls.Add(this.cuffInflationRateUnitsLabel);
            this.SettingsTabPage.Controls.Add(this.pumpPIDNumericUpDown);
            this.SettingsTabPage.Controls.Add(this.cuffInflationRateLabel);
            this.SettingsTabPage.Controls.Add(this.cuffInflationRateDisplayLabel);
            this.SettingsTabPage.Controls.Add(this.pulsePeriodDisplayLabel);
            this.SettingsTabPage.Controls.Add(this.cuffPressureADCDisplayLabel);
            this.SettingsTabPage.Controls.Add(this.ppgSensitivityLabel);
            this.SettingsTabPage.Controls.Add(this.ppgSensitivityDisplayLabel);
            this.SettingsTabPage.Controls.Add(this.ppgSensitivityUnitsLabel);
            this.SettingsTabPage.Location = new System.Drawing.Point(8, 39);
            this.SettingsTabPage.Name = "SettingsTabPage";
            this.SettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTabPage.Size = new System.Drawing.Size(1672, 788);
            this.SettingsTabPage.TabIndex = 1;
            this.SettingsTabPage.Text = "Settings";
            this.SettingsTabPage.UseVisualStyleBackColor = true;
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
            this.systemPanel.Controls.Add(this.phmspDataBitsDisplayLabel);
            this.systemPanel.Controls.Add(this.phmspParityDisplayLabel);
            this.systemPanel.Controls.Add(this.phmspBaudRateDisplayLabel);
            this.systemPanel.Controls.Add(this.phmspPortDisplayLabel);
            this.systemPanel.Controls.Add(this.phmspLabel);
            this.systemPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.systemPanel.Location = new System.Drawing.Point(3, 632);
            this.systemPanel.Margin = new System.Windows.Forms.Padding(6);
            this.systemPanel.Name = "systemPanel";
            this.systemPanel.Size = new System.Drawing.Size(1666, 153);
            this.systemPanel.TabIndex = 74;
            // 
            // testModeCheckBox
            // 
            this.testModeCheckBox.AutoSize = true;
            this.testModeCheckBox.Location = new System.Drawing.Point(1222, 17);
            this.testModeCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.testModeCheckBox.Name = "testModeCheckBox";
            this.testModeCheckBox.Size = new System.Drawing.Size(145, 29);
            this.testModeCheckBox.TabIndex = 46;
            this.testModeCheckBox.Text = "Test mode";
            this.testModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // phmspStopBitsDisplayLabel
            // 
            this.phmspStopBitsDisplayLabel.Location = new System.Drawing.Point(672, 16);
            this.phmspStopBitsDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.phmspStopBitsDisplayLabel.Name = "phmspStopBitsDisplayLabel";
            this.phmspStopBitsDisplayLabel.Size = new System.Drawing.Size(74, 25);
            this.phmspStopBitsDisplayLabel.TabIndex = 45;
            this.phmspStopBitsDisplayLabel.Text = "One";
            this.phmspStopBitsDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // commErrorDisplayLabel
            // 
            this.commErrorDisplayLabel.Location = new System.Drawing.Point(758, 17);
            this.commErrorDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.commErrorDisplayLabel.Name = "commErrorDisplayLabel";
            this.commErrorDisplayLabel.Size = new System.Drawing.Size(308, 25);
            this.commErrorDisplayLabel.TabIndex = 44;
            this.commErrorDisplayLabel.Text = "Not connected";
            // 
            // showAllBufferUpdatesCheckBox
            // 
            this.showAllBufferUpdatesCheckBox.AutoSize = true;
            this.showAllBufferUpdatesCheckBox.Location = new System.Drawing.Point(1390, 16);
            this.showAllBufferUpdatesCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.showAllBufferUpdatesCheckBox.Name = "showAllBufferUpdatesCheckBox";
            this.showAllBufferUpdatesCheckBox.Size = new System.Drawing.Size(269, 29);
            this.showAllBufferUpdatesCheckBox.TabIndex = 43;
            this.showAllBufferUpdatesCheckBox.Text = "Show all buffer updates";
            this.showAllBufferUpdatesCheckBox.UseVisualStyleBackColor = true;
            // 
            // bytePositionLabel
            // 
            this.bytePositionLabel.AutoSize = true;
            this.bytePositionLabel.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bytePositionLabel.Location = new System.Drawing.Point(18, 48);
            this.bytePositionLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.bytePositionLabel.Name = "bytePositionLabel";
            this.bytePositionLabel.Size = new System.Drawing.Size(1613, 29);
            this.bytePositionLabel.TabIndex = 42;
            this.bytePositionLabel.Text = "POS: 00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F 10 11 12 13 14 15 16 17 18 1" +
    "9 1A 1B 1C 1D 1E 1F";
            // 
            // inBufferDisplayLabel
            // 
            this.inBufferDisplayLabel.AutoSize = true;
            this.inBufferDisplayLabel.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inBufferDisplayLabel.Location = new System.Drawing.Point(18, 103);
            this.inBufferDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.inBufferDisplayLabel.Name = "inBufferDisplayLabel";
            this.inBufferDisplayLabel.Size = new System.Drawing.Size(77, 30);
            this.inBufferDisplayLabel.TabIndex = 41;
            this.inBufferDisplayLabel.Text = "IN: ";
            // 
            // outBufferDisplayLabel
            // 
            this.outBufferDisplayLabel.AutoSize = true;
            this.outBufferDisplayLabel.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outBufferDisplayLabel.Location = new System.Drawing.Point(18, 78);
            this.outBufferDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.outBufferDisplayLabel.Name = "outBufferDisplayLabel";
            this.outBufferDisplayLabel.Size = new System.Drawing.Size(93, 29);
            this.outBufferDisplayLabel.TabIndex = 40;
            this.outBufferDisplayLabel.Text = "OUT: ";
            // 
            // phmspDataBitsDisplayLabel
            // 
            this.phmspDataBitsDisplayLabel.Location = new System.Drawing.Point(518, 17);
            this.phmspDataBitsDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.phmspDataBitsDisplayLabel.Name = "phmspDataBitsDisplayLabel";
            this.phmspDataBitsDisplayLabel.Size = new System.Drawing.Size(52, 25);
            this.phmspDataBitsDisplayLabel.TabIndex = 37;
            this.phmspDataBitsDisplayLabel.Text = "8";
            this.phmspDataBitsDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // phmspParityDisplayLabel
            // 
            this.phmspParityDisplayLabel.Location = new System.Drawing.Point(582, 17);
            this.phmspParityDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.phmspParityDisplayLabel.Name = "phmspParityDisplayLabel";
            this.phmspParityDisplayLabel.Size = new System.Drawing.Size(78, 25);
            this.phmspParityDisplayLabel.TabIndex = 36;
            this.phmspParityDisplayLabel.Text = "None";
            this.phmspParityDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // phmspBaudRateDisplayLabel
            // 
            this.phmspBaudRateDisplayLabel.Location = new System.Drawing.Point(410, 17);
            this.phmspBaudRateDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.phmspBaudRateDisplayLabel.Name = "phmspBaudRateDisplayLabel";
            this.phmspBaudRateDisplayLabel.Size = new System.Drawing.Size(96, 25);
            this.phmspBaudRateDisplayLabel.TabIndex = 35;
            this.phmspBaudRateDisplayLabel.Text = "115200";
            this.phmspBaudRateDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // phmspPortDisplayLabel
            // 
            this.phmspPortDisplayLabel.Location = new System.Drawing.Point(302, 17);
            this.phmspPortDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.phmspPortDisplayLabel.Name = "phmspPortDisplayLabel";
            this.phmspPortDisplayLabel.Size = new System.Drawing.Size(96, 25);
            this.phmspPortDisplayLabel.TabIndex = 34;
            this.phmspPortDisplayLabel.Text = "COM1";
            this.phmspPortDisplayLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // phmspLabel
            // 
            this.phmspLabel.AutoSize = true;
            this.phmspLabel.Location = new System.Drawing.Point(18, 17);
            this.phmspLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.phmspLabel.Name = "phmspLabel";
            this.phmspLabel.Size = new System.Drawing.Size(278, 25);
            this.phmspLabel.TabIndex = 33;
            this.phmspLabel.Text = "PHM Main Controller Serial:";
            // 
            // bleedRatePanel
            // 
            this.bleedRatePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bleedRatePanel.Controls.Add(this.bleedRateDecreaseButton);
            this.bleedRatePanel.Controls.Add(this.bleedRateIncreaseButton);
            this.bleedRatePanel.Controls.Add(this.bleedRateLebel);
            this.bleedRatePanel.Controls.Add(this.bleedRateDisplayLabel);
            this.bleedRatePanel.Location = new System.Drawing.Point(1202, 227);
            this.bleedRatePanel.Margin = new System.Windows.Forms.Padding(6);
            this.bleedRatePanel.Name = "bleedRatePanel";
            this.bleedRatePanel.Size = new System.Drawing.Size(452, 192);
            this.bleedRatePanel.TabIndex = 75;
            // 
            // bleedRateDecreaseButton
            // 
            this.bleedRateDecreaseButton.Image = global::PHTManager.Properties.Resources.down;
            this.bleedRateDecreaseButton.Location = new System.Drawing.Point(0, 125);
            this.bleedRateDecreaseButton.Margin = new System.Windows.Forms.Padding(6);
            this.bleedRateDecreaseButton.Name = "bleedRateDecreaseButton";
            this.bleedRateDecreaseButton.Size = new System.Drawing.Size(84, 67);
            this.bleedRateDecreaseButton.TabIndex = 3;
            this.bleedRateDecreaseButton.UseVisualStyleBackColor = true;
            // 
            // bleedRateIncreaseButton
            // 
            this.bleedRateIncreaseButton.Image = global::PHTManager.Properties.Resources.up;
            this.bleedRateIncreaseButton.Location = new System.Drawing.Point(0, 61);
            this.bleedRateIncreaseButton.Margin = new System.Windows.Forms.Padding(6);
            this.bleedRateIncreaseButton.Name = "bleedRateIncreaseButton";
            this.bleedRateIncreaseButton.Size = new System.Drawing.Size(84, 67);
            this.bleedRateIncreaseButton.TabIndex = 2;
            this.bleedRateIncreaseButton.UseVisualStyleBackColor = true;
            // 
            // bleedRateLebel
            // 
            this.bleedRateLebel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bleedRateLebel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bleedRateLebel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bleedRateLebel.Location = new System.Drawing.Point(0, 0);
            this.bleedRateLebel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.bleedRateLebel.Name = "bleedRateLebel";
            this.bleedRateLebel.Size = new System.Drawing.Size(452, 61);
            this.bleedRateLebel.TabIndex = 1;
            this.bleedRateLebel.Text = "Bleed Rate (mmHg/min)";
            this.bleedRateLebel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bleedRateDisplayLabel
            // 
            this.bleedRateDisplayLabel.BackColor = System.Drawing.Color.Black;
            this.bleedRateDisplayLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bleedRateDisplayLabel.Font = new System.Drawing.Font("Courier New", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bleedRateDisplayLabel.ForeColor = System.Drawing.Color.Lime;
            this.bleedRateDisplayLabel.Location = new System.Drawing.Point(80, 61);
            this.bleedRateDisplayLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.bleedRateDisplayLabel.Name = "bleedRateDisplayLabel";
            this.bleedRateDisplayLabel.Size = new System.Drawing.Size(372, 131);
            this.bleedRateDisplayLabel.TabIndex = 0;
            this.bleedRateDisplayLabel.Text = "30";
            this.bleedRateDisplayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PHTManagerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1688, 1464);
            this.Controls.Add(this.bleedRatePanel);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.saveDataButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.PHTMMainToolStrip);
            this.Controls.Add(this.targetPressurePanel);
            this.Controls.Add(this.reperfuseButton);
            this.Controls.Add(this.maintainCuffPressureButton);
            this.Controls.Add(this.findSystolicPressureButton);
            this.Controls.Add(this.pulseRatePanel);
            this.Controls.Add(this.bleedCuffPressureButton);
            this.Controls.Add(this.fillCuffButton);
            this.Controls.Add(this.systolicPressurePanel);
            this.Controls.Add(this.cuffPressureDisplayPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "PHTManagerMain";
            this.Text = "Permissive Hypotension Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PHTManagerMain_FormClosing);
            this.Load += new System.EventHandler(this.PHTManagerMain_Load);
            this.Resize += new System.EventHandler(this.PHTManagerMain_Resize);
            this.cuffPressureDisplayPanel.ResumeLayout(false);
            this.systolicPressurePanel.ResumeLayout(false);
            this.pulseRatePanel.ResumeLayout(false);
            this.pulseRatePanel.PerformLayout();
            this.targetPressurePanel.ResumeLayout(false);
            this.PHTMMainToolStrip.ResumeLayout(false);
            this.PHTMMainToolStrip.PerformLayout();
            this.TestControlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pumpPIDNumericUpDown)).EndInit();
            this.MainTabControl.ResumeLayout(false);
            this.GraphTabPage.ResumeLayout(false);
            this.SettingsTabPage.ResumeLayout(false);
            this.SettingsTabPage.PerformLayout();
            this.systemPanel.ResumeLayout(false);
            this.systemPanel.PerformLayout();
            this.bleedRatePanel.ResumeLayout(false);
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
        private System.Windows.Forms.Button bleedCuffPressureButton;
        private System.Windows.Forms.Panel pulseRatePanel;
        private System.Windows.Forms.Label pulseRateLebel;
        private System.Windows.Forms.Label pulseRateDisplayLabel;
        private System.Windows.Forms.Button findSystolicPressureButton;
        private System.Windows.Forms.Button maintainCuffPressureButton;
        private System.Windows.Forms.Button reperfuseButton;
        private System.Windows.Forms.Panel targetPressurePanel;
        private System.Windows.Forms.Button targetPressureIncreaseButton;
        private System.Windows.Forms.Label targetPressureLabel;
        private System.Windows.Forms.Label targetPressureDisplayLabel;
        private System.Windows.Forms.Button targetPressureDecreaseButton;
        private System.Windows.Forms.Label ppgSensitivityDisplayLabel;
        private System.Windows.Forms.Label ppgSensitivityLabel;
        private System.Windows.Forms.Label ppgSensitivityUnitsLabel;
        private System.Windows.Forms.Label cuffInflationRateUnitsLabel;
        private System.Windows.Forms.Label cuffInflationRateLabel;
        private System.Windows.Forms.Label cuffInflationRateDisplayLabel;
        private System.Windows.Forms.Label cuffDeflationRateUnitsLabel;
        private System.Windows.Forms.Label cuffDeflationRateLabel;
        private System.Windows.Forms.Label cuffDeflationRateDisplayLabel;
        private System.IO.Ports.SerialPort PHMSerialPort;
        private System.Windows.Forms.Timer PHMMainTimer;
        private System.Windows.Forms.CheckBox showPumpPIDOnGraphCheckBox;
        private System.Windows.Forms.Label pulsePeriodUnitsLabel;
        private System.Windows.Forms.Label pulsePeriodLabel;
        private System.Windows.Forms.Label pulsePeriodDisplayLabel;
        private System.Windows.Forms.ToolStrip PHTMMainToolStrip;
        private System.Windows.Forms.ToolStripComboBox COMPortToolStripComboBox;
        private System.Windows.Forms.SaveFileDialog PHTMSaveDataFileDialog;
        private System.Windows.Forms.Panel TestControlPanel;
        private System.Windows.Forms.Button pulseLS1ONButton;
        private System.Windows.Forms.Button pulseLS2OFFButton;
        private System.Windows.Forms.Button pulseLS1OFFButton;
        private System.Windows.Forms.Button pulseLS2ONButton;
        private System.Windows.Forms.Label rawTargetPressureLabel;
        private System.Windows.Forms.Label rawTargetPressureDisplayLabel;
        private System.Windows.Forms.NumericUpDown pumpPIDNumericUpDown;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button saveDataButton;
        private System.Windows.Forms.CheckBox calculatePulseRateCheckBox;
        private System.Windows.Forms.Button pulseLS3OFFButton;
        private System.Windows.Forms.Button pulseLS3ONButton;
        private System.Windows.Forms.Label cuffPressureADCUnitsLabel;
        private System.Windows.Forms.Label cuffPressureADCLabel;
        private System.Windows.Forms.Label cuffPressureADCDisplayLabel;
        private System.Windows.Forms.Button uploadFirmwareButton;
        private System.Windows.Forms.OpenFileDialog openHexFileDialog;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage GraphTabPage;
        private ZedGraph.ZedGraphControl phmDataZedGraph;
        private System.Windows.Forms.TabPage SettingsTabPage;
        private System.Windows.Forms.Panel systemPanel;
        private System.Windows.Forms.CheckBox testModeCheckBox;
        private System.Windows.Forms.Label phmspStopBitsDisplayLabel;
        private System.Windows.Forms.Label commErrorDisplayLabel;
        private System.Windows.Forms.CheckBox showAllBufferUpdatesCheckBox;
        private System.Windows.Forms.Label bytePositionLabel;
        private System.Windows.Forms.Label inBufferDisplayLabel;
        private System.Windows.Forms.Label outBufferDisplayLabel;
        private System.Windows.Forms.Label phmspDataBitsDisplayLabel;
        private System.Windows.Forms.Label phmspParityDisplayLabel;
        private System.Windows.Forms.Label phmspBaudRateDisplayLabel;
        private System.Windows.Forms.Label phmspPortDisplayLabel;
        private System.Windows.Forms.Label phmspLabel;
        private System.Windows.Forms.Panel bleedRatePanel;
        private System.Windows.Forms.Button bleedRateDecreaseButton;
        private System.Windows.Forms.Button bleedRateIncreaseButton;
        private System.Windows.Forms.Label bleedRateLebel;
        private System.Windows.Forms.Label bleedRateDisplayLabel;
    }
}

