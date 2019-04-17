using System.Net;

namespace LotoResultsViewer.Models.Data
{
    public class ResponseMessage
    {
        public HttpStatusCode Status { get; set; }
        public object Result { get; set; }
    }
}