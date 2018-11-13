using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportReaperMarkersToGrandMA2
{
    class Timecode
    {
        TimecodeEvent[] timecodeEvents { get; set; }

        string Seq { get; set; }
        string SeqName { get; set; }
        int FrameRate { get; set; }

        public Timecode(string s, string sname, int framerate)
        {
            this.Seq = s;
            this.SeqName = sname;
            this.FrameRate = framerate;

        }

        public void parseCSV(string[] csvtext)
        {
            string[] names = csvtext[0].Split(',');

            timecodeEvents = new TimecodeEvent[csvtext.Length-1];

            for (int i = 0; i < csvtext.Length-1; i++)
            {
                timecodeEvents[i] = TimecodeEvent.parseCSV(csvtext[i+1], names, FrameRate);
            }

        }

    }
}
