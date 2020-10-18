using System;

namespace depox.Core.Exceptions
{
    public class OutOfStockException : Exception
    {
        public OutOfStockException(int itemId) : base($"Item is out of stock  {itemId}")
        {
        }

        protected OutOfStockException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public OutOfStockException(string message) : base(message)
        {
        }

        public OutOfStockException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}