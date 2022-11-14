using System.Runtime.Serialization;

namespace Lesson12
{
    public class WrongPasswordException : AccountException
    {
        public WrongPasswordException()
        {
        }

        public WrongPasswordException(string? message) : base(message)
        {
        }

        public WrongPasswordException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected WrongPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
