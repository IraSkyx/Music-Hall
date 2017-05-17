using System;
using System.Runtime.Serialization;

namespace Biblio
{
    [Serializable]
    internal class AlreadyUsedException : Exception
    {
        public AlreadyUsedException()
        {
        }

        public AlreadyUsedException(string message) : base(message)
        {
        }

        public AlreadyUsedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AlreadyUsedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class DoesntExistException : Exception
    {
        public DoesntExistException()
        {
        }

        public DoesntExistException(string message) : base(message)
        {
        }

        public DoesntExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DoesntExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}