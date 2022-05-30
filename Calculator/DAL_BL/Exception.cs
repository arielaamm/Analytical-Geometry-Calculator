using System;
using System.Runtime.Serialization;

namespace DAL_BL
{
    [Serializable]
    public class ParallelException : System.Exception
    {
        public ParallelException()
        {
        }

        public ParallelException(string message) : base(message)
        {
        }

        public ParallelException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        public ParallelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}