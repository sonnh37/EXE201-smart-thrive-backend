using EXE201.SmartThrive.API.HandleException;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.SmartThrive.Domain.ExceptionHandler
{
    public class NotImplementException : ApiException
    {
        private static readonly int StatusCode = (int)HttpStatusCode.NotImplemented;
        public NotImplementException(string message) : base(message, (int)HttpStatusCode.NotImplemented) { }


        public NotImplementException() : base(ReasonPhrases.GetReasonPhrase(StatusCode), StatusCode) { }
    }
}
