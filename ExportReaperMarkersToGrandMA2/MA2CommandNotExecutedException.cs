using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportReaperMarkersToGrandMA2
{
    [Serializable]
    class MA2CommandNotExecutedException : Exception
    {

        public string command { get; set; }
        public string error { get; set; }

        public MA2CommandNotExecutedException(string command, string error)
        {
            this.command = command;
            this.error = error;
        }

        public MA2CommandNotExecutedException(string message)
        : base(message)
        {
            error = message;
        }

        public MA2CommandNotExecutedException(string message, Exception inner)
        : base(message, inner)
        {

        }

    }
}