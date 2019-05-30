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
    using System.Reflection;

    /// <summary>
    /// Provides helper methods to set response objects to service entities.
    /// </summary>
    public static class EntityResponseHelper
    {
        /// <summary>
        /// The name of the property which should be used by classes defining a response.
        /// </summary>
        public const string ResponsePropertyName = "Response";

        /// <summary>
        /// Returns a object defined on the given object with called <see cref="ResponsePropertyName"/>, if any.
        /// </summary>
        /// <param name="value">The object to inspect.</param>
        /// <returns>An object value, or null.</returns>
        public static object GetResponse(object value)
        {
            if (value == null)
            {
                return null;
            }

            var property = GetResponseProperty(value);
            return property?.GetValue(value);
        }

        /// <summary>
        /// Sets the <see cref="ResponsePropertyName"/> property of the given value to the response object.
        /// </summary>
        /// <param name="value">The value to allocate the response to.</param>
        /// <param name="response">The response.</param>
        public static void SetResponse(object value, object response)
        {
            if (value == null)
            {
                return;
            }

            var property = GetResponseProperty(value);

            if (property != null)
            {
                property.SetValue(value, response);
            }
        }

        private static PropertyInfo GetResponseProperty(object value)
        {
            // find the Response property on the value
            var property = value
                .GetType()
                .GetRuntimeProperty(ResponsePropertyName);

            return property;
        }
    }
}
