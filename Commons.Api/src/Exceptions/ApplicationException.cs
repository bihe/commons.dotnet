using System;

namespace Commons.Api.Exceptions
{
    public class ApplicationException : Exception
    {
        public int StatusCode { get; set; }

        public ApplicationException(string message) : base(message)
        {}

        public ApplicationException(string message, Exception inner) : base(message, inner)
        {}

        public ApplicationException(string message, int statusCode) : base(message)
        {
            this.StatusCode = statusCode;
        }
    }
}