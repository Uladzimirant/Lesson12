using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class WrongLoginException : AccountException
    {
        public WrongLoginException()
        {
        }

        public WrongLoginException(string? message) : base(message)
        {
        }

        public WrongLoginException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected WrongLoginException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
