using System.Net;

namespace LotoResultsViewer.Models.Data
{
    public class ResponseMessage<T>
    {
        public HttpStatusCode Status { get; set; }
        public T Result { get; set; }
    }
}