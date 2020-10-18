using System;

namespace depox.Core.Exceptions
{
    public class BinNotFoundException : Exception
    {
        public BinNotFoundException(int binId) : base($"No bin found with id {binId}")
        {
        }

        protected BinNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public BinNotFoundException(string message) : base(message)
        {
        }

        public BinNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}