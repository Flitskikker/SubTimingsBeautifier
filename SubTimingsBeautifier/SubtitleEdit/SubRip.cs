﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Nikse.SubtitleEdit.PluginLogic
{
    internal class SubRip
    {
        private static readonly Regex RegexTimeCodes = new Regex(@"^-?\d+:-?\d+:-?\d+[:,]-?\d+\s*-->\s*-?\d+:-?\d+:-?\d+[:,]-?\d+$", RegexOptions.Compiled);
        private static readonly Regex RegexTimeCodes2 = new Regex(@"^\d+:\d+:\d+,\d+\s*-->\s*\d+:\d+:\d+,\d+$", RegexOptions.Compiled);
        private ExpectingLine _expecting = ExpectingLine.Number;
        private int _lineNumber;
        private Paragraph _paragraph;
        private int _errorCount;

        private enum ExpectingLine
        {
            Number,
            TimeCodes,
            Text
        }

        public List<string> AlternateExtensions
        {
            get
            {
                return new List<string> { ".wsrt" };
            }
        }

        public string Errors { get; private set; }

        public string Extension
        {
            get { return ".srt"; }
        }

        public bool IsTimeBased
        {
            get { return true; }
        }

        public string Name
        {
            get { return "SubRip"; }
        }

        public int ErrorCount
        {
            get
            {
                return _errorCount;
            }
        }

        public void LoadSubtitle(Subtitle subtitle, string[] lines, string fileName)
        {
            bool doRenum = false;
            _lineNumber = 0;

            _paragraph = new Paragraph();
            _expecting = ExpectingLine.Number;
            _errorCount = 0;

            subtitle.Paragraphs.Clear();
            for (int i = 0; i < lines.Length; i++)
            {
                _lineNumber++;
                string line = lines[i].TrimEnd();
                line = line.Trim(Convert.ToChar(127)); // 127=delete acscii

                string next = string.Empty;
                if (i + 1 < lines.Length)
                    next = lines[i + 1];

                // A new line is missing between two paragraphs (buggy srt file)
                if (_expecting == ExpectingLine.Text && i + 1 < lines.Length &&
                    _paragraph != null && !string.IsNullOrEmpty(_paragraph.Text) && Utilities.IsInteger(line) &&
                    RegexTimeCodes.IsMatch(lines[i + 1]))
                {
                    _errorCount++;
                    ReadLine(subtitle, string.Empty, string.Empty);
                }
                if (_expecting == ExpectingLine.Number && RegexTimeCodes.IsMatch(line))
                {
                    _errorCount++;
                    _expecting = ExpectingLine.TimeCodes;
                    doRenum = true;
                }
                ReadLine(subtitle, line, next);
            }

            if (_paragraph.Text.Trim().Length > 0)
                subtitle.Paragraphs.Add(_paragraph);

            foreach (Paragraph p in subtitle.Paragraphs)
            {
                p.Text = p.Text.Replace(Environment.NewLine + Environment.NewLine, Environment.NewLine);
            }
            if (_errorCount < 100 && doRenum)
            {
                subtitle.Renumber(1);
            }
            Errors = _errorCount.ToString();
        }

        public string ToText(IEnumerable<Paragraph> paragraphs)
        {
            const string paragraphWriteFormat = "{0}\r\n{1} --> {2}\r\n{3}\r\n\r\n";
            var sb = new StringBuilder();
            foreach (Paragraph p in paragraphs)
            {
                var s = p.Text
                    .Replace(Environment.NewLine + Environment.NewLine, Environment.NewLine)
                    .Replace(Environment.NewLine + Environment.NewLine, Environment.NewLine);
                sb.AppendFormat(paragraphWriteFormat, p.Number, p.StartTime, p.EndTime, s);
            }
            return sb.ToString();
        }

        private bool IsText(string text)
        {
            return !(string.IsNullOrWhiteSpace(text) || Utilities.IsInteger(text) || RegexTimeCodes.IsMatch(text));
        }

        private void ReadLine(Subtitle subtitle, string line, string next)
        {
            switch (_expecting)
            {
                case ExpectingLine.Number:
                    if (Utilities.IsInteger(line))
                    {
                        _paragraph.Number = int.Parse(line);
                        _expecting = ExpectingLine.TimeCodes;
                    }
                    else if (line.Trim().Length > 0)
                    {
                        _errorCount++;
                    }
                    break;

                case ExpectingLine.TimeCodes:
                    if (TryReadTimeCodesLine(line, _paragraph))
                    {
                        _paragraph.Text = string.Empty;
                        _expecting = ExpectingLine.Text;
                    }
                    else if (line.Trim().Length > 0)
                    {
                        _errorCount++;
                        _expecting = ExpectingLine.Number; // lets go to next paragraph
                    }
                    break;

                case ExpectingLine.Text:
                    if (line.Trim().Length > 0)
                    {
                        if (_paragraph.Text.Length > 0)
                            _paragraph.Text += Environment.NewLine;
                        _paragraph.Text += RemoveBadChars(line).TrimEnd().Replace(Environment.NewLine + Environment.NewLine, Environment.NewLine);
                    }
                    else if (IsText(next))
                    {
                        if (_paragraph.Text.Length > 0)
                            _paragraph.Text += Environment.NewLine;
                        _paragraph.Text += RemoveBadChars(line).TrimEnd().Replace(Environment.NewLine + Environment.NewLine, Environment.NewLine);
                    }
                    else if (string.IsNullOrEmpty(line) && string.IsNullOrEmpty(_paragraph.Text))
                    {
                        _paragraph.Text = string.Empty;
                        if (!string.IsNullOrEmpty(next) && (Utilities.IsInteger(next) || RegexTimeCodes.IsMatch(next)))
                        {
                            subtitle.Paragraphs.Add(_paragraph);
                            _paragraph = new Paragraph();
                            _expecting = ExpectingLine.Number;
                        }
                    }
                    else
                    {
                        subtitle.Paragraphs.Add(_paragraph);
                        _paragraph = new Paragraph();
                        _expecting = ExpectingLine.Number;
                    }
                    break;
            }
        }

        private string RemoveBadChars(string line) => line.Replace('\0', ' ');

        private bool TryReadTimeCodesLine(string line, Paragraph paragraph)
        {
            line = line.Replace('،', ',');
            line = line.Replace('', ',');
            line = line.Replace('¡', ',');

            const string defaultSeparator = " --> ";
            // Fix some badly formatted separator sequences - anything can happen if you manually edit ;)
            line = line.Replace(" -> ", defaultSeparator); // I've seen this
            line = line.Replace(" - > ", defaultSeparator);
            line = line.Replace(" ->> ", defaultSeparator);
            line = line.Replace(" -- > ", defaultSeparator);
            line = line.Replace(" - -> ", defaultSeparator);
            line = line.Replace(" -->> ", defaultSeparator);
            line = line.Replace(" ---> ", defaultSeparator);

            // Removed stuff after timecodes - like subtitle position
            // - example of position info: 00:02:26,407 --> 00:02:31,356  X1:100 X2:100 Y1:100 Y2:100
            if (line.Length > 30 && line[29] == ' ')
                line = line.Substring(0, 29);

            // removes all extra spaces
            line = line.Replace(" ", string.Empty).Replace("-->", defaultSeparator);
            line = line.Trim();

            // Fix a few more cases of wrong time codes, seen this: 00.00.02,000 --> 00.00.04,000
            line = line.Replace('.', ':');
            if (line.Length >= 29 && ":;".Contains(line[8].ToString()))
                line = line.Substring(0, 8) + ',' + line.Substring(8 + 1);
            if (line.Length >= 29 && line.Length <= 30 && ":;".Contains(line[25].ToString()))
                line = line.Substring(0, 25) + ',' + line.Substring(25 + 1);

            if (RegexTimeCodes.IsMatch(line) || RegexTimeCodes2.IsMatch(line))
            {
                string[] parts = line.Replace("-->", ":").Replace(" ", string.Empty).Split(':', ',');
                try
                {
                    // start time
                    int startHours = int.Parse(parts[0]);
                    int startMinutes = int.Parse(parts[1]);
                    int startSeconds = int.Parse(parts[2]);
                    int startMilliseconds = int.Parse(parts[3]);

                    // endTime
                    int endHours = int.Parse(parts[4]);
                    int endMinutes = int.Parse(parts[5]);
                    int endSeconds = int.Parse(parts[6]);
                    int endMilliseconds = int.Parse(parts[7]);

                    paragraph.StartTime = new TimeCode(startHours, startMinutes, startSeconds, startMilliseconds);
                    paragraph.EndTime = new TimeCode(endHours, endMinutes, endSeconds, endMilliseconds);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}