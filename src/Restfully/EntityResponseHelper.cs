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
