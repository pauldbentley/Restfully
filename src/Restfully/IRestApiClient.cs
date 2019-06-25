﻿// Copyright(c) 2019 Paul Bentley

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
    using System.Net;

    /// <summary>
    /// Generic client for sending HTTP requests to a RESTful API server.
    /// </summary>
    public interface IRestApiClient
    {
        /// <summary>
        /// Gets a value indicating whether redirects should be automatically followed.
        /// </summary>
        bool AllowAutoRedirect { get; }

        /// <summary>
        /// Gets a timeout in milliseconds to use for requests made by the client.
        /// </summary>
        int? HttpTimeout { get; }

        /// <summary>
        /// Gets a proxy to use for requests made to the service.
        /// </summary>
        IWebProxy Proxy { get; }

        /// <summary>
        /// Gets the content type.
        /// </summary>
        string ContentType { get; }

        /// <summary>
        /// Sends the specified request and returns a response.
        /// </summary>
        /// <param name="restApiRequest">A <see cref="IRestApiRequest"/> that represents the HTTP request.</param>
        /// <returns>A <see cref="IRestApiResponse"/> representing the response from the server.</returns>
        IRestApiResponse Send(IRestApiRequest restApiRequest);
    }
}
