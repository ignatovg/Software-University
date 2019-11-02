using System;
using System.Collections.Generic;
using System.Text;
using SIS.Http.Headers.Contracts;

namespace SIS.Http.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly IDictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            if (header != null && 
                !string.IsNullOrEmpty(header.Key) && 
                !string.IsNullOrEmpty(header.Value) &&
                !this.ContainsHeader(header.Key))
            {
                this.headers.Add(header.Key, header);

            }
        }

        public bool ContainsHeader(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException($"{nameof(key)} cannot be null.");
            }
            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException($"{nameof(key)} cannot be null");
            }
            if (this.ContainsHeader(key))
            {
                return this.headers[key];
            }
            return null;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.headers.Values);
        }
    }
}
