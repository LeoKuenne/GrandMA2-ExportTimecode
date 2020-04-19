using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExportReaperMarkersToGrandMA2
{
    public class TimelineFormatException : Exception
    {
        public TimelineFormatException()
        {
        }
    
        public TimelineFormatException(string message) : base(message)
        {
        }

        public TimelineFormatException(string message, Exception innerException) : base(message, innerException)
        { 
        }

        protected TimelineFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

}
