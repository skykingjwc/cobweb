﻿using System.Net;
using System.Web;

namespace Aranasoft.Cobweb.Mvc {
    public class HttpBadRequestException : HttpException {
        public HttpBadRequestException(string reason) : base((int) HttpStatusCode.BadRequest, reason) {}
    }
}
