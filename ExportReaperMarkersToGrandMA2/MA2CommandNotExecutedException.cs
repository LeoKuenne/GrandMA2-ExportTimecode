using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportReaperMarkersToGrandMA2
{
    class MA2CommandNotExecutedException : Exception
    {
        public MA2CommandNotExecutedException()
        {

        }

        public MA2CommandNotExecutedException(string message)
        : base(message)
        {

        }

        public MA2CommandNotExecutedException(string message, Exception inner)
        : base(message, inner)
        {

        }

    }
}