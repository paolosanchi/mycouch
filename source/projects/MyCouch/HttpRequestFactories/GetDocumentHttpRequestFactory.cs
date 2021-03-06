﻿using System.Net.Http;
using EnsureThat;
using MyCouch.Net;
using MyCouch.Requests;

namespace MyCouch.HttpRequestFactories
{
    public class GetDocumentHttpRequestFactory
    {
        public virtual HttpRequest Create(GetDocumentRequest request)
        {
            Ensure.Any.IsNotNull(request, nameof(request));

            return new HttpRequest(HttpMethod.Get, GenerateRelativeUrl(request))
                .SetRequestTypeHeader(request.GetType())
                .SetIfMatchHeader(request.Rev);
        }

        protected virtual string GenerateRelativeUrl(GetDocumentRequest request)
        {
            var urlParams = new UrlParams();

            urlParams.AddIfNotNullOrWhiteSpace("rev", request.Rev);
            urlParams.AddIfTrue("conflicts", request.Conflicts);
            urlParams.AddIfTrue("revs", request.Revisions);

            return string.Format("/{0}{1}", new UrlSegment(request.Id), new QueryString(urlParams));
        }
    }
}