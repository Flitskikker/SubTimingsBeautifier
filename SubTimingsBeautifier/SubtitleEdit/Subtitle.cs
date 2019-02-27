using System.Collections.Generic;

namespace Nikse.SubtitleEdit.PluginLogic
{
    internal class Subtitle
    {
        private List<Paragraph> _paragraphs;

        public Subtitle()
        {
            _paragraphs = new List<Paragraph>();
        }

        public List<Paragraph> Paragraphs
        {
            get
            {
                return _paragraphs;
            }
        }

        public void Renumber(int startNumber = 1)
        {
            if (startNumber < 0)
                startNumber = 1;
            foreach (Paragraph p in _paragraphs)
            {
                p.Number = startNumber++;
            }
        }

        public void ChangeFrameRate(double oldFrameRate, double newFrameRate)
        {
            foreach (Paragraph p in Paragraphs)
            {
                p.StartTime.TotalMilliseconds = (p.StartTime.TotalMilliseconds * oldFrameRate / newFrameRate);
                p.EndTime.TotalMilliseconds = (p.EndTime.TotalMilliseconds * oldFrameRate / newFrameRate);
            }
        }
    }
}
