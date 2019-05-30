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
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Base class for a RESTful API service.
    /// </summary>
    public abstract class AsyncRestApiServiceBase : RestApiServiceBase, IAsyncRestApiService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncRestApiServiceBase"/> class with the specified base URL and service path.
        /// </summary>
        /// <param name="baseUrl">The base URL of the API.</param>
        /// <param name="path">The path to the service from the base URL.</param>
        /// <param name="client">The RESTful client.</param>
        /// <param name="serializer">Service to serialize and deserialize JSON requests and responses.</param>
        protected AsyncRestApiServiceBase(Uri baseUrl, string path, IAsyncRestApiClient client, IJsonSerializationService serializer)
            : base(baseUrl, path, client, serializer)
        {
        }

        /// <summary>
        /// Gets the REST API client.
        /// </summary>
        protected new IAsyncRestApiClient Client =>
            (IAsyncRestApiClient)base.Client;

        /// <summary>
        /// Performs a GET request with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        public async Task<TEntity> GetRequestAsync<TEntity>(object data, CancellationToken cancellationToken) =>
            await GetRequestAsync<TEntity>(string.Empty, data, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Performs a GET request to the specified resource with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="resource">The resource to post the data to.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        public async Task<TEntity> GetRequestAsync<TEntity>(string resource, object data, CancellationToken cancellationToken) =>
            await RunRequestAsync<TEntity>(resource, "GET", data, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Performs a POST request with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        public async Task<TEntity> PostRequestAsync<TEntity>(object data, CancellationToken cancellationToken) =>
            await PostRequestAsync<TEntity>(string.Empty, data, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Performs a POST request to the specified resource with the specified data asynchronously.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="resource">The resource to post the data to.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        public async Task<TEntity> PostRequestAsync<TEntity>(string resource, object data, CancellationToken cancellationToken) =>
            await RunRequestAsync<TEntity>(resource, "POST", data, cancellationToken).ConfigureAwait(false);

        private async Task<TEntity> RunRequestAsync<TEntity>(string resource, string method, object data, CancellationToken cancellationToken)
        {
            var request = BuildRequest(resource, method, data);
            var response = await Client
                .SendAsync(request, cancellationToken)
                .ConfigureAwait(false);

            ThrowOnError(response);
            var entity = Serializer.Deserialize<TEntity>(response.Content);
            SetEntityResponse(response, entity);
            return entity;
        }
    }
}