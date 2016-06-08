﻿using System.Diagnostics;
using System.Net.Http;
using System.Web.Http.Routing;

namespace Cobweb.Testing.WebApi.Assertions {
    /// <summary>
    ///     Contains extension methods for custom assertions in unit tests.
    /// </summary>
    [DebuggerNonUserCode]
    public static class AssertionExtensions {
        /// <summary>
        ///     Returns a <see cref="HttpRouteValueDictionaryAssertions" /> object that can be used to assert the current
        ///     <see cref="HttpRouteValueDictionary" />.
        /// </summary>
        public static HttpRouteValueDictionaryAssertions Should(this HttpRouteValueDictionary actualValue) {
            return new HttpRouteValueDictionaryAssertions(actualValue);
        }

        /// <summary>
        ///     Returns a <see cref="HttpRequestMessageAssertions" /> object that can be used to assert the current
        ///     <see cref="HttpRouteData" />.
        /// </summary>
        public static HttpRequestMessageAssertions Should(this HttpRequestMessage actualValue) {
            return new HttpRequestMessageAssertions(actualValue);
        }
    }
}