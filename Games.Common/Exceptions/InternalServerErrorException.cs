using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Games.Common.Exceptions
{
    /// <summary>
    /// Исключение выбрасываемое в случае, если возникла внутренняя ошибка сервера
    /// </summary>
    [Serializable]
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException()
        {
        }
        public InternalServerErrorException(string message) : base(message)
        {
        }

        public InternalServerErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InternalServerErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
