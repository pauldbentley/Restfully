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
    /// Defines service methods to serialize and deserialize JSON responses.
    /// </summary>
    public interface IJsonSerializationService
    {
        /// <summary>
        /// Serializes a value to a JSON string.
        /// </summary>
        /// <param name="value">The value to serialize.</param>
        /// <returns>A JSON string representation of the given value.</returns>
        string Serialize(object value);

        /// <summary>
        /// Deserializes a JSON string to an object.
        /// </summary>
        /// <typeparam name="T">The type of value to deserialize.</typeparam>
        /// <param name="value">A JSON string to deserialize.</param>
        /// <returns>An object deserialized from the JSON string.</returns>
        T Deserialize<T>(string value);

        /// <summary>
        /// Deserializes a JSON string to an object.
        /// </summary>
        /// <param name="value">A JSON string to deserialize.</param>
        /// <returns>An object deserialized from the JSON string.</returns>
        object Deserialize(string value);
    }
}