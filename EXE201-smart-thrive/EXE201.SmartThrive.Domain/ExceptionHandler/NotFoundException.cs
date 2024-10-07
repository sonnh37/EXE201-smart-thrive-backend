using Microsoft.AspNetCore.WebUtilities;
using System.Net;

namespace EXE201.SmartThrive.Domain.ExceptionHandler
{
    public class NotfoundException : ApiException
    {
        private static readonly int StatusCode = (int)HttpStatusCode.NotFound;

        public NotfoundException()
            : base(ReasonPhrases.GetReasonPhrase(StatusCode), StatusCode)
        {
        }

        public NotfoundException(string message)
            : base(message, StatusCode)
        {
        }
    }
}
