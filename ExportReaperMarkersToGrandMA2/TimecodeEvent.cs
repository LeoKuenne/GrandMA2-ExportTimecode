using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportReaperMarkersToGrandMA2
{
    class TimecodeEvent
    {
        string Name { get; set; }
        int Time { get; set; }
        string Cue { get; set; }
        
        public TimecodeEvent(string n, int t, string c)
        {
            this.Name = n;
            this.Time = t;
            this.Cue = c;
        }

        public static TimecodeEvent parseCSV(string v, string[] names, int fps)
        {
            string[] values = v.Split(',');
            int posName = Array.IndexOf(names, "Name");
            int posTime = Array.IndexOf(names, "Start");
            int posCount = Array.IndexOf(names, "#");

            //HH:MM:SS:FF
            string[] t = values[posTime].Split(':');
            int frames = int.Parse(t[3]);
            int seconds = int.Parse(t[2]) * 30;
            int minutes = int.Parse(t[1]) * 30 * 60;
            int hours = int.Parse(t[0]) * 30 * 60 * 60;
            int time = frames + seconds + minutes + hours;


            return new TimecodeEvent(values[posName], time, values[posCount].Substring(1));
        }

        public override String ToString()
        {
            return Name + ";" + Time + ";" + Cue;
        }
    }
}
