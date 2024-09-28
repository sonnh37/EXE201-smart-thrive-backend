using EXE201.SmartThrive.API.HandleException;
using EXE201.SmartThrive.Domain.Utilities;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Net;
using Microsoft.AspNetCore.WebUtilities;

namespace EXE201.SmartThrive.Domain.Exceptions
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
