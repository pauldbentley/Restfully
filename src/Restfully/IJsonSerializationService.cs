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