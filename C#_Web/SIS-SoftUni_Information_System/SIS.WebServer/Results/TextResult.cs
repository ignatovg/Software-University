using SIS.Http.Responses;
using System.Net;
using SIS.Http.Headers;
using System.Text;

namespace SIS.WebServer.Results
{
   public class TextResult:HttpResponse
    {
        public TextResult(string content, HttpStatusCode statusCode )
            :base(statusCode)
        {
            this.Headers.Add(new HttpHeader("Content-Type", "text/plain"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
