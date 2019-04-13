using System.Net;
using Newtonsoft.Json.Linq;

namespace LotoResultsViewer.Models.Data
{
    public class ResponseMessage
    {
        public HttpStatusCode Status { get; set; }
        public object Result { get; set; }
    }
}