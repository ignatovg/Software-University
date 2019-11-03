using SIS.Http.Common;
using SIS.Http.Enum;
using SIS.Http.Exceptions;
using SIS.Http.Headers;
using SIS.Http.Headers.Contracts;
using SIS.Http.Requests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.Http.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);

        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private void ParseRequest(string requestString)
        {
            var splitReqiestContent = requestString
                .Split(Environment.NewLine);

            var requestLine = splitReqiestContent[0]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (!this.ValidateRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            //method
            //url
            //path

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            //headers
            this.ParseHeaders(splitReqiestContent.Skip(1).ToArray());
            //parameters
            bool requestHasBody = splitReqiestContent.Length > 1;
            this.ParseRequestParameters(splitReqiestContent[splitReqiestContent.Length-1],requestHasBody);
            

        }

        private void ParseRequestParameters(string bodyParameters, bool requestHasBody)
        {
            this.ParseQueryParameters(this.Url);
            if (requestHasBody)
            {
                this.ParseFormDataParameters(bodyParameters);
            }
            
        }

        private void ParseFormDataParameters(string bodyParameters)
        {
            
            var formDataKeyValuePairs = bodyParameters.Split('&', StringSplitOptions.RemoveEmptyEntries);

            foreach (var formDataKeyValuePair in formDataKeyValuePairs)
            {
                //key=value
                var keyValuePair = formDataKeyValuePair.Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (keyValuePair.Length != 2)
                {
                    throw new BadRequestException();
                }

                var formDataKey = keyValuePair[0];
                var formDataValue = keyValuePair[1];

                //formDataKey -> {formDataKey, formDataValue} ?
                //should we overwrite?
                this.FormData[formDataKey] = formDataValue;

            }
        }

        private void ParseQueryParameters(string url)
        {
            var queryParameters = this.Url?
                .Split(new char[] { '?', '#' })
                .Skip(1)
                .ToArray()[0];
            
            if (string.IsNullOrEmpty(queryParameters))
            {
                throw new BadRequestException();
            }

            ///? query=12&hour=2  #
            var queryKeyValuePairs = queryParameters.Split('&', StringSplitOptions.RemoveEmptyEntries);

            foreach (var queryKeyValuePair in queryKeyValuePairs)
            {
                //key=value
                var keyValuePair = queryKeyValuePair.Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (keyValuePair.Length != 2)
                {
                    throw new BadRequestException();
                }

                var queryKey = keyValuePair[0];
                var queryValue = keyValuePair[1];

                //queryKey -> {querykey, queryValue} ?
                //should we overwrite?
                this.QueryData[queryKey] =queryValue;

            }
        }

        private void ParseHeaders(string[] requestHeaders)
        {
            if (requestHeaders.Any())
            {
                throw new BadRequestException();
            }
            foreach(var requestHeader in requestHeaders)
            {
                if (string.IsNullOrEmpty(requestHeader))
                {
                    return;
                }
                var splitRequestHeader = requestHeader.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                var requestHeaderKey = splitRequestHeader[0];
                var requestHeaderValue = splitRequestHeader[1];

                this.Headers.Add(new HttpHeader(requestHeaderKey, requestHeaderValue));
            }
        }

        private void ParseRequestPath()
        {
            var path = this.Url?.Split('?').FirstOrDefault();
            if (string.IsNullOrEmpty(path))
            {
                throw new BadRequestException();
            }
            this.Path = path;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            if (string.IsNullOrEmpty(requestLine[1]))
            {
                throw new BadRequestException();
            }
            this.Url = requestLine[1];
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }
            var parseResult = System.Enum.TryParse<HttpRequestMethod>(requestLine[0], out var parsedRequestmethod);

            if (!parseResult)
            {
                throw new BadRequestException();
            }
            this.RequestMethod = parsedRequestmethod;
            
        }

        private bool ValidateRequestLine(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }

            if (requestLine.Length == 3 &&
                requestLine[2] == GlobalConstants.HttpOneProtocolFragment)
            {
                return true;
            }
            return false;
        }

       
    }
}
