namespace SubTimingsBeautifier
{
    partial class FormImportShotCuts
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
            this.textBoxTimecodes = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelInstruction = new System.Windows.Forms.Label();
            this.groupBoxTimeCodes = new System.Windows.Forms.GroupBox();
            this.radioButtonSeconds = new System.Windows.Forms.RadioButton();
            this.radioButtonMilliseconds = new System.Windows.Forms.RadioButton();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxTimeCodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxTimecodes
            // 
            this.textBoxTimecodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTimecodes.Location = new System.Drawing.Point(15, 37);
            this.textBoxTimecodes.Multiline = true;
            this.textBoxTimecodes.Name = "textBoxTimecodes";
            this.textBoxTimecodes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTimecodes.Size = new System.Drawing.Size(430, 262);
            this.textBoxTimecodes.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(370, 368);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(289, 368);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // labelInstruction
            // 
            this.labelInstruction.AutoSize = true;
            this.labelInstruction.Location = new System.Drawing.Point(12, 12);
            this.labelInstruction.Name = "labelInstruction";
            this.labelInstruction.Size = new System.Drawing.Size(259, 15);
            this.labelInstruction.TabIndex = 3;
            this.labelInstruction.Text = "Paste shot cuts below, one timecode per line, or";
            // 
            // groupBoxTimeCodes
            // 
            this.groupBoxTimeCodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTimeCodes.Controls.Add(this.radioButtonSeconds);
            this.groupBoxTimeCodes.Controls.Add(this.radioButtonMilliseconds);
            this.groupBoxTimeCodes.Location = new System.Drawing.Point(15, 305);
            this.groupBoxTimeCodes.Name = "groupBoxTimeCodes";
            this.groupBoxTimeCodes.Size = new System.Drawing.Size(430, 53);
            this.groupBoxTimeCodes.TabIndex = 4;
            this.groupBoxTimeCodes.TabStop = false;
            this.groupBoxTimeCodes.Text = "Time codes";
            // 
            // radioButtonSeconds
            // 
            this.radioButtonSeconds.AutoSize = true;
            this.radioButtonSeconds.Location = new System.Drawing.Point(215, 22);
            this.radioButtonSeconds.Name = "radioButtonSeconds";
            this.radioButtonSeconds.Size = new System.Drawing.Size(69, 19);
            this.radioButtonSeconds.TabIndex = 1;
            this.radioButtonSeconds.Text = "Seconds";
            this.radioButtonSeconds.UseVisualStyleBackColor = true;
            // 
            // radioButtonMilliseconds
            // 
            this.radioButtonMilliseconds.AutoSize = true;
            this.radioButtonMilliseconds.Checked = true;
            this.radioButtonMilliseconds.Location = new System.Drawing.Point(9, 22);
            this.radioButtonMilliseconds.Name = "radioButtonMilliseconds";
            this.radioButtonMilliseconds.Size = new System.Drawing.Size(91, 19);
            this.radioButtonMilliseconds.TabIndex = 0;
            this.radioButtonMilliseconds.TabStop = true;
            this.radioButtonMilliseconds.Text = "Milliseconds";
            this.radioButtonMilliseconds.UseVisualStyleBackColor = true;
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(277, 8);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(98, 23);
            this.buttonOpenFile.TabIndex = 17;
            this.buttonOpenFile.Text = "Open file...";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "*.txt;*.scenechanges;*.xml";
            // 
            // FormImportShotCuts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(457, 403);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.groupBoxTimeCodes);
            this.Controls.Add(this.labelInstruction);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxTimecodes);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(473, 442);
            this.Name = "FormImportShotCuts";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import shot cuts...";
            this.groupBoxTimeCodes.ResumeLayout(false);
            this.groupBoxTimeCodes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelInstruction;
        public System.Windows.Forms.TextBox textBoxTimecodes;
        private System.Windows.Forms.GroupBox groupBoxTimeCodes;
        public System.Windows.Forms.RadioButton radioButtonSeconds;
        public System.Windows.Forms.RadioButton radioButtonMilliseconds;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}