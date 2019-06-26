// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace Restfully
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Base class for a RESTful API service.
    /// </summary>
    public abstract class ApiService : ApiServiceBase, IApiService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiService"/> class with the specified base URL and service path.
        /// </summary>
        /// <param name="baseUrl">The base URL of the API.</param>
        /// <param name="path">The path to the service from the base URL.</param>
        /// <param name="client">The RESTful client.</param>
        /// <param name="serializer">Service to serialize and deserialize JSON requests and responses.</param>
        protected ApiService(Uri baseUrl, string path, IApiClient client, ISerializer serializer)
            : base(baseUrl, path, serializer)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <summary>
        /// Gets the client to make requests to the API.
        /// </summary>
        protected IApiClient Client { get; }

        /// <summary>
        /// Performs a GET request with the specified data.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        public TEntity GetRequest<TEntity>(object data) =>
            RunRequest<TEntity>(string.Empty, HttpGet, data);

        /// <summary>
        /// Performs a GET request to the specified resource with the specified data.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="resource">The resource to get.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        public TEntity GetRequest<TEntity>(string resource, object data) =>
            RunRequest<TEntity>(resource, HttpGet, data);

        /// <summary>
        /// Performs a POST request with the specified data.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        public TEntity PostRequest<TEntity>(object data) =>
            RunRequest<TEntity>(string.Empty, HttpPost, data);

        /// <summary>
        /// Performs a POST request to a specified resource with the specified data.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="resource">The resource to post the data to.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        public TEntity PostRequest<TEntity>(string resource, object data) =>
            RunRequest<TEntity>(resource, HttpPost, data);

        /// <summary>
        /// Performs a GET request with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        public async Task<TEntity> GetRequestAsync<TEntity>(object data, CancellationToken cancellationToken) =>
            await RunRequestAsync<TEntity>(string.Empty, HttpGet, data, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Performs a GET request to the specified resource with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="resource">The resource to post the data to.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        public async Task<TEntity> GetRequestAsync<TEntity>(string resource, object data, CancellationToken cancellationToken) =>
            await RunRequestAsync<TEntity>(resource, HttpGet, data, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Performs a POST request with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        public async Task<TEntity> PostRequestAsync<TEntity>(object data, CancellationToken cancellationToken) =>
            await RunRequestAsync<TEntity>(string.Empty, HttpPost, data, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Performs a POST request to the specified resource with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="resource">The resource to post the data to.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        public async Task<TEntity> PostRequestAsync<TEntity>(string resource, object data, CancellationToken cancellationToken) =>
            await RunRequestAsync<TEntity>(resource, HttpPost, data, cancellationToken).ConfigureAwait(false);

        private TEntity RunRequest<TEntity>(string resource, string method, object data)
        {
            var request = BuildRequest(resource, method, data);
            var response = Client.Send(request);
            return BuildResponse<TEntity>(response);
        }

        private async Task<TEntity> RunRequestAsync<TEntity>(string resource, string method, object data, CancellationToken cancellationToken)
        {
            var request = BuildRequest(resource, method, data);
            var response = await Client
                .SendAsync(request, cancellationToken)
                .ConfigureAwait(false);

            return BuildResponse<TEntity>(response);
        }
    }
}