using System.Net;

namespace ShabbaToDoo.Application.Common.Errors
{
    public interface IServiceExceptions
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage { get; }
    }
}
