﻿
using SIS.Http.Enum;
using SIS.Http.Headers;
using SIS.Http.Headers.Contracts;
using System.Net;

namespace SIS.Http.Responses.Contracts
{
    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; set; }

        IHttpHeaderCollection Headers { get; }

        byte[] Content { get; set; }

        void AddHeader(HttpHeader header);

        byte[] GetBytes();

    }
}
