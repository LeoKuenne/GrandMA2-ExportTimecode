using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExportReaperMarkersToGrandMA2
{
    
    public enum TimecodeEventTrigger
    {
        Go,
        Goto
    }

    public class TimecodeEvent
    {

        [Browsable(false)]
        public TimelineFormat TimelineFormat { get; set; }
        [Browsable(false)]
        public int Index { get; set; }
        [Browsable(false)]
        public int Seq { get; set; }

        public int Cue { get; set; }
        public string Name { get; set; }
        public Timestamp Time { get; set; }
        public TimecodeEventTrigger trigger { get; set; }

        private FPS FrameRate;


        public TimecodeEvent() { }

        public TimecodeEvent(int index, int seqitem, int cue, string name, int fps, TimecodeEventTrigger trigger)
        {
            this.Name = name;
            this.Seq = seqitem;
            this.Cue = cue;
            this.Index = index;
            this.trigger = trigger;
        }

        public static TimecodeEvent ParseCSV(int index, string valuesText, string[] names, TimelineFormat timelineFormat, int page, int seq, FPS fps, TimecodeEventTrigger defaulttrigger)
        {
            
            string[] values = valuesText.Split(',');
            int posName = Array.IndexOf(names, "Name");
            int posTime = Array.IndexOf(names, "Start");
            int posCount = Array.IndexOf(names, "#");
            
            TimecodeEvent e = new TimecodeEvent();
            e.TimelineFormat = timelineFormat;
            e.Time = Timestamp.parseTimestamp(values[posTime], timelineFormat, fps);
            e.Name = values[posName];
            e.Seq = seq;
            e.Cue = int.Parse(values[posCount].Substring(1));
            e.Index = index;
            e.FrameRate = fps;
            e.trigger = defaulttrigger;
            
            return e;
        }

        public FPS GetFps()
        {
            return FrameRate;
        }

        public void SetFps(FPS value)
        {
            FrameRate = value;
        }
        
        public override String ToString()
        {
            return Name + ";" + Time.ToString() + ";" + Cue;
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
            nodeEvent_Time.Value = Time.GetFrameWithFPS((FPS)30).ToString();


            XmlAttribute nodeEvent_Step = doc.CreateAttribute("step");
            nodeEvent_Step.Value = (Index+1).ToString();

            XmlAttribute nodeEvent_Command = doc.CreateAttribute("command");
            nodeEvent_Command.Value = trigger.ToString();

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