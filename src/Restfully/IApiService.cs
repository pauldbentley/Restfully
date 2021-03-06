﻿// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace Restfully
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A sync/async RESTful API service which can be sent GET and POST requests.
    /// </summary>
    public interface IApiService
    {
        /// <summary>
        /// Performs a GET request with the specified data.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        T GetRequest<T>(object data);

        /// <summary>
        /// Performs a GET request to the specified resource with the specified data.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="resource">The resource to get.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        T GetRequest<T>(string resource, object data);

        /// <summary>
        /// Performs a POST request with the specified data.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        T PostRequest<T>(object data);

        /// <summary>
        /// Performs a POST request to a specified resource with the specified data.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="resource">The resource to post the data to.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        T PostRequest<T>(string resource, object data);

        /// <summary>
        /// Performs a GET request with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        Task<T> GetRequestAsync<T>(object data, CancellationToken cancellationToken);

        /// <summary>
        /// Performs a GET request to the specified resource with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="resource">The resource to post the data to.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        Task<T> GetRequestAsync<T>(string resource, object data, CancellationToken cancellationToken);

        /// <summary>
        /// Performs a POST request with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        Task<T> PostRequestAsync<T>(object data, CancellationToken cancellationToken);

        /// <summary>
        /// Performs a POST request to the specified resource with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="resource">The resource to post the data to.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        Task<T> PostRequestAsync<T>(string resource, object data, CancellationToken cancellationToken);
    }
}