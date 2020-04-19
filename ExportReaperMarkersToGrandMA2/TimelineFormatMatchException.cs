using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExportReaperMarkersToGrandMA2
{
    public class TimelineFormatMatchException : TimelineFormatException
    {
        public TimelineFormat Excepted;
        public string ActualTimeline;

        public TimelineFormatMatchException(TimelineFormat excepted)
        {
            this.Excepted = excepted;
        }

        public TimelineFormatMatchException(TimelineFormat excepted, string actualTimeline)
        {
            this.Excepted = excepted;
            this.ActualTimeline = actualTimeline;
        }
    }

}
