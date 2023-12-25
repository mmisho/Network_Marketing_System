#nullable disable
using System.Net;

namespace Application.Shared
{
    public class BaseExceptionResponse
    {
        public BaseExceptionResponse()
        {
            HttpStatusCode = HttpStatusCode.OK;
        }

        public BaseExceptionResponse(string message)
        {
            Message = message;
            HttpStatusCode = HttpStatusCode.InternalServerError;
        }

        public BaseExceptionResponse(string message, HttpStatusCode httpStatusCode)
        {
            Message = message;
            HttpStatusCode = httpStatusCode;
        }

        public BaseExceptionResponse(Exception ex)
        {
            HttpStatusCode = HttpStatusCode.InternalServerError;
            Message = "A System Error occured, please try again";

            if (ex.InnerException?.Message != null)
            {
                AddError(ex.InnerException.Message);
            }

            if (ex.InnerException?.InnerException?.Message != null)
            {
                AddError(ex.InnerException.InnerException.Message);
            }

            if (ex.Message != null)
            {
                AddError(ex.Message);
            }

        }

        public HttpStatusCode HttpStatusCode { get; private set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        private void AddError(string description)
        {
            Errors ??= new List<string>();
            Errors.Add(description);
        }
    }
}
