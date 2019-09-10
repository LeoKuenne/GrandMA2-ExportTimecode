using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExportReaperMarkersToGrandMA2
{
    public class TimecodeEvent
    {
        public string Name { get; set; }
        public int Time { get; set; }
        public string[] Times { get; set; }
        public int Seq { get; set; }
        public int Cue { get; set; }
        public int Index { get; set; }
        public string Trigger { get; set; }

        private int FrameRate;


        public TimecodeEvent() { }

        public TimecodeEvent(int index, int seqitem, int cue, int time, string name, int fps, string trigger)
        {
            this.Name = name;
            this.Time = time;
            this.Seq = seqitem;
            this.Cue = cue;
            this.Index = index;
            this.Trigger = trigger;
        }

        public static TimecodeEvent ParseCSV(int index, string values, string[] names, int page, int seq, int fps, string defaulttrigger)
        {
            
            string[] Values = values.Split(',');
            int PosName = Array.IndexOf(names, "Name");
            int PosTime = Array.IndexOf(names, "Start");
            int PosCount = Array.IndexOf(names, "#");
            
            //HH:MM:SS:FF
            string[] Times = Values[PosTime].Split(':');
            int Frames = int.Parse(Times[3]);
            int Seconds = int.Parse(Times[2]) * fps;
            int Minutes = int.Parse(Times[1]) * fps * 60;
            int Hours = int.Parse(Times[0]) * fps * 60 * 60;
            int Time = Frames + Seconds + Minutes + Hours;

            TimecodeEvent e = new TimecodeEvent();
            e.Time = Time;
            e.Times = Times;
            e.Name = Values[PosName];
            e.Seq = seq;
            e.Cue = int.Parse(Values[PosCount].Substring(1));
            e.Index = index;
            e.SetFps(fps);
            e.Trigger = defaulttrigger;
            
            return e;
        }

        public int GetFps()
        {
            return FrameRate;
        }

        public void SetFps(int value)
        {
            FrameRate = value;
            int Frames = int.Parse(Times[3]);
            int Seconds = int.Parse(Times[2]) * FrameRate;
            int Minutes = int.Parse(Times[1]) * FrameRate * 60;
            int Hours = int.Parse(Times[0]) * FrameRate * 60 * 60;
            Time = Frames + Seconds + Minutes + Hours;
        }


        public override String ToString()
        {
            return Name + ";" + Time + ";" + Cue;
        }

        private int DateTimeToFrames(DateTime time)
        {
            throw new NotImplementedException();
        }

        private DateTime FramesToDateTime(int time)
        {
            throw new NotImplementedException();
        }

        public void writeXML(XmlNode nodeparent, XmlDocument doc)
        {
            XmlNode nodeEvent = doc.CreateElement("Event");
            XmlAttribute nodeEvent_Index = doc.CreateAttribute("index");
            nodeEvent_Index.Value = Index.ToString();

            XmlAttribute nodeEvent_Time = doc.CreateAttribute("time");
            nodeEvent_Time.Value = Time.ToString();

            XmlAttribute nodeEvent_Step = doc.CreateAttribute("step");
            nodeEvent_Step.Value = (Index+1).ToString();

            XmlAttribute nodeEvent_Command = doc.CreateAttribute("command");
            nodeEvent_Command.Value = Trigger;

            XmlAttribute nodeEvent_Pressed = doc.CreateAttribute("pressed");
            nodeEvent_Pressed.Value = "true";

            nodeEvent.Attributes.Append(nodeEvent_Index);
            nodeEvent.Attributes.Append(nodeEvent_Time);
            nodeEvent.Attributes.Append(nodeEvent_Step);
            nodeEvent.Attributes.Append(nodeEvent_Command);
            nodeEvent.Attributes.Append(nodeEvent_Pressed);
            nodeparent.AppendChild(nodeEvent);

            XmlNode nodeCue = doc.CreateElement("Cue");
            XmlAttribute nodeCue_Name = doc.CreateAttribute("name");
            nodeCue_Name.Value = Name;

            nodeCue.Attributes.Append(nodeCue_Name);
            nodeEvent.AppendChild(nodeCue);

            XmlNode nodeNoPage = doc.CreateElement("No");
            nodeNoPage.InnerText = "1";
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