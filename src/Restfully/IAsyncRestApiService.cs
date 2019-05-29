namespace Restfully
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A RESTful API service which can be sent async GET and POST requests.
    /// </summary>
    public interface IAsyncRestApiService : IRestApiService
    {
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
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>An object based on the server response.</returns>
        Task<T> PostRequestAsync<T>(string resource, object data, CancellationToken cancellationToken);
    }
}