// Copyright(c) 2019 Paul Bentley

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
namespace Restfully
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Reflection;

    /// <summary>
    /// Defines the response from a RESTful API.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public class RestApiResponse : IRestApiResponse
    {
        /// <summary>
        /// Gets or sets the response body.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the length in bytes of the response content.
        /// </summary>
        public long ContentLength { get; set; }

        /// <summary>
        /// Gets or sets the MIME content type of response.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the headers returned by server with the response.
        /// </summary>
        public IReadOnlyDictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Gets or sets the URL that actually responded to the content (different from request if redirected).
        /// </summary>
        public Uri ResponseUri { get; set; }

        /// <summary>
        /// Gets or sets the HTTP response status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the description of HTTP status returned.
        /// </summary>
        public string StatusDescription { get; set; }

        /// <summary>
        /// Gets or sets the transport or other non-HTTP error generated while attempting request.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the exceptions thrown during the request, if any.
        /// </summary>
        public Exception ErrorException { get; set; }

        private string DebuggerDisplay()
        {
            return string.Format(
                CultureInfo.CurrentCulture,
                "StatusCode: {0}, Content-Type: {1}, Content-Length: {2})",
                StatusCode,
                ContentType,
                ContentLength);
        }
    }
}
