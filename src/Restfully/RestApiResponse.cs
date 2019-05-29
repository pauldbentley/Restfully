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
