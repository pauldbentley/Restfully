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
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        string Serialize<T>(T value);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        T Deserialize<T>(string value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        object Deserialize(string value);
    }
}