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
        TimecodeEvent[] timecodeEvents { get; set; }

        int Page { get; set; }
        int Seq { get; set; }
        string SeqName { get; set; }
        int Tc { get; set; }
        string TcName { get; set; }
        int FrameRate { get; set; }

        public Timecode(int p, int s, string sname, int tc, string tcname, int framerate)
        {
            this.Page = p;
            this.Seq = s;
            this.SeqName = sname;
            this.FrameRate = framerate;
            this.Tc = tc;
            this.TcName = tcname;

        }

        public void parseCSV(string[] csvtext)
        {
            string[] names = csvtext[0].Split(',');

            timecodeEvents = new TimecodeEvent[csvtext.Length-1];

            for (int i = 0; i < csvtext.Length-1; i++)
            {
                timecodeEvents[i] = TimecodeEvent.parseCSV(csvtext[i+1], names, FrameRate, i, Seq, Page);
            }

        }

        public void writeXML(String path)
        {
            XmlDocument xmlDoc = new XmlDocument();

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

            XmlNode nodeTimecode = xmlDoc.CreateElement("Timecode");
            XmlAttribute nodeTimecodeAttribute_Index = xmlDoc.CreateAttribute("index");
            nodeTimecodeAttribute_Index.Value = "0";

            XmlAttribute nodeTimecodeAttribute_Name = xmlDoc.CreateAttribute("name");
            nodeTimecodeAttribute_Name.Value = TcName;

            XmlAttribute nodeTimecodeAttribute_FramRate = xmlDoc.CreateAttribute("frame_format");
            nodeTimecodeAttribute_FramRate.Value = FrameRate.ToString() + " FPS";

            nodeTimecode.Attributes.Append(nodeTimecodeAttribute_Index);
            nodeTimecode.Attributes.Append(nodeTimecodeAttribute_Name);
            nodeTimecode.Attributes.Append(nodeTimecodeAttribute_FramRate);
            nodeMA.AppendChild(nodeTimecode);

            XmlNode nodeTrack = xmlDoc.CreateElement("Track");
            XmlAttribute nodeTrackAttribute_Index = xmlDoc.CreateAttribute("index");
            nodeTrackAttribute_Index.Value = "0";

            nodeTrack.Attributes.Append(nodeTrackAttribute_Index);
            nodeTimecode.AppendChild(nodeTrack);

            XmlNode nodeSubTrack = xmlDoc.CreateElement("SubTrack");
            XmlAttribute nodeSubTrackAttribute_Index = xmlDoc.CreateAttribute("index");
            nodeSubTrackAttribute_Index.Value = "0";

            nodeSubTrack.Attributes.Append(nodeSubTrackAttribute_Index);
            nodeTrack.AppendChild(nodeSubTrack);

            foreach (TimecodeEvent t in timecodeEvents)
            {
                t.writeXML(nodeSubTrack, xmlDoc);
            }

            xmlDoc.Save(path + "\\" + TcName+".xml");

        }
    }
}

