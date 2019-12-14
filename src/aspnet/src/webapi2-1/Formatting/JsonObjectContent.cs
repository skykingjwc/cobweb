﻿using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Aranasoft.Cobweb.Http.Formatting {
    public class JsonObjectContent : ObjectContent<dynamic> {
        public JsonObjectContent(object data)
            : base(data, GlobalConfiguration.Configuration.Formatters.OfType<JsonMediaTypeFormatter>().First()) {}
    }
}
