using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SubTimingsBeautifier
{
    public partial class FormImportShotCuts : Form
    {
        public FormImportShotCuts()
        {
            InitializeComponent();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            // Show open file dialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Read lines
                string[] lines = File.ReadAllLines(openFileDialog.FileName);

                // Check if EZTitles shotcut xml
                if (lines.Length > 2 && lines[1].Contains("EZTitles") && lines[2] == "<shotchanges version=\"1.0\">")
                {                    
                    try
                    {
                        // Create list
                        List<double> shotChanges = new List<double>();

                        // Parse XML
                        XmlDocument document = new XmlDocument();
                        document.LoadXml(String.Join(Environment.NewLine, lines));

                        // Get framerate
                        double frameRate = Double.Parse(document.DocumentElement.SelectSingleNode("/shotchanges/video/frame_rate").InnerText);
                        double frameNumber;

                        // Get frame list
                        foreach (XmlNode node in document.DocumentElement.SelectNodes("/shotchanges/shotchanges_list/shotchange"))
                        {
                            // Get frame number
                            frameNumber = Double.Parse(node.Attributes["frame"].InnerText);

                            // Add converted time
                            shotChanges.Add((frameNumber / frameRate) * 1000);
                        }

                        // Set mode
                        radioButtonMilliseconds.Checked = true;

                        // Add to set box
                        textBoxTimecodes.Lines = shotChanges.Select(x => x.ToString()).ToArray();
                    }
                    catch
                    {
                        // Show error
                        MessageBox.Show("Failed to parse shotchanges file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Regular file, just import it
                    textBoxTimecodes.Lines = lines;
                }
            }
        }
    }
}
