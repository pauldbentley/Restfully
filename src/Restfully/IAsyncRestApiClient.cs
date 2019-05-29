namespace Restfully
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Generic client for sending sync HTTP requests to a RESTful API server.
    /// </summary>
    public interface IAsyncRestApiClient : IRestApiClient
    {
        /// <summary>
        /// Sends the specified request and returns a response asynchronously.
        /// </summary>
        /// <param name="restApiRequest">A <see cref="IRestApiRequest"/> that represents the HTTP request.</param>
        /// <param name="cancellationToken">Used to cancel the request</param>
        /// <returns>A <see cref="Task" /> of <see cref="IRestApiResponse"/></returns>
        Task<IRestApiResponse> SendAsync(IRestApiRequest restApiRequest, CancellationToken cancellationToken);
    }
}
