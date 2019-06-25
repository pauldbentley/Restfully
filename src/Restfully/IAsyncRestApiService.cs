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
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A RESTful API service which can be sent async GET and POST requests.
    /// </summary>
    public interface IAsyncRestApiService
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
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An object based on the server response.</returns>
        Task<T> PostRequestAsync<T>(string resource, object data, CancellationToken cancellationToken);
    }
}