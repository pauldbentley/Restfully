namespace Restfully
{
    /// <summary>
    /// Generic client for sending HTTP requests to a RESTful API server.
    /// </summary>
    public interface IRestApiClient
    {
        /// <summary>
        /// Sends the specified request and returns a response.
        /// </summary>
        /// <param name="restApiRequest">A <see cref="IRestApiRequest"/> that represents the HTTP request.</param>
        /// <returns>A <see cref="IRestApiResponse"/> representing the response from the server.</returns>
        IRestApiResponse Send(IRestApiRequest restApiRequest);
    }
}
