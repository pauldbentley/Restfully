namespace Restfully
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    public interface IRestApiRequest
    {
        object Body { get; set; }

        IDictionary<string, string> Headers { get; }

        string Method { get; set; }

        IDictionary<string, object> Parameters { get; }

        Uri BaseAddress { get; set; }

        Uri Endpoint { get; set; }

        /// <summary>
        /// Gets or sets the timeout in milliseconds to use for requests made.
        /// </summary>
        int Timeout { get; set; }

        string ContentType { get; set; }

        bool AllowAutoRedirect { get; set; }

        IWebProxy Proxy { get; set; }
    }
}
