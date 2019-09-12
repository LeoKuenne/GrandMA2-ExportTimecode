using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SFTP
{
    class SFTPConnectionException : Exception
    {
       
        public FTPConnectionStatus State { get; set; }

        public SFTPConnectionException()
        {
        }

        public SFTPConnectionException(FTPConnectionStatus state)
        {
            this.State = state;
        }

        public SFTPConnectionException(string message) : base(message)
    {
        }

        public SFTPConnectionException(string message, Exception innerException) : base(message, innerException)
    {
        }

        protected SFTPConnectionException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
        }

    }
}