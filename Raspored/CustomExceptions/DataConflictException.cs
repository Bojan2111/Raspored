using System;

namespace Raspored.CustomExceptions
{
    public class DataConflictException : Exception
    {
        public DataConflictException() { }
        public DataConflictException(string message) : base(message) { }
        public DataConflictException(string message, Exception innerException) : base(message, innerException) { }
    }
}
