using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Games.Common.Exceptions
{
    /// <summary>
    /// Исключение выбрасываемое в случае, если в запросе были ошибки
    /// </summary>
    [Serializable]
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {
        }
        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
