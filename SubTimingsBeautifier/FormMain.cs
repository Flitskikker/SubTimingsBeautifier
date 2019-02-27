using Nikse.SubtitleEdit.PluginLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace SubTimingsBeautifier
{
    public partial class FormMain : Form
    {
        private List<double> timeCodes = new List<double>();
        private List<double> shotCuts = new List<double>();

        private bool timeCodesImported = false;
        private bool shotCutsImported = false;

        private Process processTimecodes;
        private Process processShotCuts;

        private double duration = 0;
        private string lastError = "";

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set title
            this.Text = "Sub Timings Beautifier v" + Application.ProductVersion;

            // Default config
            checkBoxAlignFreeOutCuesToShotCuts.Checked = true;
            checkBoxOvershootShotCuts.Checked = false;
            //RestoreUI(false, false);
        }
                
        private string GetTimeCodesFilePath()
        {
            return textBoxVideo.Text + ".timecodes.txt";
        }

        private string GetShotCutsFilePath()
        {
            return textBoxVideo.Text + ".shotcuts.txt";
        }

        private void numericUpDownThreshold_ValueChanged(object sender, EventArgs e)
        {
            trackBarThreshold.Value = (int) (numericUpDownThreshold.Value * 100);
        }

        private void trackBarThreshold_Scroll(object sender, EventArgs e)
        {
            numericUpDownThreshold.Value = Convert.ToDecimal(trackBarThreshold.Value) / 100;
        }

        private void checkBoxShotCuts_CheckedChanged(object sender, EventArgs e)
        {
            buttonImportShotCuts.Enabled = checkBoxShotCuts.Checked;
            labelThreshold.Enabled = checkBoxShotCuts.Checked;
            trackBarThreshold.Enabled = checkBoxShotCuts.Checked;
            numericUpDownThreshold.Enabled = checkBoxShotCuts.Checked;
            labelMaxShotCutOffset.Enabled = checkBoxShotCuts.Checked;
            numericUpDownMaxShotCutOffset.Enabled = checkBoxShotCuts.Checked;
            checkBoxOnlyGapsBeforeShotCuts.Enabled = checkBoxShotCuts.Checked;
            progressBarShotCuts.Enabled = checkBoxShotCuts.Checked;
            checkBoxAlignFreeInCuesToShotCuts.Enabled = checkBoxShotCuts.Checked;
            numericUpDownAlignFreeInCuesToShotCuts.Enabled = checkBoxShotCuts.Checked;
            checkBoxFreeInCuesToShotCutsExtendOnly.Enabled = checkBoxShotCuts.Checked;
            checkBoxAlignFreeOutCuesToShotCuts.Enabled = checkBoxShotCuts.Checked;
            numericUpDownAlignFreeOutCuesToShotCuts.Enabled = checkBoxShotCuts.Checked;
            checkBoxFreeOutCuesToShotCutsExtendOnly.Enabled = checkBoxShotCuts.Checked;
            checkBoxOvershootShotCuts.Enabled = checkBoxShotCuts.Checked;
            numericUpDownOvershootShotCuts.Enabled = checkBoxShotCuts.Checked;

            checkBoxAlignFreeInCuesToShotCuts_CheckedChanged(checkBoxAlignFreeInCuesToShotCuts, new EventArgs());
            checkBoxAlignFreeOutCuesToShotCuts_CheckedChanged(checkBoxAlignFreeOutCuesToShotCuts, new EventArgs());
            checkBoxOvershootShotCuts_CheckedChanged(checkBoxOvershootShotCuts, new EventArgs());
        }

        private void buttonImportShotCuts_Click(object sender, EventArgs e)
        {
            // Create form
            FormImportShotCuts formInput = new FormImportShotCuts();

            // Populate existing time codes
            formInput.textBoxTimecodes.Lines = this.shotCuts.Select(x => x.ToString()).ToArray();

            if (formInput.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Convert to time codes
                    if (formInput.radioButtonSeconds.Checked)
                    {
                        this.shotCuts = Array.ConvertAll(formInput.textBoxTimecodes.Lines.Where(x => !string.IsNullOrEmpty(x)).ToArray(), Double.Parse).Select(x => x * 1000).ToList();
                    }
                    else if (formInput.radioButtonMilliseconds.Checked)
                    {
                        this.shotCuts = Array.ConvertAll(formInput.textBoxTimecodes.Lines.Where(x => !string.IsNullOrEmpty(x)).ToArray(), Double.Parse).Select(x => x).ToList();
                    }

                    // Write file
                    File.WriteAllLines(GetShotCutsFilePath(), this.shotCuts.Select(x => x.ToString()).ToArray(), Encoding.Default);

                    // Check time codes
                    CheckShotCuts();
                                        
                    MessageBox.Show("" + this.shotCuts.Count + " shot cuts imported.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Invalid timecodes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialogVideo.ShowDialog() == DialogResult.OK)
            {
                // Set file name
                textBoxVideo.Text = openFileDialogVideo.FileName;

                // Reset
                this.timeCodes.Clear();
                this.shotCuts.Clear();
                this.progressBarTimeCodes.Value = 0;
                this.progressBarShotCuts.Value = 0;
                this.timeCodesImported = false;
                this.shotCutsImported = false;
                this.buttonAnalyze.Enabled = true;
                this.buttonGo.Enabled = false;
                this.buttonExportShotCuts.Enabled = false;
                this.labelThreshold.Enabled = true;
                this.trackBarThreshold.Enabled = true;
                this.numericUpDownThreshold.Enabled = true;
                this.checkBoxShotCuts.Enabled = true;
                this.buttonImportShotCuts.Enabled = true;
                this.openFileDialog.FileName = "";
                this.saveFileDialog.FileName = "";
                buttonClearTimeCodes.Enabled = false;
                buttonClearShotCuts.Enabled = false;

                // Check if file with time codes exists for this video
                if (File.Exists(GetTimeCodesFilePath()))
                {
                    // Load it
                    try
                    {
                        // Convert to time codes
                        this.timeCodes = Array.ConvertAll(File.ReadLines(GetTimeCodesFilePath()).Where(x => !string.IsNullOrEmpty(x)).ToArray(), Double.Parse).Select(x => x).ToList();

                        // Check time codes
                        if (this.timeCodes.Count > 0)
                        {
                            progressBarTimeCodes.Maximum = 100;
                            progressBarTimeCodes.Value = 100;
                            buttonClearTimeCodes.Enabled = true;
                            this.timeCodesImported = true;
                        }
                        else
                        {
                            progressBarTimeCodes.Value = 0;
                            buttonClearTimeCodes.Enabled = false;
                            this.timeCodesImported = false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Invalid saved timecodes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Check if file with shot cuts exists for this video
                if (File.Exists(GetShotCutsFilePath()))
                {
                    // Load it
                    try
                    {
                        // Convert to time codes
                        this.shotCuts = Array.ConvertAll(File.ReadLines(GetShotCutsFilePath()).Where(x => !string.IsNullOrEmpty(x)).ToArray(), Double.Parse).Select(x => x).ToList();

                        // Check time codes
                        CheckShotCuts();
                    }
                    catch
                    {
                        MessageBox.Show("Invalid saved shot cuts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Reload UI
                if (this.timeCodes.Count > 0 && this.shotCuts.Count > 0)
                {
                    this.RestoreUI(true, true);
                }
            }
        }

        private void CheckShotCuts()
        {
            if (this.shotCuts.Count > 0)
            {
                if (progressBarShotCuts.Value != progressBarShotCuts.Maximum)
                {
                    progressBarShotCuts.Maximum = 100;
                    progressBarShotCuts.Value = 100;
                }
                
                buttonClearShotCuts.Enabled = true;
                checkBoxShotCuts.Enabled = false;
                buttonImportShotCuts.Enabled = false;
                labelThreshold.Enabled = false;
                trackBarThreshold.Enabled = false;
                numericUpDownThreshold.Enabled = false;
                buttonExportShotCuts.Enabled = true;
                checkBoxShotCuts.Checked = true;
                this.shotCutsImported = true;
            }
            else
            {
                progressBarShotCuts.Value = 0;
                buttonClearShotCuts.Enabled = false;
                checkBoxShotCuts.Enabled = true;
                buttonImportShotCuts.Enabled = true;
                labelThreshold.Enabled = true;
                trackBarThreshold.Enabled = true;
                numericUpDownThreshold.Enabled = true;
                buttonExportShotCuts.Enabled = false;
                this.shotCutsImported = false;
            }
        }

        private void buttonExportShotCuts_Click(object sender, EventArgs e)
        {
            // Update clipboard
            Clipboard.SetText(String.Join(Environment.NewLine, this.shotCuts.Select(x => x.ToString())));

            // Show message
            MessageBox.Show("Shot cuts copied to clipboard (as milliseconds)!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Kill processes
            try { processTimecodes.Kill(); } catch { }
            try { processShotCuts.Kill(); } catch { }
        }
        
        private void buttonClearTimeCodes_Click(object sender, EventArgs e)
        {
            // Ask confirmation
            if (MessageBox.Show("Are you sure you want to clear the time codes for this video? You will need to re-analyze the video.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Delete time codes from memory and disk
                this.timeCodes.Clear();
                try { File.Delete(GetTimeCodesFilePath()); } catch { }

                // Reset
                this.progressBarTimeCodes.Value = 0;
                this.buttonClearTimeCodes.Enabled = false;
                this.timeCodesImported = false;

                this.buttonAnalyze.Enabled = true;
                this.buttonGo.Enabled = false;

                // Reload UI
                CheckShotCuts();
            }
        }

        private void buttonClearShotCuts_Click(object sender, EventArgs e)
        {
            // Ask confirmation
            if (MessageBox.Show("Are you sure you want to clear the shot cuts for this video? You will need to re-analyze the video.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Delete shot cuts from memory and disk
                this.shotCuts.Clear();
                try { File.Delete(GetShotCutsFilePath()); } catch { }

                // Reset
                this.progressBarShotCuts.Value = 0;
                this.buttonClearShotCuts.Enabled = false;
                this.shotCutsImported = false;

                this.buttonAnalyze.Enabled = true;

                // Reload UI
                CheckShotCuts();
            }
        }
        
        private void checkBoxAlignFreeInCuesToShotCuts_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAlignFreeInCuesToShotCuts.Enabled)
            {
                checkBoxFreeInCuesToShotCutsExtendOnly.Enabled = checkBoxAlignFreeInCuesToShotCuts.Checked;
                numericUpDownAlignFreeInCuesToShotCuts.Enabled = checkBoxAlignFreeInCuesToShotCuts.Checked;
            }
        }

        private void checkBoxAlignFreeOutCuesToShotCuts_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAlignFreeOutCuesToShotCuts.Enabled)
            {
                checkBoxFreeOutCuesToShotCutsExtendOnly.Enabled = checkBoxAlignFreeOutCuesToShotCuts.Checked;
                numericUpDownAlignFreeOutCuesToShotCuts.Enabled = checkBoxAlignFreeOutCuesToShotCuts.Checked;
            }
        }

        private void checkBoxOvershootShotCuts_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOvershootShotCuts.Enabled)
            {
                numericUpDownOvershootShotCuts.Enabled = checkBoxOvershootShotCuts.Checked;
            }
        }
        
        private void checkBoxExtend_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownExtend.Enabled = checkBoxExtend.Checked;
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            // Show open file dialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Open check
                Subtitle subtitle = new Subtitle();
                SubRip subRip = new SubRip();

                // Load sub
                subRip.LoadSubtitle(subtitle, File.ReadAllLines(openFileDialog.FileName, GetEncoding(openFileDialog.FileName)), "");

                // Parse fps
                double correction = 0; // Removed: (double) numericUpDownSECorrection.Value;

                double frameMs = this.timeCodes[1] - this.timeCodes[0];

                double shotCutMaxOffsetMs = this.timeCodes[(int) numericUpDownMaxShotCutOffset.Value] - this.timeCodes[0];
                double gapMs = this.timeCodes[(int) numericUpDownGap.Value] - this.timeCodes[0];
                double maxGapMs = (double) numericUpDownDetectMaxGap.Value;
                double maxConnectGapMs = (double) numericUpDownConnectMaxGap.Value;

                double alignInCuesMs = this.timeCodes[(int)numericUpDownAlignFreeInCuesToShotCuts.Value] - this.timeCodes[0];
                double alignOutCuesMs = this.timeCodes[(int) numericUpDownAlignFreeOutCuesToShotCuts.Value] - this.timeCodes[0];
                double overshootMs = this.timeCodes[(int) numericUpDownOvershootShotCuts.Value] - this.timeCodes[0];

                // Set cursor
                this.Cursor = Cursors.WaitCursor;

                // Fix
                for (int p = 0; p < subtitle.Paragraphs.Count; p++)
                {
                    // Get corrected start
                    double start = subtitle.Paragraphs[p].StartTime.TotalMilliseconds + correction;

                    // Get nearest shot cut
                    double nearestShotCut = this.shotCuts.Count > 0 ? this.shotCuts.Aggregate((x, y) => Math.Abs(x - start) < Math.Abs(y - start) ? x : y) : -9999;

                    // Check if shot cut is within max offset
                    if (Math.Abs(nearestShotCut - start) <= shotCutMaxOffsetMs + (frameMs / 2))
                    {
                        // Check if not the first title
                        if (p > 0)
                        {
                            // Get previous end cue
                            double previousEnd = subtitle.Paragraphs[p - 1].EndTime.TotalMilliseconds;

                            // Get shot cut cue
                            double nearestShotCutExact = this.timeCodes.Aggregate((x, y) => Math.Abs(x - nearestShotCut) < Math.Abs(y - nearestShotCut) ? x : y);

                            // Check if there is a gap
                            if (Math.Abs(start - previousEnd) <= maxGapMs || Math.Abs(nearestShotCutExact - previousEnd) <= maxGapMs)
                            {
                                // Yes: Check which cue is closer
                                if ((Math.Abs(nearestShotCut - start) <= Math.Abs(nearestShotCut - previousEnd)) || this.checkBoxOnlyGapsBeforeShotCuts.Checked)
                                {
                                    // Incue on the shot cut
                                    subtitle.Paragraphs[p].StartTime.TotalMilliseconds = nearestShotCutExact;

                                    // Calculate gap time
                                    double newEnd = nearestShotCut - gapMs;

                                    // Nicely align it
                                    subtitle.Paragraphs[p - 1].EndTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - newEnd) < Math.Abs(y - newEnd) ? x : y);
                                }
                                else
                                {
                                    // Outcue on the shot cut
                                    subtitle.Paragraphs[p - 1].EndTime.TotalMilliseconds = nearestShotCutExact;

                                    // Calculate gap time
                                    double newStart = nearestShotCut + gapMs;

                                    // Nicely align it
                                    subtitle.Paragraphs[p].StartTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - newStart) < Math.Abs(y - newStart) ? x : y);
                                }
                            }
                            else
                            {
                                // No: Just align the cue on the shot cut
                                subtitle.Paragraphs[p].StartTime.TotalMilliseconds = nearestShotCutExact;
                            }
                        }
                        else
                        {
                            // It's the first: Just align the cue on the shot cut
                            subtitle.Paragraphs[p].StartTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - nearestShotCut) < Math.Abs(y - nearestShotCut) ? x : y);
                        }
                    }
                    else
                    {
                        // No: just align time
                        subtitle.Paragraphs[p].StartTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - start) < Math.Abs(y - start) ? x : y);

                        // Check if snapping is enabled
                        if (checkBoxAlignFreeInCuesToShotCuts.Checked)
                        {
                            // Get nearest shot cut
                            double nearestAlignShotCut = -9999;

                            if (checkBoxFreeInCuesToShotCutsExtendOnly.Checked)
                            {
                                List<double> previousShotCuts = this.shotCuts.Count > 0 ? this.shotCuts.Where(x => x <= subtitle.Paragraphs[p].StartTime.TotalMilliseconds + frameMs - 1.0).ToList() : new List<double>();
                                nearestAlignShotCut = previousShotCuts.Count > 0 ? previousShotCuts.Aggregate((x, y) => Math.Abs(x - subtitle.Paragraphs[p].StartTime.TotalMilliseconds) < Math.Abs(y - subtitle.Paragraphs[p].StartTime.TotalMilliseconds) ? x : y) : -9999;
                            }
                            else
                            {
                                nearestAlignShotCut = this.shotCuts.Count > 0 ? this.shotCuts.Aggregate((x, y) => Math.Abs(x - subtitle.Paragraphs[p].StartTime.TotalMilliseconds) < Math.Abs(y - subtitle.Paragraphs[p].StartTime.TotalMilliseconds) ? x : y) : -9999;
                            }

                            // Check if shot cut is within max align offset
                            if (Math.Abs(nearestAlignShotCut - subtitle.Paragraphs[p].StartTime.TotalMilliseconds) <= alignInCuesMs)
                            {
                                // Check direction
                                if (subtitle.Paragraphs[p].StartTime.TotalMilliseconds >= nearestAlignShotCut)
                                {
                                    // Extend: Check if previous end cue is not in the way
                                    if (p == 0 || nearestAlignShotCut - subtitle.Paragraphs[p - 1].EndTime.TotalMilliseconds >= gapMs)
                                    {
                                        // Snap it!
                                        subtitle.Paragraphs[p].StartTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - nearestAlignShotCut) < Math.Abs(y - nearestAlignShotCut) ? x : y);
                                    }
                                }
                                else
                                {
                                    // Shrink: Check if there is no gap
                                    if (p == 0 || subtitle.Paragraphs[p].StartTime.TotalMilliseconds - subtitle.Paragraphs[p - 1].EndTime.TotalMilliseconds > maxGapMs)
                                    {
                                        // Check if duration is longer than 0
                                        if (subtitle.Paragraphs[p].EndTime.TotalMilliseconds - nearestAlignShotCut > 0)
                                        {
                                            // Snap it!
                                            subtitle.Paragraphs[p].StartTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - nearestAlignShotCut) < Math.Abs(y - nearestAlignShotCut) ? x : y);
                                        }
                                    }
                                }
                            }
                        }

                        // Check if not first title
                        if (p > 0)
                        {
                            // Check if we should fix this gap
                            if (Math.Abs(subtitle.Paragraphs[p].StartTime.TotalMilliseconds - subtitle.Paragraphs[p - 1].EndTime.TotalMilliseconds) <= maxGapMs)
                            {
                                // Calculate gap time
                                double newEnd = subtitle.Paragraphs[p].StartTime.TotalMilliseconds - gapMs;

                                // Get nearest shot cut
                                nearestShotCut = this.shotCuts.Count > 0 ? this.shotCuts.Aggregate((x, y) => Math.Abs(x - newEnd) < Math.Abs(y - newEnd) ? x : y) : -9999;

                                // Check if shot cut is within max offset
                                if (Math.Abs(nearestShotCut - newEnd) <= shotCutMaxOffsetMs + (frameMs / 2))
                                {
                                    // Check if not the last cue
                                    if (p < subtitle.Paragraphs.Count)
                                    {
                                        // Get next start cue
                                        double nextStart = subtitle.Paragraphs[p].StartTime.TotalMilliseconds;

                                        // Get shot cut cue
                                        double nearestShotCutExact = this.timeCodes.Aggregate((x, y) => Math.Abs(x - nearestShotCut) < Math.Abs(y - nearestShotCut) ? x : y);

                                        // Check if there is a gap
                                        if (Math.Abs(nextStart - newEnd) <= maxGapMs || Math.Abs(nextStart - nearestShotCutExact) <= maxGapMs)
                                        {
                                            // Yes: Check which cue is closer
                                            if ((Math.Abs(nearestShotCut - nextStart) <= Math.Abs(nearestShotCut - newEnd)) || this.checkBoxOnlyGapsBeforeShotCuts.Checked)
                                            {
                                                // Incue on the shot cut
                                                subtitle.Paragraphs[p].StartTime.TotalMilliseconds = nearestShotCutExact;

                                                // Calculate gap time
                                                double newNewEnd = nearestShotCut - gapMs;

                                                // Nicely align it
                                                subtitle.Paragraphs[p - 1].EndTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - newNewEnd) < Math.Abs(y - newNewEnd) ? x : y);
                                            }
                                            else
                                            {
                                                // Outcue on the shot cut
                                                subtitle.Paragraphs[p - 1].EndTime.TotalMilliseconds = nearestShotCutExact;

                                                // Calculate gap time
                                                double newStart = nearestShotCut + gapMs;

                                                // Nicely align it
                                                subtitle.Paragraphs[p].StartTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - newStart) < Math.Abs(y - newStart) ? x : y);
                                            }
                                        }
                                        else
                                        {
                                            // No: Just align the cue on the shot cut
                                            subtitle.Paragraphs[p - 1].EndTime.TotalMilliseconds = nearestShotCutExact;
                                        }
                                    }
                                    else
                                    {
                                        // It's the last: Just align the cue on the shot cut
                                        subtitle.Paragraphs[p - 1].EndTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - nearestShotCut) < Math.Abs(y - nearestShotCut) ? x : y);
                                    }
                                }
                                else
                                {
                                    // No: just align time
                                    subtitle.Paragraphs[p - 1].EndTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - newEnd) < Math.Abs(y - newEnd) ? x : y);
                                }
                            }
                        }
                    }
                    
                    // Check if not first title
                    if (p > 0)
                    {
                        // Check if we should connect this gap
                        if (Math.Abs(subtitle.Paragraphs[p].StartTime.TotalMilliseconds - subtitle.Paragraphs[p - 1].EndTime.TotalMilliseconds) <= maxConnectGapMs)
                        {
                            // Out cue shouldn't be on shot cut
                            double nearestEndShotCut = this.shotCuts.Count > 0 ? this.shotCuts.Aggregate((x, y) => Math.Abs(x - subtitle.Paragraphs[p - 1].EndTime.TotalMilliseconds) < Math.Abs(y - subtitle.Paragraphs[p - 1].EndTime.TotalMilliseconds) ? x : y) : -9999;

                            if (Math.Abs(nearestEndShotCut - subtitle.Paragraphs[p - 1].EndTime.TotalMilliseconds) > frameMs - 1.0)
                            {
                                // In cue shouldn't be on shot cut if set
                                double nearestStartShotCut = this.shotCuts.Count > 0 ? this.shotCuts.Aggregate((x, y) => Math.Abs(x - subtitle.Paragraphs[p].StartTime.TotalMilliseconds) < Math.Abs(y - subtitle.Paragraphs[p].StartTime.TotalMilliseconds) ? x : y) : -9999;

                                if (Math.Abs(nearestStartShotCut - subtitle.Paragraphs[p].StartTime.TotalMilliseconds) > frameMs - 1.0 || checkBoxConnectToShotCuts.Checked)
                                {
                                    // Calculate gap time
                                    double newEnd = subtitle.Paragraphs[p].StartTime.TotalMilliseconds - gapMs;

                                    // Check if there are scene changes in the way
                                    List<double> shotCutsInBetween = this.shotCuts.Count > 0 ? this.shotCuts.Where(x => x > subtitle.Paragraphs[p - 1].EndTime.TotalMilliseconds - frameMs + 1.0 && x < newEnd + frameMs - 1.0).ToList() : new List<double>();

                                    // If there is a shot cut, align to first one
                                    if (shotCutsInBetween.Count > 0)
                                    {
                                        // Nicely align it
                                        subtitle.Paragraphs[p - 1].EndTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - shotCutsInBetween.First()) < Math.Abs(y - shotCutsInBetween.First()) ? x : y);
                                    }
                                    else
                                    {
                                        // Nicely align it
                                        subtitle.Paragraphs[p - 1].EndTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - newEnd) < Math.Abs(y - newEnd) ? x : y);
                                    }
                                }
                            }
                        }
                    }

                    double end = subtitle.Paragraphs[p].EndTime.TotalMilliseconds + correction;

                    // Get nearest shot cut
                    nearestShotCut = this.shotCuts.Count > 0 ? this.shotCuts.Aggregate((x, y) => Math.Abs(x - end) < Math.Abs(y - end) ? x : y) : -9999;

                    // Check if shot cut is within max offset
                    if (Math.Abs(nearestShotCut - end) <= shotCutMaxOffsetMs + (frameMs / 2))
                    {
                        // Check if not the last cue
                        if (p < subtitle.Paragraphs.Count - 1)
                        {
                            // Get next start cue
                            double nextStart = subtitle.Paragraphs[p + 1].StartTime.TotalMilliseconds;

                            // Get shot cut cue
                            double nearestShotCutExact = this.timeCodes.Aggregate((x, y) => Math.Abs(x - nearestShotCut) < Math.Abs(y - nearestShotCut) ? x : y);

                            // Check if there is a gap                            
                            if (Math.Abs(nextStart - end) <= maxGapMs || Math.Abs(nextStart - nearestShotCutExact) <= maxGapMs)
                            {
                                // Yes: Check which cue is closer
                                if ((Math.Abs(nearestShotCut - nextStart) <= Math.Abs(nearestShotCut - end)) || this.checkBoxOnlyGapsBeforeShotCuts.Checked)
                                {
                                    // Incue on the shot cut
                                    subtitle.Paragraphs[p + 1].StartTime.TotalMilliseconds = nearestShotCutExact;

                                    // Calculate gap time
                                    double newEnd = nearestShotCut - gapMs;

                                    // Nicely align it
                                    subtitle.Paragraphs[p].EndTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - newEnd) < Math.Abs(y - newEnd) ? x : y);
                                }
                                else
                                {
                                    // Outcue on the shot cut
                                    subtitle.Paragraphs[p].EndTime.TotalMilliseconds = nearestShotCutExact;

                                    // Calculate gap time
                                    double newStart = nearestShotCut + gapMs;

                                    // Nicely align it
                                    subtitle.Paragraphs[p + 1].StartTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - newStart) < Math.Abs(y - newStart) ? x : y);
                                }
                            }
                            else
                            {
                                // No: Just align the cue on the shot cut
                                subtitle.Paragraphs[p].EndTime.TotalMilliseconds = nearestShotCutExact;
                            }
                        }
                        else
                        {
                            // It's the last: Just align the cue on the shot cut
                            subtitle.Paragraphs[p].EndTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - nearestShotCut) < Math.Abs(y - nearestShotCut) ? x : y);
                        }
                    }
                    else
                    {
                        // No: just align time
                        subtitle.Paragraphs[p].EndTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - end) < Math.Abs(y - end) ? x : y);

                        // Check if extending is enabled
                        if (checkBoxExtend.Checked)
                        {
                            // Get potential values
                            double extendedEndTime = subtitle.Paragraphs[p].EndTime.TotalMilliseconds + (double) numericUpDownExtend.Value;
                            double nearestStartTimeWithGap = p != subtitle.Paragraphs.Count - 1 ? subtitle.Paragraphs[p + 1].StartTime.TotalMilliseconds - gapMs : Double.MaxValue;
                            double nearestExtendShotCut = Double.MaxValue;

                            List<double> nextShotCuts = this.shotCuts.Count > 0 ? this.shotCuts.Where(x => x >= subtitle.Paragraphs[p].EndTime.TotalMilliseconds - frameMs + 1.0).ToList() : new List<double>();
                            nearestExtendShotCut = nextShotCuts.Count > 0 ? nextShotCuts.Aggregate((x, y) => Math.Abs(x - subtitle.Paragraphs[p].EndTime.TotalMilliseconds) < Math.Abs(y - subtitle.Paragraphs[p].EndTime.TotalMilliseconds) ? x : y) : Double.MaxValue;

                            // Calculate the new end time
                            double newExtendedEndTime = Math.Min(Math.Min(extendedEndTime, nearestStartTimeWithGap), nearestExtendShotCut);

                            // Snap it!
                            subtitle.Paragraphs[p].EndTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - newExtendedEndTime) < Math.Abs(y - newExtendedEndTime) ? x : y);
                        }

                        // Check if snapping is enabled
                        if (checkBoxAlignFreeOutCuesToShotCuts.Checked)
                        {
                            // Get nearest shot cut
                            double nearestAlignShotCut = -9999;

                            if (checkBoxFreeOutCuesToShotCutsExtendOnly.Checked)
                            {
                                List<double> nextShotCuts = this.shotCuts.Count > 0 ? this.shotCuts.Where(x => x >= subtitle.Paragraphs[p].EndTime.TotalMilliseconds - frameMs + 1.0).ToList() : new List<double>();
                                nearestAlignShotCut = nextShotCuts.Count > 0 ? nextShotCuts.Aggregate((x, y) => Math.Abs(x - subtitle.Paragraphs[p].EndTime.TotalMilliseconds) < Math.Abs(y - subtitle.Paragraphs[p].EndTime.TotalMilliseconds) ? x : y) : -9999;
                            }
                            else
                            {
                                nearestAlignShotCut = this.shotCuts.Count > 0 ? this.shotCuts.Aggregate((x, y) => Math.Abs(x - subtitle.Paragraphs[p].EndTime.TotalMilliseconds) < Math.Abs(y - subtitle.Paragraphs[p].EndTime.TotalMilliseconds) ? x : y) : -9999;
                            }

                            // Check if shot cut is within max align offset
                            if (Math.Abs(nearestAlignShotCut - subtitle.Paragraphs[p].EndTime.TotalMilliseconds) <= alignOutCuesMs)
                            {
                                // Check direction
                                if (subtitle.Paragraphs[p].EndTime.TotalMilliseconds <= nearestAlignShotCut)
                                {
                                    // Extend: Check if next start cue is not in the way
                                    if (p == subtitle.Paragraphs.Count - 1 || subtitle.Paragraphs[p + 1].StartTime.TotalMilliseconds - nearestAlignShotCut >= gapMs)
                                    {
                                        // Snap it!
                                        subtitle.Paragraphs[p].EndTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - nearestAlignShotCut) < Math.Abs(y - nearestAlignShotCut) ? x : y);
                                    }
                                }
                                else
                                {
                                    // Shrink: Check if there is no gap
                                    if (p == subtitle.Paragraphs.Count - 1 || subtitle.Paragraphs[p + 1].StartTime.TotalMilliseconds - subtitle.Paragraphs[p].EndTime.TotalMilliseconds > maxGapMs)
                                    {
                                        // Check if duration is longer than 0
                                        if (nearestAlignShotCut - subtitle.Paragraphs[p].StartTime.TotalMilliseconds > 0)
                                        {
                                            // Snap it!
                                            subtitle.Paragraphs[p].EndTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - nearestAlignShotCut) < Math.Abs(y - nearestAlignShotCut) ? x : y);
                                        }
                                    }
                                }
                            }
                        }

                        // Check if overshooting is enabled
                        if (checkBoxOvershootShotCuts.Checked)
                        {
                            // Get nearest shot cut
                            List<double> previousShotCuts = this.shotCuts.Count > 0 ? this.shotCuts.Where(x => x <= subtitle.Paragraphs[p].EndTime.TotalMilliseconds + frameMs - 1.0).ToList() : new List<double>();
                            double nearestAlignShotCut = previousShotCuts.Count > 0 ? previousShotCuts.Aggregate((x, y) => Math.Abs(x - subtitle.Paragraphs[p].EndTime.TotalMilliseconds) < Math.Abs(y - subtitle.Paragraphs[p].EndTime.TotalMilliseconds) ? x : y) : -9999;

                            // Cue shouldn't be on shot cut already
                            if (Math.Abs(nearestAlignShotCut - subtitle.Paragraphs[p].EndTime.TotalMilliseconds) > frameMs - 1.0)
                            {
                                // Check if shot cut is not overshot far enough
                                if (subtitle.Paragraphs[p].EndTime.TotalMilliseconds - nearestAlignShotCut < overshootMs)
                                {
                                    // Find the next shot cut after the shot cut that's overshot
                                    List<double> nextShotCuts = this.shotCuts.Count > 0 ? this.shotCuts.Where(x => x > nearestAlignShotCut + frameMs - 1.0).ToList() : new List<double>();
                                    double nextShotCut = nextShotCuts.Count > 0 ? nextShotCuts.Aggregate((x, y) => Math.Abs(x - nearestAlignShotCut) < Math.Abs(y - nearestAlignShotCut) ? x : y) : -9999;

                                    // Calculate new end; either overshoot distance, the next shot cut, or before next in cue
                                    double newEnd = Math.Min(nearestAlignShotCut + overshootMs, Math.Min(nextShotCut, p == subtitle.Paragraphs.Count - 1 ? Double.MaxValue : subtitle.Paragraphs[p + 1].StartTime.TotalMilliseconds - gapMs));

                                    // Snap it!
                                    subtitle.Paragraphs[p].EndTime.TotalMilliseconds = this.timeCodes.Aggregate((x, y) => Math.Abs(x - newEnd) < Math.Abs(y - newEnd) ? x : y);
                                }
                            }
                        }
                    }
                }

                // Reset cursor
                this.Cursor = Cursors.Arrow;
                
                // Show save file dialog
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Create backup if checked
                    if (File.Exists(saveFileDialog.FileName) && checkBoxMakeBackup.Checked)
                    {
                        string fileName = Path.ChangeExtension(saveFileDialog.FileName, ".backup" + Path.GetExtension(saveFileDialog.FileName));
                        int i = 1;

                        while (File.Exists(fileName))
                        {
                            i++;
                            fileName = Path.ChangeExtension(saveFileDialog.FileName, ".backup " + i.ToString() + Path.GetExtension(saveFileDialog.FileName));
                        }

                        File.Copy(saveFileDialog.FileName, fileName, true);
                    }

                    // Save file
                    File.WriteAllText(saveFileDialog.FileName, subRip.ToText(subtitle.Paragraphs), GetEncoding(openFileDialog.FileName));

                    // Show dialog
                    MessageBox.Show(this, "Done!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            // Check if video exists
            if (File.Exists(textBoxVideo.Text))
            {
                // Check if FFprobe exists
                if (!File.Exists(Application.StartupPath + "\\ffprobe.exe"))
                {
                    MessageBox.Show("FFprobe not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if FFmpeg exists
                if (!File.Exists(Application.StartupPath + "\\ffmpeg.exe"))
                {
                    MessageBox.Show("FFmpeg not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                // Disable UI
                buttonAnalyze.Enabled = false;
                labelThreshold.Enabled = false;
                trackBarThreshold.Enabled = false;
                numericUpDownThreshold.Enabled = false;
                checkBoxShotCuts.Enabled = false;
                buttonImportShotCuts.Enabled = false;
                buttonGo.Enabled = false;
                labelVideo.Enabled = false;
                textBoxVideo.Enabled = false;
                buttonBrowse.Enabled = false;
                buttonCancel.Visible = true;

                // Check if we need to get time codes
                if (!timeCodesImported)
                {
                    // Clear array
                    this.timeCodes.Clear();

                    // Create the process
                    processTimecodes = new Process();
                    ProcessStartInfo processStartInfo = new ProcessStartInfo(Application.StartupPath + "\\ffprobe.exe", "\"" + textBoxVideo.Text + "\"");
                    processStartInfo.UseShellExecute = false;
                    processStartInfo.RedirectStandardError = true;
                    processStartInfo.RedirectStandardOutput = true;
                    processStartInfo.CreateNoWindow = true;
                    processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    processTimecodes.StartInfo = processStartInfo;

                    // Set callbacks
                    processTimecodes.OutputDataReceived += ProcessTimecodes_OutputDataReceived;
                    processTimecodes.ErrorDataReceived += ProcessTimecodes_ErrorDataReceived;
                    processTimecodes.Exited += ProcessTimecodes_Exited;

                    // Start process
                    processTimecodes.Start();
                    processTimecodes.BeginOutputReadLine();
                    processTimecodes.BeginErrorReadLine();
                    Application.DoEvents();
                    
                    // Set progress bar
                    progressBarTimeCodes.Value = 0;
                    progressBarTimeCodes.Style = ProgressBarStyle.Marquee;
                    buttonClearTimeCodes.Enabled = false;

                    // Set progress label
                    labelProgress.Text = "Extracting timecodes: 00:00:00 / 00:00:00";
                }
                else
                {
                    // Check if we should continue with shot cuts
                    if (checkBoxShotCuts.Checked && !this.shotCutsImported)
                    {
                        DetectShotCuts();
                    }
                    else
                    {
                        RestoreUI(true, false);
                    }
                }

                Debug.WriteLine("### START " + DateTime.Now.ToString());
            }
            else
            {
                // Show error
                MessageBox.Show(this, "Video file not found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessTimecodes_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            //Debug.WriteLine("[INFO] " + e.Data);

            // Handle output
            HandleProcessTimecodesOutput(e.Data);

            // Trigger Process_Exited
            if (processTimecodes.HasExited)
            {
                try
                {
                    if (processTimecodes.ExitCode >= 0) { }
                }
                catch
                {
                    // Stfu
                }
            }
        }

        private void ProcessTimecodes_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.WriteLine("[ERROR] " + e.Data);

            // Save error
            if (e.Data != null && e.Data != "")
            {
                lastError = e.Data;
            }

            // Handle output (FFmpeg sends regular output as error data)
            HandleProcessTimecodesOutput(e.Data);
        }

        private void ProcessTimecodes_Exited(object sender, EventArgs e)
        {
            Debug.WriteLine("[EXIT] " + processTimecodes.ExitCode);

            // Handle exit
            HandleProcessTimecodesExit(processTimecodes.ExitCode);
        }


        // Functions

        private void HandleProcessTimecodesOutput(string line)
        {
            // Check if line is not empty
            if (line != null && line != "")
            {
                if (line.Contains("Duration:"))
                {
                    // Duration info

                    // Get the duration
                    int startIndex = line.IndexOf("Duration:") + "Duration:".Length;
                    int length = line.IndexOf(",") - startIndex;
                    string durationString = line.Substring(startIndex, length).Trim();

                    // Set duration
                    duration = TimeSpan.Parse(durationString).TotalSeconds;

                    // Update progress bar
                    progressBarTimeCodes.Invoke(new MethodInvoker(() =>
                    {
                        progressBarTimeCodes.Style = ProgressBarStyle.Blocks;
                        progressBarTimeCodes.Maximum = (int)duration;
                    }));

                    // Update progress label
                    labelProgress.Invoke(new MethodInvoker(() =>
                    {
                        labelProgress.Text = "Extracting timecodes: 00:00:00 / " + FormatSeconds(duration);
                    }));
                }
                else if (line.StartsWith("frame,") && !line.Contains("N/A"))
                {
                    // Progress info

                    // Get the time
                    string timeString = line.Replace("frame,", "").Trim();
                    if (timeString.Contains("side_data")) timeString = timeString.Substring(0, timeString.IndexOf("side_data"));

                    // Convert it
                    double time = Double.Parse(timeString.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));

                    // Add it to the array
                    this.timeCodes.Add(time * 1000);

                    // Update progress bar
                    progressBarTimeCodes.Invoke(new MethodInvoker(() =>
                    {
                        progressBarTimeCodes.Value = (int)time;
                    }));

                    // Update progress label
                    labelProgress.Invoke(new MethodInvoker(() =>
                    {
                        labelProgress.Text = "Extracting timecodes: " + FormatSeconds(time) + " / " + FormatSeconds(duration);
                    }));
                }
            }
        }

        private void HandleProcessTimecodesExit(int exitCode)
        {
            Debug.WriteLine("### END " + DateTime.Now.ToString());

            // Check exit code and show message
            if (processTimecodes.ExitCode == 0)
            {
                // Success!

                // Go again
                if (progressBarTimeCodes.Value == 0)
                {
                    // Create the process
                    processTimecodes = new Process();
                    ProcessStartInfo processStartInfo = new ProcessStartInfo(Application.StartupPath + "\\ffprobe.exe", "-select_streams v -show_frames -show_entries frame=pkt_dts_time -of csv -threads 0 \"" + textBoxVideo.Text + "\"");
                    processStartInfo.UseShellExecute = false;
                    processStartInfo.RedirectStandardError = true;
                    processStartInfo.RedirectStandardOutput = true;
                    processStartInfo.CreateNoWindow = true;
                    processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    processTimecodes.StartInfo = processStartInfo;

                    // Set callbacks
                    processTimecodes.OutputDataReceived += ProcessTimecodes_OutputDataReceived;
                    processTimecodes.ErrorDataReceived += ProcessTimecodes_ErrorDataReceived;
                    processTimecodes.Exited += ProcessTimecodes_Exited;

                    // Start process
                    processTimecodes.Start();
                    processTimecodes.BeginOutputReadLine();
                    processTimecodes.BeginErrorReadLine();
                    Application.DoEvents();

                    return;
                }

                // Fill progress bar
                progressBarTimeCodes.Invoke(new MethodInvoker(() =>
                {
                    progressBarTimeCodes.Style = ProgressBarStyle.Blocks;
                    progressBarTimeCodes.Value = progressBarTimeCodes.Maximum;
                }));

                // Set flag
                this.timeCodesImported = true;

                // Write file
                File.WriteAllLines(GetTimeCodesFilePath(), this.timeCodes.Select(x => x.ToString()).ToArray(), Encoding.Default);

                // Check if we should continue with shot cuts
                if (checkBoxShotCuts.Checked && !this.shotCutsImported)
                {
                    progressBarTimeCodes.Invoke(new MethodInvoker(() =>
                    {
                        DetectShotCuts();
                    }));
                }
                else
                {
                    progressBarTimeCodes.Invoke(new MethodInvoker(() =>
                    {
                        RestoreUI(true, false);
                    }));
                }
            }
            else
            {
                // Error!

                // Reset progress bar
                progressBarTimeCodes.Invoke(new MethodInvoker(() =>
                {
                    progressBarTimeCodes.Style = ProgressBarStyle.Blocks;
                }));

                // Show message
                MessageBox.Show("An error occurred.\n\n" + lastError, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Restore UI
                progressBarTimeCodes.Invoke(new MethodInvoker(() =>
                {
                    RestoreUI(false, false);
                }));
            }
        }


        // Shot cuts

        private void DetectShotCuts()
        {
            // Create the process
            processShotCuts = new Process();
            ProcessStartInfo processStartInfo = new ProcessStartInfo(Application.StartupPath + "\\ffmpeg.exe", "-i \"" + textBoxVideo.Text + "\"  -filter:v \"select = 'gt(scene," + numericUpDownThreshold.Value.ToString().Replace(",", ".") + ")', showinfo\"  -threads 0  -f null  -");
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processShotCuts.StartInfo = processStartInfo;

            // Set callbacks
            processShotCuts.OutputDataReceived += ProcessShotCuts_OutputDataReceived;
            processShotCuts.ErrorDataReceived += ProcessShotCuts_ErrorDataReceived;
            processShotCuts.Exited += ProcessShotCuts_Exited;

            // Start process
            processShotCuts.Start();
            processShotCuts.BeginOutputReadLine();
            processShotCuts.BeginErrorReadLine();
            Application.DoEvents();
            
            // Set progress bar
            progressBarShotCuts.Value = 0;
            progressBarShotCuts.Style = ProgressBarStyle.Marquee;
            buttonClearShotCuts.Enabled = false;

            // Set progress label
            labelProgress.Text = "Detecting shot cuts: 00:00:00 / 00:00:00";

            // Clear output
            this.shotCuts.Clear();

            Debug.WriteLine("### START " + DateTime.Now.ToString());
        }

        private void ProcessShotCuts_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.WriteLine("[INFO] " + e.Data);

            // Handle output
            HandleProcessShotCutsOutput(e.Data);

            // Trigger Process_Exited
            if (processShotCuts.ExitCode >= 0) { }
        }

        private void ProcessShotCuts_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.WriteLine("[ERROR] " + e.Data);

            // Save error
            if (e.Data != null && e.Data != "")
            {
                lastError = e.Data;
            }

            // Handle output (FFmpeg sends regular output as error data)
            HandleProcessShotCutsOutput(e.Data);
        }

        private void ProcessShotCuts_Exited(object sender, EventArgs e)
        {
            Debug.WriteLine("[EXIT] " + processShotCuts.ExitCode);

            // Handle exit
            HandleProcessShotCutsExit(processShotCuts.ExitCode);
        }


        // Functions

        private void HandleProcessShotCutsOutput(string line)
        {
            // Check if line is not empty
            if (line != null && line != "")
            {
                if (line.Contains("Duration:"))
                {
                    // Duration info

                    // Get the duration
                    int startIndex = line.IndexOf("Duration:") + "Duration:".Length;
                    int length = line.IndexOf(",") - startIndex;
                    string durationString = line.Substring(startIndex, length).Trim();

                    // Set duration
                    duration = TimeSpan.Parse(durationString).TotalSeconds;

                    // Update progress bar
                    progressBarShotCuts.Invoke(new MethodInvoker(() =>
                    {
                        progressBarShotCuts.Style = ProgressBarStyle.Blocks;
                        progressBarShotCuts.Maximum = (int)duration;
                    }));

                    // Update progress label
                    labelProgress.Invoke(new MethodInvoker(() =>
                    {
                        labelProgress.Text = "Detecting shot cuts: 00:00:00 / " + FormatSeconds(duration);
                    }));
                }
                else if (line.Contains("time="))
                {
                    // Progress info

                    // Get the time
                    int startIndex = line.IndexOf("time=") + "time=".Length;
                    int length = line.IndexOf("bitrate=") - startIndex;
                    string timeString = line.Substring(startIndex, length).Trim();

                    // Convert it
                    double time = TimeSpan.Parse(timeString).TotalSeconds;

                    // Update progress bar
                    progressBarShotCuts.Invoke(new MethodInvoker(() =>
                    {
                        progressBarShotCuts.Value = (int)time;
                    }));

                    // Update progress label
                    labelProgress.Invoke(new MethodInvoker(() =>
                    {
                        labelProgress.Text = "Detecting shot cuts: " + FormatSeconds(time) + " / " + FormatSeconds(duration);
                    }));
                }
                else if (line.Contains("pts_time:"))
                {
                    // Scene change info

                    // Get the time
                    int startIndex = line.IndexOf("pts_time:") + "pts_time:".Length;
                    int length = line.IndexOf("pos:") - startIndex;
                    string timeString = line.Substring(startIndex, length).Trim();

                    // Convert it
                    double time = Double.Parse(timeString.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)) * 1000;

                    // Add it
                    this.shotCuts.Add(time);
                }
            }
        }

        private void HandleProcessShotCutsExit(int exitCode)
        {
            Debug.WriteLine("### END " + DateTime.Now.ToString());

            // Re-enable form
            this.Invoke(new MethodInvoker(() =>
            {
                this.Enabled = true;
            }));

            // Check exit code and show message
            if (processShotCuts.ExitCode == 0)
            {
                // Success!

                // Fill progress bar
                progressBarShotCuts.Invoke(new MethodInvoker(() =>
                {
                    progressBarShotCuts.Style = ProgressBarStyle.Blocks;
                    progressBarShotCuts.Value = progressBarShotCuts.Maximum;
                }));

                double frameMs = this.timeCodes[1] - this.timeCodes[0];
                double thisShotCut, previousShotCut;

                // Update progress label
                labelProgress.Invoke(new MethodInvoker(() =>
                {
                    labelProgress.Text = "Processing shot cuts...";
                }));

                // Process shot cuts
                for (int i = 1; i < this.shotCuts.Count; i++)
                {
                    thisShotCut = this.timeCodes.Aggregate((x, y) => Math.Abs(x - this.shotCuts[i]) < Math.Abs(y - this.shotCuts[i]) ? x : y);
                    previousShotCut = this.timeCodes.Aggregate((x, y) => Math.Abs(x - this.shotCuts[i - 1]) < Math.Abs(y - this.shotCuts[i - 1]) ? x : y);

                    if (thisShotCut - previousShotCut <= frameMs + 1.0)
                    {
                        this.shotCuts.Remove(this.shotCuts[i]);
                    }
                }

                // Write file
                File.WriteAllLines(GetShotCutsFilePath(), this.shotCuts.Select(x => x.ToString()).ToArray(), Encoding.Default);

                // Update progress label
                labelProgress.Invoke(new MethodInvoker(() =>
                {
                    labelProgress.Text = "Done!";
                }));

                // Restore UI
                progressBarShotCuts.Invoke(new MethodInvoker(() =>
                {
                    RestoreUI(true, false);
                }));
            }
            else
            {
                // Error!

                // Reset progress bar
                progressBarShotCuts.Invoke(new MethodInvoker(() =>
                {
                    progressBarShotCuts.Style = ProgressBarStyle.Blocks;
                }));

                // Show message
                MessageBox.Show("An error occurred.\n\n" + lastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Restore UI
                progressBarShotCuts.Invoke(new MethodInvoker(() =>
                {
                    RestoreUI(false, false);
                }));
            }
        }

        private void RestoreUI(bool success, bool loaded)
        {
            // Restore everything
            buttonAnalyze.Enabled = true;            
            checkBoxShotCuts.Enabled = true;
            buttonImportShotCuts.Enabled = true;
            buttonGo.Enabled = success;
            labelVideo.Enabled = true;
            textBoxVideo.Enabled = true;
            buttonBrowse.Enabled = true;
            buttonCancel.Visible = false;
            labelProgress.Text = "Ready.";

            // Restore correctly
            checkBoxShotCuts_CheckedChanged(checkBoxShotCuts, new EventArgs());
            checkBoxAlignFreeOutCuesToShotCuts_CheckedChanged(checkBoxAlignFreeOutCuesToShotCuts, new EventArgs());
            checkBoxOvershootShotCuts_CheckedChanged(checkBoxOvershootShotCuts, new EventArgs());
            checkBoxExtend_CheckedChanged(checkBoxExtend, new EventArgs());

            if (success)
            {
                // Disable analyze button
                buttonAnalyze.Enabled = false;
                checkBoxShotCuts.Enabled = false;
                labelThreshold.Enabled = false;
                trackBarThreshold.Enabled = false;
                numericUpDownThreshold.Enabled = false;
                buttonImportShotCuts.Enabled = false;

                // Toggle clear buttons
                buttonClearTimeCodes.Enabled = progressBarTimeCodes.Value == progressBarTimeCodes.Maximum;
                buttonClearShotCuts.Enabled = progressBarShotCuts.Value == progressBarShotCuts.Maximum;

                if (loaded)
                {
                    MessageBox.Show("Done!\n\nTime codes and " + this.shotCuts.Count + " shot cuts loaded.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (checkBoxShotCuts.Checked && !this.shotCutsImported)
                    {
                        MessageBox.Show("Done!\n\n" + this.shotCuts.Count + " shot cuts detected.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        buttonExportShotCuts.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Done!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            
            // Check time codes
            CheckShotCuts();
        }


        // Helper functions

        private string FormatSeconds(double seconds)
        {
            TimeSpan t = TimeSpan.FromSeconds(seconds);
            return t.ToString(@"hh\:mm\:ss");
        }

        private Encoding GetEncoding(string filename)
        {
            using (var reader = new StreamReader(filename, Encoding.Default, true))
            {
                reader.Peek(); // you need this!
                return reader.CurrentEncoding;
            }
        }
    }
}
