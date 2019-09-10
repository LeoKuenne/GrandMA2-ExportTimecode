using System;
using System.Runtime.Serialization;

[Serializable]
internal class TelnetConnectionException : Exception
{
    public const int Refused = 1;
    public const int LOGIN_INCORRECT = 2;

    public int state { get; set; }

    public TelnetConnectionException()
    {
    }

    public TelnetConnectionException(int state)
    {
        this.state = state;
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