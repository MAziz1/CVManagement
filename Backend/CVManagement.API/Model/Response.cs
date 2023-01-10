using System.Collections.Generic;
using System.Net;

namespace CVManagement.API.Model
{
    public class Response<T> where T: class
    {
        public List<string> Errors { get; set; }
        public HttpStatusCode Status { get; set; }
        public T Data { get; set; }
    }
}
