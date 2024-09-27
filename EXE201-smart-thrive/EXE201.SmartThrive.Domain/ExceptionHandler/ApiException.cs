using EXE201.SmartThrive.Domain.Utilities;
using System.Net;

namespace EXE201.SmartThrive.API.HandleException
{
    public class ApiException : Exception
    {
        protected int _httpStatusCode;

        public int StatusCode { get => _httpStatusCode; }

        public ApiException() : base() { }

        public ApiException(string message, int statusCode) : base(message)
        {
            _httpStatusCode = statusCode;
        }
    }
}