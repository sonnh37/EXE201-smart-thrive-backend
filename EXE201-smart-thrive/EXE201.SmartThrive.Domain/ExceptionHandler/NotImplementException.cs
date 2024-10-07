using Microsoft.AspNetCore.WebUtilities;
using System.Net;

namespace EXE201.SmartThrive.Domain.ExceptionHandler
{
    public class NotImplementException : ApiException
    {
        private static readonly int StatusCode = (int)HttpStatusCode.NotImplemented;
        public NotImplementException(string message) : base(message, (int)HttpStatusCode.NotImplemented) { }


        public NotImplementException() : base(ReasonPhrases.GetReasonPhrase(StatusCode), StatusCode) { }
    }
}
