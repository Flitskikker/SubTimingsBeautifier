﻿using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Nikse.SubtitleEdit.PluginLogic
{
    public static class Utilities
    {
        #region Extension Methods

        public static string[] SplitToLines(this string s)
        {
            return s.Replace(Environment.NewLine, "\n").Replace('\r', '\n').Split('\n');
        }
        public static bool StartsWith(this string s, char c)
        {
            return s.Length > 0 && s[0] == c;
        }
        public static bool EndsWith(this string s, char c)
        {
            return s.Length > 0 && s[s.Length - 1] == c;
        }
        public static bool Contains(this string s, char c)
        {
            return s.Length > 0 && s.IndexOf(c) >= 0;
        }

        #endregion

        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public static bool IsInteger(string s)
        {
            int i;
            if (int.TryParse(s, out i))
                return true;
            return false;
        }

        public static string RemoveHtmlTags(string s, bool alsoSsa )
        {
            if (string.IsNullOrEmpty(s))
                return null;

            int idx;
            if (alsoSsa)
            {
                const string SSA = "{\\";
                idx = s.IndexOf(SSA, StringComparison.Ordinal);
                while (idx >= 0)
                {
                    var endIdx = s.IndexOf('}', idx + 2);
                    if (endIdx < idx)
                        break;
                    s = s.Remove(idx, endIdx - idx + 1);
                    idx = s.IndexOf(SSA);
                }
            }

            idx = s.IndexOf('<');
            return Regex.Replace(s, "(?i)</?[iіbu]>", string.Empty);
        }

        public static int GetNumberOfLines(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            var totalLines = 1;
            var idx = s.IndexOf('\n');
            while (idx >= 0)
            {
                totalLines++;
                idx = s.IndexOf('\n', idx + 1);
            }
            return totalLines;
        }

        public static int CountTagInText(string text, string tag)
        {
            int count = 0;
            int index = text.IndexOf(tag, StringComparison.Ordinal);
            while (index >= 0)
            {
                count++;
                index = index + tag.Length;
                if (index >= text.Length)
                    return count;
                index = text.IndexOf(tag, index, StringComparison.Ordinal);
            }
            return count;
        }

        public static int CountTagInText(string text, char tag)
        {
            int count = 0;
            int index = text.IndexOf(tag);
            while (index >= 0)
            {
                count++;
                if ((index + 1) == text.Length)
                    return count;
                index = text.IndexOf(tag, index + 1);
            }
            return count;
        }


    }
}