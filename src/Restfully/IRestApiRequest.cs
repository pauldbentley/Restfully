namespace Restfully
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    /// <summary>
    /// Represents a request which can be sent to a RESTful API service.
    /// </summary>
    public interface IRestApiRequest
    {
        /// <summary>
        /// Gets or sets the body of the request.
        /// </summary>
        object Body { get; set; }

        /// <summary>
        /// Gets the headers sent with the request.
        /// </summary>
        IDictionary<string, string> Headers { get; }

        /// <summary>
        /// Gets or sets the request method.
        /// </summary>
        string Method { get; set; }

        /// <summary>
        /// Gets the parameters sent with the request.
        /// </summary>
        IDictionary<string, object> Parameters { get; }

        /// <summary>
        /// Gets the base address of the REST API to request.
        /// </summary>
        Uri BaseAddress { get; }

        /// <summary>
        /// Gets the end point of the service to request.
        /// </summary>
        Uri Endpoint { get; }

        /// <summary>
        /// Gets or sets the timeout in milliseconds to use for requests made.
        /// </summary>
        int Timeout { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        string ContentType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether redirects should be automatically followed.
        /// </summary>
        bool AllowAutoRedirect { get; set; }

        /// <summary>
        /// Gets or sets the proxy access for the request.
        /// </summary>
        IWebProxy Proxy { get; set; }
    }
}
