﻿// Copyright (c) Paul Bentley 2019. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project root for full license information.

namespace Restfully
{
    /// <summary>
    /// Defines methods to serialize and deserialize JSON responses.
    /// </summary>
    public interface ISerializer
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
    }
}