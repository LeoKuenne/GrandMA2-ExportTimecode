using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExportReaperMarkersToGrandMA2
{
    class TimecodeEvent
    {
        string Name { get; set; }
        int Time { get; set; }
        int Page { get; set; }
        int Seq { get; set; }
        int Cue { get; set; }
        int Index { get; set; }
        
        public TimecodeEvent(string n, int t, int s, int c, int i, int p)
        {
            this.Name = n;
            this.Time = t;
            this.Seq = s;
            this.Cue = c;
            this.Page = p;
            this.Index = i;
        }

        public static TimecodeEvent parseCSV(string v, string[] names, int fps, int index, int seq, int page)
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


            return new TimecodeEvent(values[posName], time, seq, int.Parse(values[posCount].Substring(1)), index, page);
        }

        public override String ToString()
        {
            return Name + ";" + Time + ";" + Cue;
        }

        public void writeXML(XmlNode nodeparent, XmlDocument doc)
        {
            XmlNode nodeEvent = doc.CreateElement("Event");
            XmlAttribute nodeEvent_Index = doc.CreateAttribute("index");
            nodeEvent_Index.Value = Index.ToString();

            XmlAttribute nodeEvent_Time = doc.CreateAttribute("time");
            nodeEvent_Time.Value = Time.ToString();

            XmlAttribute nodeEvent_Step = doc.CreateAttribute("step");
            nodeEvent_Step.Value = (Index++).ToString();

            XmlAttribute nodeEvent_Command = doc.CreateAttribute("command");
            nodeEvent_Command.Value = "Goto";


            nodeEvent.Attributes.Append(nodeEvent_Index);
            nodeEvent.Attributes.Append(nodeEvent_Time);
            nodeEvent.Attributes.Append(nodeEvent_Step);
            nodeEvent.Attributes.Append(nodeEvent_Command);
            nodeparent.AppendChild(nodeEvent);

            XmlNode nodeCue = doc.CreateElement("Cue");
            XmlAttribute nodeCue_Name = doc.CreateAttribute("name");
            nodeCue_Name.Value = Name;

            nodeCue.Attributes.Append(nodeCue_Name);
            nodeEvent.AppendChild(nodeCue);

            XmlNode nodeNoPage = doc.CreateElement("No");
            nodeNoPage.InnerText = Page.ToString();
            XmlNode nodeNoSeq = doc.CreateElement("No");
            nodeNoSeq.InnerText = Seq.ToString();
            XmlNode nodeNoCue = doc.CreateElement("No");
            nodeNoCue.InnerText = Cue.ToString();

            nodeCue.AppendChild(nodeNoPage);
            nodeCue.AppendChild(nodeNoSeq);
            nodeCue.AppendChild(nodeNoCue);


        }
    }
}