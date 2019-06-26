// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace Restfully
{
    using System;

    /// <summary>
    /// Base class for a synchronous RESTful API service.
    /// </summary>
    public class ApiService : ApiServiceBase, IApiService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiService"/> class with the specified base URL and service path.
        /// </summary>
        /// <param name="baseUrl">The base URL of the API.</param>
        /// <param name="path">The path to the service from the base URL.</param>
        /// <param name="client">The RESTful client.</param>
        /// <param name="serializer">Service to serialize and deserialize JSON requests and responses.</param>
        public ApiService(Uri baseUrl, string path, IApiClient client, ISerializer serializer)
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

        private TEntity RunRequest<TEntity>(string resource, string method, object data)
        {
            var request = BuildRequest(resource, method, data);
            var response = Client.Send(request);
            return BuildResponse<TEntity>(response);
        }
    }
}