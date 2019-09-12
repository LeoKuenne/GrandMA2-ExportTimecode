using System;
using System.Runtime.Serialization;

namespace Telnet
{
    [Serializable]
    internal class TelnetConnectionException : Exception
    {

        public TelnetConnectionStatus State { get; set; }

        public TelnetConnectionException()
        {
        }

        public TelnetConnectionException(TelnetConnectionStatus state)
        {
            this.State = state;
        }

        public TelnetConnectionException(string message) : base(message)
        {
        }

        public TelnetConnectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TelnetConnectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

    }
}