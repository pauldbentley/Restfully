// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace Restfully
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Generic client for sending asynchronous HTTP requests to a RESTful API server.
    /// Implement this interface with your own implementation e.g. using RestSharp.
    /// </summary>
    public interface IAsyncApiClient
    {
        /// <summary>
        /// Sends the specified request and returns a response asynchronously.
        /// </summary>
        /// <param name="restApiRequest">A <see cref="IApiRequest"/> that represents the HTTP request.</param>
        /// <param name="cancellationToken">Used to cancel the request.</param>
        /// <returns>A <see cref="Task" /> of <see cref="IApiResponse"/>.</returns>
        Task<IApiResponse> SendAsync(IApiRequest restApiRequest, CancellationToken cancellationToken);
    }
}
