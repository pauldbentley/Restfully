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
