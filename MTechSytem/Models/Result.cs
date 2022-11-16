using System.Net;

namespace MTechSytem.Models
{
    public class Result
    {
        public HttpStatusCode Status { get; set; }
        public object Response { get; set; }
    }
}
