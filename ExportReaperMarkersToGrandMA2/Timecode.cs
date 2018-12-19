using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExportReaperMarkersToGrandMA2
{
    class Timecode
    {
        public TimecodeEvent[] timecodeEvents { get; set; }
        
        private int Page;
        private int Exec;
        private int Seq;
        private string SeqName;
        private int Tc;
        private string TcName;
        private int FrameRate;
        private string defaultTrigger;


        public Timecode(int page, int exec, int seq, string seqname, int tc, string tcname, int framerate, string defaultTrigger)
        {
            this.Page = page;
            this.Exec = exec;
            this.Seq = seq;
            this.SeqName = seqname;
            this.Tc = tc;
            this.TcName = tcname;
            this.FrameRate = framerate;
            this.defaultTrigger = defaultTrigger;
        }

        public bool ParseCSV(string[] csvtext)
        {
            string[] names = csvtext[0].Split(',');

            timecodeEvents = new TimecodeEvent[csvtext.Length-1];

            try
            {
                for (int i = 0; i < csvtext.Length-1; i++)
                {
                    timecodeEvents[i] = TimecodeEvent.ParseCSV(i, csvtext[i + 1], names, GetPage(), GetSeq(), GetFrameRate(), defaultTrigger);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public void save(String path)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "UTF-8",null));
            xmlDoc.AppendChild(xmlDoc.CreateProcessingInstruction("xml-stylesheet", "type='text/xsl' href='styles/timecode@sheet.xsl'"));

            XmlNode nodeMA = xmlDoc.CreateElement("MA");

            XmlAttribute nodeMAAttribute_XMLNSXSI = xmlDoc.CreateAttribute("xmlns:xsi");
            nodeMAAttribute_XMLNSXSI.Value = "http://www.w3.org/2001/XMLSchema-instance";

            XmlAttribute nodeMAAttribute_XMLNS = xmlDoc.CreateAttribute("xmlns");
            nodeMAAttribute_XMLNS.Value = "http://schemas.malighting.de/grandma2/xml/MA";

            XmlAttribute nodeMAAttribute_XSI = xmlDoc.CreateAttribute("xsi:schemaLocation");
            nodeMAAttribute_XSI.Value = "http://schemas.malighting.de/grandma2/xml/MA http://schemas.malighting.de/grandma2/xml/3.4.0/MA.xsd";

            nodeMA.Attributes.Append(nodeMAAttribute_XMLNS);
            nodeMA.Attributes.Append(nodeMAAttribute_XMLNSXSI);
            nodeMA.Attributes.Append(nodeMAAttribute_XSI);
            xmlDoc.AppendChild(nodeMA);

            XmlNode nodeInfo = xmlDoc.CreateElement("Info");
            XmlAttribute nodeInfoAttribute_DateTime = xmlDoc.CreateAttribute("index");
            nodeInfoAttribute_DateTime.Value = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

            XmlAttribute nodeInfoAttribute_Showfile = xmlDoc.CreateAttribute("name");
            nodeInfoAttribute_Showfile.Value = "ExportReaperMarkerToGrandMA2";

            nodeInfo.Attributes.Append(nodeInfoAttribute_DateTime);
            nodeInfo.Attributes.Append(nodeInfoAttribute_Showfile);
            nodeMA.AppendChild(nodeInfo);


            XmlNode nodeTimecode = xmlDoc.CreateElement("Timecode");
            XmlAttribute nodeTimecodeAttribute_Index = xmlDoc.CreateAttribute("index");
            nodeTimecodeAttribute_Index.Value = "0";

            XmlAttribute nodeTimecodeAttribute_Name = xmlDoc.CreateAttribute("name");
            nodeTimecodeAttribute_Name.Value = GetTcName();

            XmlAttribute nodeTimecodeAttribute_FramRate = xmlDoc.CreateAttribute("frame_format");
            nodeTimecodeAttribute_FramRate.Value = GetFrameRate().ToString() + " FPS";

            nodeTimecode.Attributes.Append(nodeTimecodeAttribute_Index);
            nodeTimecode.Attributes.Append(nodeTimecodeAttribute_Name);
            nodeTimecode.Attributes.Append(nodeTimecodeAttribute_FramRate);
            nodeMA.AppendChild(nodeTimecode);

            XmlNode nodeTrack = xmlDoc.CreateElement("Track");
            XmlAttribute nodeTrackAttribute_Index = xmlDoc.CreateAttribute("index");
            nodeTrackAttribute_Index.Value = "0";

            nodeTrack.Attributes.Append(nodeTrackAttribute_Index);
            nodeTimecode.AppendChild(nodeTrack);

            XmlNode nodeTrackObject = xmlDoc.CreateElement("Object");
            XmlAttribute nodeTrackObjectAttribute_Name = xmlDoc.CreateAttribute("name");
            nodeTrackObjectAttribute_Name.Value = GetSeqName();

            nodeTrackObject.Attributes.Append(nodeTrackObjectAttribute_Name);
            nodeTrack.AppendChild(nodeTrackObject);


            XmlNode nodeNo30 = xmlDoc.CreateElement("No");
            nodeNo30.InnerText = "30";
            XmlNode nodeNoConsole = xmlDoc.CreateElement("No");
            nodeNoConsole.InnerText = "1";

            XmlNode nodeNoPage = xmlDoc.CreateElement("No");
            nodeNoPage.InnerText = GetPage().ToString();
            XmlNode nodeNoExec = xmlDoc.CreateElement("No");
            nodeNoExec.InnerText = GetExec().ToString();


            nodeTrackObject.AppendChild(nodeNo30);
            nodeTrackObject.AppendChild(nodeNoConsole);
            nodeTrackObject.AppendChild(nodeNoPage);
            nodeTrackObject.AppendChild(nodeNoExec);


            XmlNode nodeSubTrack = xmlDoc.CreateElement("SubTrack");
            XmlAttribute nodeSubTrackAttribute_Index = xmlDoc.CreateAttribute("index");
            nodeSubTrackAttribute_Index.Value = "0";

            nodeSubTrack.Attributes.Append(nodeSubTrackAttribute_Index);
            nodeTrack.AppendChild(nodeSubTrack);

            foreach (TimecodeEvent t in timecodeEvents)
            {
                t.writeXML(nodeSubTrack, xmlDoc);
            }

            xmlDoc.Save(path + "\\" + GetTcName() + ".xml");

        }
        
        public int GetPage()
        {
            return Page;
        }

        public void SetPage(int value)
        {
            this.Page = value;
        }

        public int GetExec()
        {
            return Exec;
        }

        public void SetExec(int value)
        {
            this.Exec = value;
        }

        public int GetSeq()
        {
            return Seq;
        }

        public void SetSeq(int value)
        {
            Seq = value;
            foreach(TimecodeEvent t in timecodeEvents)
            {
                t.Seq = value;
            }
        }

        public string GetSeqName()
        {
            return SeqName;
        }

        public void SetSeqName(string value)
        {
            SeqName = value;
        }

        public int GetTc()
        {
            return Tc;
        }

        public void SetTc(int value)
        {
            Tc = value;
        }

        public string GetTcName()
        {
            return TcName;
        }

        public void SetTcName(string value)
        {
            TcName = value;
        }

        public int GetFrameRate()
        {
            return FrameRate;
        }

        public void SetFrameRate(int value)
        {
            FrameRate = value;
            foreach (TimecodeEvent e in timecodeEvents) e.SetFps(value);
        }

        public string GetDefaultTrigger()
        {
            return defaultTrigger;
        }

        public void SetDefaultTrigger(string value)
        {
            defaultTrigger = value;
            foreach (TimecodeEvent e in timecodeEvents) e.Trigger = value;
        }
    }
}

