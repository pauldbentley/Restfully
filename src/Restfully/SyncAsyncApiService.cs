﻿// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace Restfully
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Base class for a sync/async RESTful API service.
    /// </summary>
    public class SyncAsyncApiService : IApiService, IAsyncApiService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SyncAsyncApiService"/> class with the specified base URL and service path.
        /// </summary>
        /// <param name="baseUrl">The base URL of the API.</param>
        /// <param name="path">The path to the service from the base URL.</param>
        /// <param name="syncClient">The RESTful client.</param>
        /// <param name="asyncClient">The asynchronous RESTful client.</param>
        /// <param name="serializer">Service to serialize and deserialize JSON requests and responses.</param>
        public SyncAsyncApiService(Uri baseUrl, string path, IApiClient syncClient, IAsyncApiClient asyncClient, ISerializer serializer)
        {
            SyncService = new ApiService(baseUrl, path, syncClient, serializer);
            AsyncService = new AsyncApiService(baseUrl, path, asyncClient, serializer);
        }

        private IApiService SyncService { get; }

        private IAsyncApiService AsyncService { get; }

        /// <summary>
        /// Performs a GET request with the specified data.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        public TEntity GetRequest<TEntity>(object data) =>
            SyncService.GetRequest<TEntity>(data);

        /// <summary>
        /// Performs a GET request to the specified resource with the specified data.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="resource">The resource to get.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        public TEntity GetRequest<TEntity>(string resource, object data) =>
            SyncService.GetRequest<TEntity>(resource, data);

        /// <summary>
        /// Performs a POST request with the specified data.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        public TEntity PostRequest<TEntity>(object data) =>
            SyncService.PostRequest<TEntity>(data);

        /// <summary>
        /// Performs a POST request to a specified resource with the specified data.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="resource">The resource to post the data to.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        public TEntity PostRequest<TEntity>(string resource, object data) =>
            SyncService.PostRequest<TEntity>(resource, data);

        /// <summary>
        /// Performs a GET request with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        public async Task<TEntity> GetRequestAsync<TEntity>(object data, CancellationToken cancellationToken) =>
            await AsyncService.GetRequestAsync<TEntity>(data, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Performs a GET request to the specified resource with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="resource">The resource to post the data to.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        public async Task<TEntity> GetRequestAsync<TEntity>(string resource, object data, CancellationToken cancellationToken) =>
            await AsyncService.GetRequestAsync<TEntity>(resource, data, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Performs a POST request with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        public async Task<TEntity> PostRequestAsync<TEntity>(object data, CancellationToken cancellationToken) =>
            await AsyncService.PostRequestAsync<TEntity>(data, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Performs a POST request to the specified resource with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="resource">The resource to post the data to.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        public async Task<TEntity> PostRequestAsync<TEntity>(string resource, object data, CancellationToken cancellationToken) =>
            await AsyncService.PostRequestAsync<TEntity>(resource, data, cancellationToken).ConfigureAwait(false);
    }
}