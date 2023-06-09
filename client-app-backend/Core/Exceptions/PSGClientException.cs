namespace client_app_backend.Core.Exceptions
{
    using System.Net;

    public class PSGClientException : Exception
    {
        public Guid GUID { get; }
        public HttpStatusCode HttpStatusCode { get; }

        public PSGClientException(string message, HttpStatusCode code)
            : base(message)
        {
            GUID = Guid.NewGuid();
            HttpStatusCode = code;
        }

        public PSGClientException(HttpStatusCode code)
            : base()
        {
            GUID = Guid.NewGuid();
            HttpStatusCode = code;
        }

        public PSGClientException(string message)
            : base(message)
        {
            GUID = Guid.NewGuid();
            HttpStatusCode = HttpStatusCode.InternalServerError;
        }

        public PSGClientException()
            : base()
        {
            GUID = Guid.NewGuid();
            HttpStatusCode = HttpStatusCode.InternalServerError;
        }
    }
}
