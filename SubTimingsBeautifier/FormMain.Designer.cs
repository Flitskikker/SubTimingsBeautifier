namespace SubTimingsBeautifier
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelVideo = new System.Windows.Forms.Label();
            this.textBoxVideo = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelThreshold = new System.Windows.Forms.Label();
            this.trackBarThreshold = new System.Windows.Forms.TrackBar();
            this.numericUpDownThreshold = new System.Windows.Forms.NumericUpDown();
            this.buttonAnalyze = new System.Windows.Forms.Button();
            this.progressBarTimeCodes = new System.Windows.Forms.ProgressBar();
            this.progressBarShotCuts = new System.Windows.Forms.ProgressBar();
            this.labelMaxShotCutOffset = new System.Windows.Forms.Label();
            this.checkBoxOnlyGapsBeforeShotCuts = new System.Windows.Forms.CheckBox();
            this.labelGap = new System.Windows.Forms.Label();
            this.numericUpDownGap = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxShotCuts = new System.Windows.Forms.CheckBox();
            this.buttonImportShotCuts = new System.Windows.Forms.Button();
            this.labelDetectMaxGap = new System.Windows.Forms.Label();
            this.numericUpDownDetectMaxGap = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxShotCutOffset = new System.Windows.Forms.NumericUpDown();
            this.buttonGo = new System.Windows.Forms.Button();
            this.labelProgress = new System.Windows.Forms.Label();
            this.buttonExportShotCuts = new System.Windows.Forms.Button();
            this.openFileDialogVideo = new System.Windows.Forms.OpenFileDialog();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.numericUpDownConnectMaxGap = new System.Windows.Forms.NumericUpDown();
            this.labelConnectMaxGap = new System.Windows.Forms.Label();
            this.checkBoxConnectToShotCuts = new System.Windows.Forms.CheckBox();
            this.checkBoxAlignFreeOutCuesToShotCuts = new System.Windows.Forms.CheckBox();
            this.numericUpDownAlignFreeOutCuesToShotCuts = new System.Windows.Forms.NumericUpDown();
            this.checkBoxOvershootShotCuts = new System.Windows.Forms.CheckBox();
            this.numericUpDownOvershootShotCuts = new System.Windows.Forms.NumericUpDown();
            this.checkBoxFreeOutCuesToShotCutsExtendOnly = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownExtend = new System.Windows.Forms.NumericUpDown();
            this.checkBoxExtend = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonClearTimeCodes = new System.Windows.Forms.Button();
            this.buttonClearShotCuts = new System.Windows.Forms.Button();
            this.checkBoxAlignFreeInCuesToShotCuts = new System.Windows.Forms.CheckBox();
            this.numericUpDownAlignFreeInCuesToShotCuts = new System.Windows.Forms.NumericUpDown();
            this.checkBoxFreeInCuesToShotCutsExtendOnly = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxMakeBackup = new System.Windows.Forms.CheckBox();
            this.labelThresholdLow = new System.Windows.Forms.Label();
            this.labelThresholdHigh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDetectMaxGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxShotCutOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConnectMaxGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlignFreeOutCuesToShotCuts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOvershootShotCuts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExtend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlignFreeInCuesToShotCuts)).BeginInit();
            this.SuspendLayout();
            // 
            // labelVideo
            // 
            this.labelVideo.AutoSize = true;
            this.labelVideo.Location = new System.Drawing.Point(9, 15);
            this.labelVideo.Name = "labelVideo";
            this.labelVideo.Size = new System.Drawing.Size(40, 15);
            this.labelVideo.TabIndex = 0;
            this.labelVideo.Text = "Video:";
            // 
            // textBoxVideo
            // 
            this.textBoxVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxVideo.Location = new System.Drawing.Point(55, 12);
            this.textBoxVideo.Name = "textBoxVideo";
            this.textBoxVideo.Size = new System.Drawing.Size(364, 23);
            this.textBoxVideo.TabIndex = 1;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowse.Location = new System.Drawing.Point(425, 12);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "Browse...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // labelThreshold
            // 
            this.labelThreshold.AutoSize = true;
            this.labelThreshold.Enabled = false;
            this.labelThreshold.Location = new System.Drawing.Point(9, 82);
            this.labelThreshold.Name = "labelThreshold";
            this.labelThreshold.Size = new System.Drawing.Size(63, 15);
            this.labelThreshold.TabIndex = 3;
            this.labelThreshold.Text = "Threshold:";
            // 
            // trackBarThreshold
            // 
            this.trackBarThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarThreshold.Enabled = false;
            this.trackBarThreshold.Location = new System.Drawing.Point(79, 70);
            this.trackBarThreshold.Maximum = 100;
            this.trackBarThreshold.Name = "trackBarThreshold";
            this.trackBarThreshold.Size = new System.Drawing.Size(340, 45);
            this.trackBarThreshold.TabIndex = 4;
            this.trackBarThreshold.TickFrequency = 10;
            this.trackBarThreshold.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarThreshold.Value = 10;
            this.trackBarThreshold.Scroll += new System.EventHandler(this.trackBarThreshold_Scroll);
            // 
            // numericUpDownThreshold
            // 
            this.numericUpDownThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownThreshold.DecimalPlaces = 2;
            this.numericUpDownThreshold.Enabled = false;
            this.numericUpDownThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownThreshold.Location = new System.Drawing.Point(425, 80);
            this.numericUpDownThreshold.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownThreshold.Name = "numericUpDownThreshold";
            this.numericUpDownThreshold.Size = new System.Drawing.Size(75, 23);
            this.numericUpDownThreshold.TabIndex = 5;
            this.numericUpDownThreshold.Value = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            this.numericUpDownThreshold.ValueChanged += new System.EventHandler(this.numericUpDownThreshold_ValueChanged);
            // 
            // buttonAnalyze
            // 
            this.buttonAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAnalyze.Enabled = false;
            this.buttonAnalyze.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnalyze.Location = new System.Drawing.Point(12, 135);
            this.buttonAnalyze.Name = "buttonAnalyze";
            this.buttonAnalyze.Size = new System.Drawing.Size(488, 51);
            this.buttonAnalyze.TabIndex = 6;
            this.buttonAnalyze.Text = "Analyze video";
            this.buttonAnalyze.UseVisualStyleBackColor = true;
            this.buttonAnalyze.Click += new System.EventHandler(this.buttonAnalyze_Click);
            // 
            // progressBarTimeCodes
            // 
            this.progressBarTimeCodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarTimeCodes.Location = new System.Drawing.Point(12, 192);
            this.progressBarTimeCodes.Name = "progressBarTimeCodes";
            this.progressBarTimeCodes.Size = new System.Drawing.Size(459, 23);
            this.progressBarTimeCodes.TabIndex = 7;
            // 
            // progressBarShotCuts
            // 
            this.progressBarShotCuts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarShotCuts.Location = new System.Drawing.Point(12, 221);
            this.progressBarShotCuts.Name = "progressBarShotCuts";
            this.progressBarShotCuts.Size = new System.Drawing.Size(459, 23);
            this.progressBarShotCuts.TabIndex = 8;
            // 
            // labelMaxShotCutOffset
            // 
            this.labelMaxShotCutOffset.AutoSize = true;
            this.labelMaxShotCutOffset.Location = new System.Drawing.Point(9, 290);
            this.labelMaxShotCutOffset.Name = "labelMaxShotCutOffset";
            this.labelMaxShotCutOffset.Size = new System.Drawing.Size(161, 15);
            this.labelMaxShotCutOffset.TabIndex = 9;
            this.labelMaxShotCutOffset.Text = "Max. shot cut offset (frames):";
            // 
            // checkBoxOnlyGapsBeforeShotCuts
            // 
            this.checkBoxOnlyGapsBeforeShotCuts.AutoSize = true;
            this.checkBoxOnlyGapsBeforeShotCuts.Location = new System.Drawing.Point(277, 290);
            this.checkBoxOnlyGapsBeforeShotCuts.Name = "checkBoxOnlyGapsBeforeShotCuts";
            this.checkBoxOnlyGapsBeforeShotCuts.Size = new System.Drawing.Size(198, 19);
            this.checkBoxOnlyGapsBeforeShotCuts.TabIndex = 11;
            this.checkBoxOnlyGapsBeforeShotCuts.Text = "Only allow gaps before shot cuts";
            this.checkBoxOnlyGapsBeforeShotCuts.UseVisualStyleBackColor = true;
            // 
            // labelGap
            // 
            this.labelGap.AutoSize = true;
            this.labelGap.Location = new System.Drawing.Point(9, 413);
            this.labelGap.Name = "labelGap";
            this.labelGap.Size = new System.Drawing.Size(78, 15);
            this.labelGap.TabIndex = 12;
            this.labelGap.Text = "Gap (frames):";
            // 
            // numericUpDownGap
            // 
            this.numericUpDownGap.Location = new System.Drawing.Point(149, 410);
            this.numericUpDownGap.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownGap.Name = "numericUpDownGap";
            this.numericUpDownGap.Size = new System.Drawing.Size(75, 23);
            this.numericUpDownGap.TabIndex = 13;
            this.numericUpDownGap.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(12, 279);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 2);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // checkBoxShotCuts
            // 
            this.checkBoxShotCuts.AutoSize = true;
            this.checkBoxShotCuts.Checked = true;
            this.checkBoxShotCuts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShotCuts.Enabled = false;
            this.checkBoxShotCuts.Location = new System.Drawing.Point(12, 50);
            this.checkBoxShotCuts.Name = "checkBoxShotCuts";
            this.checkBoxShotCuts.Size = new System.Drawing.Size(128, 19);
            this.checkBoxShotCuts.TabIndex = 15;
            this.checkBoxShotCuts.Text = "Detect shot cuts, or";
            this.checkBoxShotCuts.UseVisualStyleBackColor = true;
            this.checkBoxShotCuts.CheckedChanged += new System.EventHandler(this.checkBoxShotCuts_CheckedChanged);
            // 
            // buttonImportShotCuts
            // 
            this.buttonImportShotCuts.Enabled = false;
            this.buttonImportShotCuts.Location = new System.Drawing.Point(146, 47);
            this.buttonImportShotCuts.Name = "buttonImportShotCuts";
            this.buttonImportShotCuts.Size = new System.Drawing.Size(75, 23);
            this.buttonImportShotCuts.TabIndex = 16;
            this.buttonImportShotCuts.Text = "Import...";
            this.buttonImportShotCuts.UseVisualStyleBackColor = true;
            this.buttonImportShotCuts.Click += new System.EventHandler(this.buttonImportShotCuts_Click);
            // 
            // labelDetectMaxGap
            // 
            this.labelDetectMaxGap.AutoSize = true;
            this.labelDetectMaxGap.Location = new System.Drawing.Point(9, 442);
            this.labelDetectMaxGap.Name = "labelDetectMaxGap";
            this.labelDetectMaxGap.Size = new System.Drawing.Size(122, 15);
            this.labelDetectMaxGap.TabIndex = 17;
            this.labelDetectMaxGap.Text = "Detect max. gap (ms):";
            // 
            // numericUpDownDetectMaxGap
            // 
            this.numericUpDownDetectMaxGap.Location = new System.Drawing.Point(149, 439);
            this.numericUpDownDetectMaxGap.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownDetectMaxGap.Name = "numericUpDownDetectMaxGap";
            this.numericUpDownDetectMaxGap.Size = new System.Drawing.Size(75, 23);
            this.numericUpDownDetectMaxGap.TabIndex = 18;
            this.numericUpDownDetectMaxGap.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            // 
            // numericUpDownMaxShotCutOffset
            // 
            this.numericUpDownMaxShotCutOffset.Location = new System.Drawing.Point(177, 287);
            this.numericUpDownMaxShotCutOffset.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownMaxShotCutOffset.Name = "numericUpDownMaxShotCutOffset";
            this.numericUpDownMaxShotCutOffset.Size = new System.Drawing.Size(75, 23);
            this.numericUpDownMaxShotCutOffset.TabIndex = 19;
            this.numericUpDownMaxShotCutOffset.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // buttonGo
            // 
            this.buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGo.Enabled = false;
            this.buttonGo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGo.Location = new System.Drawing.Point(11, 535);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(488, 51);
            this.buttonGo.TabIndex = 22;
            this.buttonGo.Text = "Process SRT...";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelProgress.Location = new System.Drawing.Point(9, 254);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(42, 15);
            this.labelProgress.TabIndex = 23;
            this.labelProgress.Text = "Ready.";
            // 
            // buttonExportShotCuts
            // 
            this.buttonExportShotCuts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExportShotCuts.Enabled = false;
            this.buttonExportShotCuts.Location = new System.Drawing.Point(330, 250);
            this.buttonExportShotCuts.Name = "buttonExportShotCuts";
            this.buttonExportShotCuts.Size = new System.Drawing.Size(170, 23);
            this.buttonExportShotCuts.TabIndex = 24;
            this.buttonExportShotCuts.Text = "Copy shot cuts to clipboard";
            this.buttonExportShotCuts.UseVisualStyleBackColor = true;
            this.buttonExportShotCuts.Click += new System.EventHandler(this.buttonExportShotCuts_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(12, 135);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(488, 51);
            this.buttonCancel.TabIndex = 25;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "SubRip|*.srt";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "SubRip|*.srt";
            // 
            // numericUpDownConnectMaxGap
            // 
            this.numericUpDownConnectMaxGap.Location = new System.Drawing.Point(149, 468);
            this.numericUpDownConnectMaxGap.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDownConnectMaxGap.Name = "numericUpDownConnectMaxGap";
            this.numericUpDownConnectMaxGap.Size = new System.Drawing.Size(75, 23);
            this.numericUpDownConnectMaxGap.TabIndex = 27;
            this.numericUpDownConnectMaxGap.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // labelConnectMaxGap
            // 
            this.labelConnectMaxGap.AutoSize = true;
            this.labelConnectMaxGap.Location = new System.Drawing.Point(9, 471);
            this.labelConnectMaxGap.Name = "labelConnectMaxGap";
            this.labelConnectMaxGap.Size = new System.Drawing.Size(133, 15);
            this.labelConnectMaxGap.TabIndex = 26;
            this.labelConnectMaxGap.Text = "Connect max. gap (ms):";
            // 
            // checkBoxConnectToShotCuts
            // 
            this.checkBoxConnectToShotCuts.AutoSize = true;
            this.checkBoxConnectToShotCuts.Checked = true;
            this.checkBoxConnectToShotCuts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxConnectToShotCuts.Location = new System.Drawing.Point(250, 471);
            this.checkBoxConnectToShotCuts.Name = "checkBoxConnectToShotCuts";
            this.checkBoxConnectToShotCuts.Size = new System.Drawing.Size(164, 19);
            this.checkBoxConnectToShotCuts.TabIndex = 28;
            this.checkBoxConnectToShotCuts.Text = "Also connect TO shot cuts";
            this.checkBoxConnectToShotCuts.UseVisualStyleBackColor = true;
            // 
            // checkBoxAlignFreeOutCuesToShotCuts
            // 
            this.checkBoxAlignFreeOutCuesToShotCuts.AutoSize = true;
            this.checkBoxAlignFreeOutCuesToShotCuts.Checked = true;
            this.checkBoxAlignFreeOutCuesToShotCuts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAlignFreeOutCuesToShotCuts.Location = new System.Drawing.Point(13, 346);
            this.checkBoxAlignFreeOutCuesToShotCuts.Name = "checkBoxAlignFreeOutCuesToShotCuts";
            this.checkBoxAlignFreeOutCuesToShotCuts.Size = new System.Drawing.Size(294, 19);
            this.checkBoxAlignFreeOutCuesToShotCuts.TabIndex = 29;
            this.checkBoxAlignFreeOutCuesToShotCuts.Text = "Snap \"free\" out cues to shot cuts if within (frames):";
            this.checkBoxAlignFreeOutCuesToShotCuts.UseVisualStyleBackColor = true;
            this.checkBoxAlignFreeOutCuesToShotCuts.CheckedChanged += new System.EventHandler(this.checkBoxAlignFreeOutCuesToShotCuts_CheckedChanged);
            // 
            // numericUpDownAlignFreeOutCuesToShotCuts
            // 
            this.numericUpDownAlignFreeOutCuesToShotCuts.Location = new System.Drawing.Point(319, 344);
            this.numericUpDownAlignFreeOutCuesToShotCuts.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownAlignFreeOutCuesToShotCuts.Name = "numericUpDownAlignFreeOutCuesToShotCuts";
            this.numericUpDownAlignFreeOutCuesToShotCuts.Size = new System.Drawing.Size(75, 23);
            this.numericUpDownAlignFreeOutCuesToShotCuts.TabIndex = 30;
            this.numericUpDownAlignFreeOutCuesToShotCuts.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // checkBoxOvershootShotCuts
            // 
            this.checkBoxOvershootShotCuts.AutoSize = true;
            this.checkBoxOvershootShotCuts.Checked = true;
            this.checkBoxOvershootShotCuts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOvershootShotCuts.Location = new System.Drawing.Point(13, 375);
            this.checkBoxOvershootShotCuts.Name = "checkBoxOvershootShotCuts";
            this.checkBoxOvershootShotCuts.Size = new System.Drawing.Size(300, 19);
            this.checkBoxOvershootShotCuts.TabIndex = 31;
            this.checkBoxOvershootShotCuts.Text = "For \"free\" out cues, overshoot shot cuts by (frames):";
            this.checkBoxOvershootShotCuts.UseVisualStyleBackColor = true;
            this.checkBoxOvershootShotCuts.CheckedChanged += new System.EventHandler(this.checkBoxOvershootShotCuts_CheckedChanged);
            // 
            // numericUpDownOvershootShotCuts
            // 
            this.numericUpDownOvershootShotCuts.Location = new System.Drawing.Point(319, 373);
            this.numericUpDownOvershootShotCuts.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownOvershootShotCuts.Name = "numericUpDownOvershootShotCuts";
            this.numericUpDownOvershootShotCuts.Size = new System.Drawing.Size(75, 23);
            this.numericUpDownOvershootShotCuts.TabIndex = 32;
            this.numericUpDownOvershootShotCuts.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // checkBoxFreeOutCuesToShotCutsExtendOnly
            // 
            this.checkBoxFreeOutCuesToShotCutsExtendOnly.AutoSize = true;
            this.checkBoxFreeOutCuesToShotCutsExtendOnly.Checked = true;
            this.checkBoxFreeOutCuesToShotCutsExtendOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFreeOutCuesToShotCutsExtendOnly.Location = new System.Drawing.Point(419, 347);
            this.checkBoxFreeOutCuesToShotCutsExtendOnly.Name = "checkBoxFreeOutCuesToShotCutsExtendOnly";
            this.checkBoxFreeOutCuesToShotCutsExtendOnly.Size = new System.Drawing.Size(87, 19);
            this.checkBoxFreeOutCuesToShotCutsExtendOnly.TabIndex = 33;
            this.checkBoxFreeOutCuesToShotCutsExtendOnly.Text = "Extend only";
            this.checkBoxFreeOutCuesToShotCutsExtendOnly.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(12, 402);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(487, 2);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            // 
            // numericUpDownExtend
            // 
            this.numericUpDownExtend.Enabled = false;
            this.numericUpDownExtend.Location = new System.Drawing.Point(284, 506);
            this.numericUpDownExtend.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDownExtend.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownExtend.Name = "numericUpDownExtend";
            this.numericUpDownExtend.Size = new System.Drawing.Size(75, 23);
            this.numericUpDownExtend.TabIndex = 38;
            this.numericUpDownExtend.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // checkBoxExtend
            // 
            this.checkBoxExtend.AutoSize = true;
            this.checkBoxExtend.Location = new System.Drawing.Point(13, 508);
            this.checkBoxExtend.Name = "checkBoxExtend";
            this.checkBoxExtend.Size = new System.Drawing.Size(265, 19);
            this.checkBoxExtend.TabIndex = 37;
            this.checkBoxExtend.Text = "Extend out cues where/until possible by (ms):";
            this.checkBoxExtend.UseVisualStyleBackColor = true;
            this.checkBoxExtend.CheckedChanged += new System.EventHandler(this.checkBoxExtend_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Location = new System.Drawing.Point(12, 498);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(487, 2);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            // 
            // buttonClearTimeCodes
            // 
            this.buttonClearTimeCodes.Enabled = false;
            this.buttonClearTimeCodes.FlatAppearance.BorderSize = 0;
            this.buttonClearTimeCodes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearTimeCodes.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearTimeCodes.Location = new System.Drawing.Point(477, 192);
            this.buttonClearTimeCodes.Name = "buttonClearTimeCodes";
            this.buttonClearTimeCodes.Size = new System.Drawing.Size(23, 23);
            this.buttonClearTimeCodes.TabIndex = 40;
            this.buttonClearTimeCodes.Text = "";
            this.toolTip.SetToolTip(this.buttonClearTimeCodes, "Clear time codes");
            this.buttonClearTimeCodes.UseVisualStyleBackColor = true;
            this.buttonClearTimeCodes.Click += new System.EventHandler(this.buttonClearTimeCodes_Click);
            // 
            // buttonClearShotCuts
            // 
            this.buttonClearShotCuts.Enabled = false;
            this.buttonClearShotCuts.FlatAppearance.BorderSize = 0;
            this.buttonClearShotCuts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearShotCuts.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearShotCuts.Location = new System.Drawing.Point(477, 221);
            this.buttonClearShotCuts.Name = "buttonClearShotCuts";
            this.buttonClearShotCuts.Size = new System.Drawing.Size(23, 23);
            this.buttonClearShotCuts.TabIndex = 41;
            this.buttonClearShotCuts.Text = "";
            this.toolTip.SetToolTip(this.buttonClearShotCuts, "Clear shot cuts");
            this.buttonClearShotCuts.UseVisualStyleBackColor = true;
            this.buttonClearShotCuts.Click += new System.EventHandler(this.buttonClearShotCuts_Click);
            // 
            // checkBoxAlignFreeInCuesToShotCuts
            // 
            this.checkBoxAlignFreeInCuesToShotCuts.AutoSize = true;
            this.checkBoxAlignFreeInCuesToShotCuts.Checked = true;
            this.checkBoxAlignFreeInCuesToShotCuts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAlignFreeInCuesToShotCuts.Location = new System.Drawing.Point(13, 317);
            this.checkBoxAlignFreeInCuesToShotCuts.Name = "checkBoxAlignFreeInCuesToShotCuts";
            this.checkBoxAlignFreeInCuesToShotCuts.Size = new System.Drawing.Size(286, 19);
            this.checkBoxAlignFreeInCuesToShotCuts.TabIndex = 42;
            this.checkBoxAlignFreeInCuesToShotCuts.Text = "Snap \"free\" in cues to shot cuts if within (frames):";
            this.checkBoxAlignFreeInCuesToShotCuts.UseVisualStyleBackColor = true;
            this.checkBoxAlignFreeInCuesToShotCuts.CheckedChanged += new System.EventHandler(this.checkBoxAlignFreeInCuesToShotCuts_CheckedChanged);
            // 
            // numericUpDownAlignFreeInCuesToShotCuts
            // 
            this.numericUpDownAlignFreeInCuesToShotCuts.Location = new System.Drawing.Point(319, 315);
            this.numericUpDownAlignFreeInCuesToShotCuts.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownAlignFreeInCuesToShotCuts.Name = "numericUpDownAlignFreeInCuesToShotCuts";
            this.numericUpDownAlignFreeInCuesToShotCuts.Size = new System.Drawing.Size(75, 23);
            this.numericUpDownAlignFreeInCuesToShotCuts.TabIndex = 43;
            this.numericUpDownAlignFreeInCuesToShotCuts.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // checkBoxFreeInCuesToShotCutsExtendOnly
            // 
            this.checkBoxFreeInCuesToShotCutsExtendOnly.AutoSize = true;
            this.checkBoxFreeInCuesToShotCutsExtendOnly.Checked = true;
            this.checkBoxFreeInCuesToShotCutsExtendOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFreeInCuesToShotCutsExtendOnly.Location = new System.Drawing.Point(419, 318);
            this.checkBoxFreeInCuesToShotCutsExtendOnly.Name = "checkBoxFreeInCuesToShotCutsExtendOnly";
            this.checkBoxFreeInCuesToShotCutsExtendOnly.Size = new System.Drawing.Size(87, 19);
            this.checkBoxFreeInCuesToShotCutsExtendOnly.TabIndex = 44;
            this.checkBoxFreeInCuesToShotCutsExtendOnly.Text = "Extend only";
            this.checkBoxFreeInCuesToShotCutsExtendOnly.UseVisualStyleBackColor = true;
            // 
            // checkBoxMakeBackup
            // 
            this.checkBoxMakeBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxMakeBackup.AutoSize = true;
            this.checkBoxMakeBackup.Checked = true;
            this.checkBoxMakeBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMakeBackup.Location = new System.Drawing.Point(13, 592);
            this.checkBoxMakeBackup.Name = "checkBoxMakeBackup";
            this.checkBoxMakeBackup.Size = new System.Drawing.Size(259, 19);
            this.checkBoxMakeBackup.TabIndex = 45;
            this.checkBoxMakeBackup.Text = "Make back-up when overwriting existing file";
            this.checkBoxMakeBackup.UseVisualStyleBackColor = true;
            // 
            // labelThresholdLow
            // 
            this.labelThresholdLow.AutoSize = true;
            this.labelThresholdLow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThresholdLow.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelThresholdLow.Location = new System.Drawing.Point(84, 112);
            this.labelThresholdLow.Name = "labelThresholdLow";
            this.labelThresholdLow.Size = new System.Drawing.Size(127, 15);
            this.labelThresholdLow.TabIndex = 46;
            this.labelThresholdLow.Text = "detect smaller changes";
            // 
            // labelThresholdHigh
            // 
            this.labelThresholdHigh.AutoSize = true;
            this.labelThresholdHigh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThresholdHigh.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelThresholdHigh.Location = new System.Drawing.Point(292, 112);
            this.labelThresholdHigh.Name = "labelThresholdHigh";
            this.labelThresholdHigh.Size = new System.Drawing.Size(123, 15);
            this.labelThresholdHigh.TabIndex = 47;
            this.labelThresholdHigh.Text = "detect bigger changes";
            this.labelThresholdHigh.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 623);
            this.Controls.Add(this.labelThresholdHigh);
            this.Controls.Add(this.labelThresholdLow);
            this.Controls.Add(this.checkBoxMakeBackup);
            this.Controls.Add(this.checkBoxFreeInCuesToShotCutsExtendOnly);
            this.Controls.Add(this.numericUpDownAlignFreeInCuesToShotCuts);
            this.Controls.Add(this.checkBoxAlignFreeInCuesToShotCuts);
            this.Controls.Add(this.buttonClearShotCuts);
            this.Controls.Add(this.buttonClearTimeCodes);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.numericUpDownExtend);
            this.Controls.Add(this.checkBoxExtend);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkBoxFreeOutCuesToShotCutsExtendOnly);
            this.Controls.Add(this.numericUpDownOvershootShotCuts);
            this.Controls.Add(this.checkBoxOvershootShotCuts);
            this.Controls.Add(this.numericUpDownAlignFreeOutCuesToShotCuts);
            this.Controls.Add(this.checkBoxAlignFreeOutCuesToShotCuts);
            this.Controls.Add(this.checkBoxConnectToShotCuts);
            this.Controls.Add(this.numericUpDownConnectMaxGap);
            this.Controls.Add(this.labelConnectMaxGap);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonExportShotCuts);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.numericUpDownMaxShotCutOffset);
            this.Controls.Add(this.numericUpDownDetectMaxGap);
            this.Controls.Add(this.labelDetectMaxGap);
            this.Controls.Add(this.buttonImportShotCuts);
            this.Controls.Add(this.checkBoxShotCuts);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numericUpDownGap);
            this.Controls.Add(this.labelGap);
            this.Controls.Add(this.checkBoxOnlyGapsBeforeShotCuts);
            this.Controls.Add(this.labelMaxShotCutOffset);
            this.Controls.Add(this.progressBarShotCuts);
            this.Controls.Add(this.progressBarTimeCodes);
            this.Controls.Add(this.buttonAnalyze);
            this.Controls.Add(this.numericUpDownThreshold);
            this.Controls.Add(this.trackBarThreshold);
            this.Controls.Add(this.labelThreshold);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxVideo);
            this.Controls.Add(this.labelVideo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sub Timings Beautifier";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDetectMaxGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxShotCutOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConnectMaxGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlignFreeOutCuesToShotCuts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOvershootShotCuts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExtend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlignFreeInCuesToShotCuts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVideo;
        private System.Windows.Forms.TextBox textBoxVideo;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelThreshold;
        private System.Windows.Forms.TrackBar trackBarThreshold;
        private System.Windows.Forms.NumericUpDown numericUpDownThreshold;
        private System.Windows.Forms.Button buttonAnalyze;
        private System.Windows.Forms.ProgressBar progressBarTimeCodes;
        private System.Windows.Forms.ProgressBar progressBarShotCuts;
        private System.Windows.Forms.Label labelMaxShotCutOffset;
        private System.Windows.Forms.CheckBox checkBoxOnlyGapsBeforeShotCuts;
        private System.Windows.Forms.Label labelGap;
        private System.Windows.Forms.NumericUpDown numericUpDownGap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxShotCuts;
        private System.Windows.Forms.Button buttonImportShotCuts;
        private System.Windows.Forms.Label labelDetectMaxGap;
        private System.Windows.Forms.NumericUpDown numericUpDownDetectMaxGap;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxShotCutOffset;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Button buttonExportShotCuts;
        private System.Windows.Forms.OpenFileDialog openFileDialogVideo;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.NumericUpDown numericUpDownConnectMaxGap;
        private System.Windows.Forms.Label labelConnectMaxGap;
        private System.Windows.Forms.CheckBox checkBoxConnectToShotCuts;
        private System.Windows.Forms.CheckBox checkBoxAlignFreeOutCuesToShotCuts;
        private System.Windows.Forms.NumericUpDown numericUpDownAlignFreeOutCuesToShotCuts;
        private System.Windows.Forms.CheckBox checkBoxOvershootShotCuts;
        private System.Windows.Forms.NumericUpDown numericUpDownOvershootShotCuts;
        private System.Windows.Forms.CheckBox checkBoxFreeOutCuesToShotCutsExtendOnly;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDownExtend;
        private System.Windows.Forms.CheckBox checkBoxExtend;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonClearTimeCodes;
        private System.Windows.Forms.Button buttonClearShotCuts;
        private System.Windows.Forms.CheckBox checkBoxAlignFreeInCuesToShotCuts;
        private System.Windows.Forms.NumericUpDown numericUpDownAlignFreeInCuesToShotCuts;
        private System.Windows.Forms.CheckBox checkBoxFreeInCuesToShotCutsExtendOnly;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox checkBoxMakeBackup;
        private System.Windows.Forms.Label labelThresholdLow;
        private System.Windows.Forms.Label labelThresholdHigh;
    }
}

