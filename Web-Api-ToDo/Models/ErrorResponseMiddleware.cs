using System;
using System.Net;

namespace Web_Api_ToDo.Models
{
    public class ErrorResponseMiddleware
    {
        public string Id { get; set; }
        public string StackTrace { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ExceptionType { get; set; }
        public string Mensagem { get; set; }
        public string Data { get; set; }

        public ErrorResponseMiddleware()
        {
            var dateNow = DateTime.Now;
            Id = Guid.NewGuid().ToString();
            Data = string.Join(null,new[] { dateNow.ToString("dd/MM/yyyy"), " as ", dateNow.ToString("HH:mm:ss") });
        }
    }
}
