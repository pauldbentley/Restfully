namespace Restfully
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    /// <summary>
    /// Represents a response from a RESTful API service.
    /// </summary>
    public interface IRestApiResponse
    {
        /// <summary>
        /// Gets or sets the response body.
        /// </summary>
        string Content { get; set; }

        /// <summary>
        /// Gets or sets the length in bytes of the response content.
        /// </summary>
        long ContentLength { get; set; }

        /// <summary>
        /// Gets or sets the MIME content type of response.
        /// </summary>
        string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the headers returned by server with the response.
        /// </summary>
        IReadOnlyDictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Gets or sets the URL that actually responded to the content (different from request if redirected).
        /// </summary>
        Uri ResponseUri { get; set; }

        /// <summary>
        /// Gets or sets the HTTP response status code.
        /// </summary>
        HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the description of HTTP status returned.
        /// </summary>
        string StatusDescription { get; set; }

        /// <summary>
        /// Gets or sets the transport or other non-HTTP error generated while attempting request.
        /// </summary>
        string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the exceptions thrown during the request, if any.
        /// </summary>
        Exception ErrorException { get; set; }
    }
}
