﻿using SIS.Http.Enum;
using SIS.Http.Headers.Contracts;
using SIS.Http.Requests.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Http.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();

        }
        public string Path { get; private set; }

        public string Url  { get; private set; }

        public Dictionary<string, object> FormData { get;  }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }
    }
}
