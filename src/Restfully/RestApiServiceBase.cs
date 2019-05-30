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
    /// Base class for a RESTful API service.
    /// </summary>
    public abstract class RestApiServiceBase : IRestApiService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RestApiServiceBase"/> class with the specified base URL and service path.
        /// </summary>
        /// <param name="baseUrl">The base URL of the API.</param>
        /// <param name="path">The path to the service from the base URL.</param>
        /// <param name="client">The RESTful client.</param>
        /// <param name="serializer">Service to serialize and deserialize JSON requests and responses.</param>
        protected RestApiServiceBase(Uri baseUrl, string path, IRestApiClient client, IJsonSerializationService serializer)
        {
            BaseUri = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            Path = path;

            Serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <summary>
        /// Gets the service path.  All requests are made from this path as a starting point.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Gets the base URI to the service.
        /// </summary>
        public Uri BaseUri { get; }

        /// <summary>
        /// Gets the service to serialize/deserialize responses from the API.
        /// </summary>
        protected IJsonSerializationService Serializer { get; }

        /// <summary>
        /// Gets the client to make requests to the API.
        /// </summary>
        protected IRestApiClient Client { get; }

        /// <summary>
        /// Performs a GET request with the specified data.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        public TEntity GetRequest<TEntity>(object data) =>
            GetRequest<TEntity>(string.Empty, data);

        /// <summary>
        /// Performs a GET request to the specified resource with the specified data.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="resource">The resource to get.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        public TEntity GetRequest<TEntity>(string resource, object data) =>
            RunRequest<TEntity>(resource, "GET", data);

        /// <summary>
        /// Performs a POST request with the specified data.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        public TEntity PostRequest<TEntity>(object data) =>
            PostRequest<TEntity>(string.Empty, data);

        /// <summary>
        /// Performs a POST request to a specified resource with the specified data.
        /// </summary>
        /// <typeparam name="TEntity">The type of response data.</typeparam>
        /// <param name="resource">The resource to post the data to.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        public TEntity PostRequest<TEntity>(string resource, object data) =>
            RunRequest<TEntity>(resource, "POST", data);

        /// <summary>
        /// Perform any actions on the data before it is sent to the server.
        /// </summary>
        /// <param name="data">The data.</param>
        protected virtual void BeforeSend(object data)
        {
        }

        /// <summary>
        /// Gets a response object to be set on the returned entity.
        /// </summary>
        /// <param name="response">The API response.</param>
        /// <returns>An object to be set on the returned entity.</returns>
        protected virtual object GetEntityResponse(IRestApiResponse response) => default;

        /// <summary>
        /// Returns an exception to throw when an error has occured.
        /// </summary>
        /// <param name="response">The response from the server.</param>
        /// <returns>A <see cref="Exception"/> object.</returns>
        protected virtual Exception HandleError(IRestApiResponse response) =>
            response.ErrorException ?? new Exception(response.ErrorMessage);

        /// <summary>
        /// Builds an <see cref="IRestApiRequest"/>.
        /// </summary>
        /// <param name="resource">The resource being requested.</param>
        /// <param name="method">The request method.</param>
        /// <param name="data">The data being sent with the request.</param>
        /// <returns>An <see cref="IRestApiRequest"/> with the relevant information set.</returns>
        protected IRestApiRequest BuildRequest(string resource, string method, object data)
        {
            BeforeSend(data);

            var input = new RestApiRequest(BaseUri, GetEndpoint(resource))
            {
                ContentType = "text/json",
                Method = method,
            };

            if (method == "POST")
            {
                // for POST we add the JSON directly to the body
                input.Body = Serializer.Serialize(data);
            }
            else if (method == "GET")
            {
                // for GET we add a query string parameters
                // We serialize to JSON then back to an object so that
                // the SerializerSettings are followed
                string json = Serializer.Serialize(data);
                var values = Serializer.Deserialize<Dictionary<string, object>>(json);

                foreach (var value in values)
                {
                    input.Parameters.Add(value.Key, value.Value);
                }
            }

            return input;
        }

        /// <summary>
        /// Gets the Endpoint URI for the given resource from the service path.
        /// </summary>
        /// <param name="resource">The resource being requested.</param>
        /// <returns>A <see cref="Uri"/> pointing to the resource from the service path.</returns>
        protected Uri GetEndpoint(string resource)
        {
            return new Uri(string.IsNullOrWhiteSpace(resource) ? Path : $"{Path}/{resource}", UriKind.Relative);
        }

        /// <summary>
        /// Gets the entity response property on the entity.
        /// </summary>
        /// <param name="response">The response from the server.</param>
        /// <param name="entity">The entity returned from the service.</param>
        protected void SetEntityResponse(IRestApiResponse response, object entity)
        {
            if (entity == null)
            {
                return;
            }

            var entityResponse = GetEntityResponse(response);

            if (entityResponse == null)
            {
                return;
            }

            EntityResponseHelper.SetResponse(entity, entityResponse);
        }

        /// <summary>
        /// If the response did not return an OK status, throws an Exception.
        /// </summary>
        /// <param name="response">The response from the service.</param>
        protected void ThrowOnError(IRestApiResponse response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw HandleError(response);
            }
        }

        private TEntity RunRequest<TEntity>(string resource, string method, object data)
        {
            var request = BuildRequest(resource, method, data);
            var response = Client.Send(request);
            ThrowOnError(response);
            var entity = Serializer.Deserialize<TEntity>(response.Content);
            SetEntityResponse(response, entity);
            return entity;
        }
    }
}