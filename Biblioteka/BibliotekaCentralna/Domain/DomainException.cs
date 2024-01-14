using System.Net;
using System.Runtime.Serialization;

namespace BibliotekaCentralna.Domain
{
    public class DomainException : Exception, ISerializable
    {
        public HttpStatusCode StatusCode { get; set; }

        public DomainException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message)
        {
            StatusCode = statusCode;
        }

        public DomainException(string message, Exception inner, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message, inner)
        {
            StatusCode = statusCode;
        }

        public DomainException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
