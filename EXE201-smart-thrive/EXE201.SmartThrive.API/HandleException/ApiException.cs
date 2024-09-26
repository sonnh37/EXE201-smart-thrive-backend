using EXE201.SmartThrive.Domain.Utilities;
using System.Net;

namespace EXE201.SmartThrive.API.HandleException
{
    public class ApiException : Exception
    {
        protected int _httpStatusCode;
        protected string _exceptionMessage;

        public int StatusCode { get => _httpStatusCode; }
        public string ExceptionMessage { get => _exceptionMessage; }

        public ApiException() : base() { }

        public ApiException(string message, string exceptionMessage, int statusCode) : base(message)
        {
            _httpStatusCode = statusCode;
            _exceptionMessage = exceptionMessage;
        }
    }

    public class NotfoundException : ApiException
    {
        public NotfoundException(string message, string exceptionMessage)
            : base(message, exceptionMessage, Const.NOT_FOUND_CODE)
        {
        }
    }

    public class NotImplementedException : ApiException
    {
        public NotImplementedException(string message, string exceptionMessage)
            : base(message, exceptionMessage, (int)HttpStatusCode.NotImplemented)
        {
        }
    }
}