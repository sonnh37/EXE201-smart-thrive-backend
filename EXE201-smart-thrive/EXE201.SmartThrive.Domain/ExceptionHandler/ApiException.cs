namespace EXE201.SmartThrive.Domain.ExceptionHandler
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