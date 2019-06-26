// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace Restfully
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    /// <summary>
    /// Represents a request which can be sent to a RESTful API service.
    /// </summary>
    public class ApiRequest : IApiRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequest"/> class.
        /// </summary>
        /// <param name="baseAddress">The base address of the REST API to request.</param>
        /// <param name="endpoint">The end point of the service to request.</param>
        public ApiRequest(Uri baseAddress, Uri endpoint)
        {
            BaseAddress = baseAddress ?? throw new ArgumentNullException(nameof(baseAddress));
            Endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
        }

        /// <summary>
        /// Gets or sets the body of the request.
        /// </summary>
        public object Body { get; set; }

        /// <summary>
        /// Gets the headers sent with the request.
        /// </summary>
        public IDictionary<string, string> Headers { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets the request method.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Gets the parameters sent with the request.
        /// </summary>
        public IDictionary<string, object> Parameters { get; } = new Dictionary<string, object>();

        /// <summary>
        /// Gets the base address of the REST API to request.
        /// </summary>
        public Uri BaseAddress { get; }

        /// <summary>
        /// Gets the end point of the service to request.
        /// </summary>
        public Uri Endpoint { get; }

        /// <summary>
        /// Gets or sets the timeout in milliseconds to use for requests made.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether redirects should be automatically followed.
        /// </summary>
        public bool AllowAutoRedirect { get; set; }

        /// <summary>
        /// Gets or sets the proxy access for the request.
        /// </summary>
        public IWebProxy Proxy { get; set; }
    }
}
