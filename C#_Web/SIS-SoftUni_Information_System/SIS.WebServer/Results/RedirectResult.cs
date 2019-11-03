using SIS.Http.Responses;
using System.Net;
using SIS.Http.Headers;

namespace SIS.WebServer.Results
{
    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location)
            :base(HttpStatusCode.Redirect)
        {
            this.Headers.Add(new HttpHeader("Location", location));
            
        }
    }
}
