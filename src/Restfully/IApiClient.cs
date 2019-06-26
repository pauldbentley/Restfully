// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace Restfully
{
    /// <summary>
    /// Generic client for sending HTTP requests to a RESTful API server.
    /// </summary>
    public interface IApiClient
    {
        /// <summary>
        /// Sends the specified request and returns a response.
        /// </summary>
        /// <param name="restApiRequest">A <see cref="IApiRequest"/> that represents the HTTP request.</param>
        /// <returns>A <see cref="IApiResponse"/> representing the response from the server.</returns>
        IApiResponse Send(IApiRequest restApiRequest);
    }
}
