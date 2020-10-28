using System;

namespace depox.Core.Exceptions
{
    public class OutOfStockException : Exception
    {
        public OutOfStockException(string itemCode) : base($"Item {itemCode} get's out of stock with the supplied quantity")
        {
        }

        protected OutOfStockException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }


        public OutOfStockException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}