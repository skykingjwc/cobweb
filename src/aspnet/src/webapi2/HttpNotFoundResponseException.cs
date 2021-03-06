﻿using System.Net;
using System.Net.Http;
using System.Web.Http;
using Aranasoft.Cobweb.Http.Formatting;

namespace Aranasoft.Cobweb.Http {
    public class HttpNotFoundResponseException : HttpResponseException {
        public HttpNotFoundResponseException(string reason, string errorMessage)
            : base(
                new HttpResponseMessage(HttpStatusCode.NotFound) {
                    ReasonPhrase = reason,
                    Content = new JsonErrorObjectContent(errorMessage)
                }) {}
    }
}
