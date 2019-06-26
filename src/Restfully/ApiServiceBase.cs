// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace Restfully
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    /// <summary>
    /// Defines a base class for a RESTful API service.
    /// </summary>
    public abstract class ApiServiceBase
    {
        /// <summary>
        /// The HTTP verb for GET.
        /// </summary>
        private protected const string HttpGet = "GET";

        /// <summary>
        /// The HTTP verb for POST.
        /// </summary>
        private protected const string HttpPost = "POST";

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiServiceBase"/> class with the specified base URL and service path.
        /// </summary>
        /// <param name="baseUrl">The base URL of the API.</param>
        /// <param name="path">The path to the service from the base URL.</param>
        /// <param name="serializer">Service to serialize and deserialize JSON requests and responses.</param>
        protected ApiServiceBase(Uri baseUrl, string path, ISerializer serializer)
        {
            BaseUri = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            Path = path;
            Serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
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
        /// Gets or sets a value indicating whether redirects should be automatically followed.
        /// </summary>
        public bool AllowAutoRedirect { get; set; }

        /// <summary>
        /// Gets or sets a timeout in milliseconds to use for requests made by the client.
        /// </summary>
        public int? HttpTimeout { get; set; }

        /// <summary>
        /// Gets or sets a proxy to use for requests made to the service.
        /// </summary>
        public IWebProxy Proxy { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets the service to serialize/deserialize responses from the API.
        /// </summary>
        protected ISerializer Serializer { get; }

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
        protected virtual object GetEntityResponse(IApiResponse response) => default;

        /// <summary>
        /// Returns an exception to throw when an error has occured.
        /// </summary>
        /// <param name="response">The response from the server.</param>
        /// <returns>A <see cref="Exception"/> object.</returns>
        protected virtual Exception HandleError(IApiResponse response) =>
            response.ErrorException ?? new Exception(response.ErrorMessage);

        /// <summary>
        /// Builds an <see cref="IApiRequest"/>.
        /// </summary>
        /// <param name="resource">The resource being requested.</param>
        /// <param name="method">The request method.</param>
        /// <param name="data">The data being sent with the request.</param>
        /// <returns>An <see cref="IApiRequest"/> with the relevant information set.</returns>
        private protected IApiRequest BuildRequest(string resource, string method, object data)
        {
            BeforeSend(data);

            var request = new ApiRequest(BaseUri, GetEndpointUri(resource))
            {
                ContentType = ContentType ?? "text/json",
                Method = method,
                AllowAutoRedirect = AllowAutoRedirect,
                Proxy = Proxy,
            };

            if (HttpTimeout.HasValue)
            {
                request.Timeout = HttpTimeout.Value;
            }

            if (method == HttpPost)
            {
                // for POST we add the JSON directly to the body
                if (data != null)
                {
                    request.Body = Serializer.Serialize(data);
                }
            }
            else if (method == HttpGet)
            {
                // for GET we add a query string parameters
                // We serialize to JSON then back to an object so that
                // the SerializerSettings are followed
                // if we have any data
                if (data != null)
                {
                    string json = Serializer.Serialize(data);
                    var values = Serializer.Deserialize<Dictionary<string, object>>(json);

                    foreach (var value in values)
                    {
                        request.Parameters.Add(value.Key, value.Value);
                    }
                }
            }

            return request;
        }

        /// <summary>
        /// Builds the response to send back to the client.
        /// </summary>
        /// <typeparam name="TEntity">The type of entity in the response.</typeparam>
        /// <param name="response">The response from the server.</param>
        /// <returns>A <typeparamref name="TEntity"/>.</returns>
        private protected TEntity BuildResponse<TEntity>(IApiResponse response)
        {
            ThrowOnError(response);
            var entity = Serializer.Deserialize<TEntity>(response.Content);
            SetEntityResponse(response, entity);
            return entity;
        }

        private Uri GetEndpointUri(string resource) =>
            new Uri(string.IsNullOrWhiteSpace(resource) ? Path : $"{Path}/{resource}", UriKind.Relative);

        private void SetEntityResponse(IApiResponse response, object entity)
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

        private void ThrowOnError(IApiResponse response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw HandleError(response);
            }
        }
    }
}