﻿using System;
using System.Net;
using System.Net.Http;
using MyCouch.Responses;

namespace MyCouch
{
    public class MyCouchResponseException : Exception
    {
        public HttpMethod HttpMethod { get; private set; }
        public HttpStatusCode HttpStatus { get; private set; }
        public Uri Uri { get; private set; }
        public string Error { get; private set; }
        public string Reason { get; private set; }

        public MyCouchResponseException(Response response)
            : this(response.RequestMethod, response.StatusCode, response.RequestUri, response.Error, response.Reason)
        { }

        public MyCouchResponseException(HttpMethod httpMethod, HttpStatusCode httpStatus, Uri uri, string error, string reason)
            : base(string.Format("MyCouch failed.{0}HttpMethod: {1}{0}HttpStatus: {2}{0}Uri:{3}{0}Error: {4}{0}Reason: {5}{0}",
                Environment.NewLine,
                httpMethod,
                httpStatus,
                uri,
                error,
                reason))
        {
            HttpMethod = httpMethod;
            HttpStatus = httpStatus;
            Uri = uri;
            Error = error;
            Reason = reason;
        }
    }
}