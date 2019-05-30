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
    /// <summary>
    /// A RESTful API service which can be sent GET and POST requests.
    /// </summary>
    public interface IRestApiService
    {
        /// <summary>
        /// Performs a GET request with the specified data.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        T GetRequest<T>(object data);

        /// <summary>
        /// Performs a GET request to the specified resource with the specified data.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="resource">The resource to get.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        T GetRequest<T>(string resource, object data);

        /// <summary>
        /// Performs a POST request with the specified data.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        T PostRequest<T>(object data);

        /// <summary>
        /// Performs a POST request to a specified resource with the specified data.
        /// </summary>
        /// <typeparam name="T">The type of response data.</typeparam>
        /// <param name="resource">The resource to post the data to.</param>
        /// <param name="data">The data to supply with the request.</param>
        /// <returns>An object based on the server response.</returns>
        T PostRequest<T>(string resource, object data);
    }
}