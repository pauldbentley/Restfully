namespace Restfully
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;

    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public class RestApiRequest : IRestApiRequest
    {
        public object Body { get; set; }

        public IDictionary<string, string> Headers { get; } = new Dictionary<string, string>();

        public string Method { get; set; }

        public IDictionary<string, object> Parameters { get; } = new Dictionary<string, object>();

        public Uri BaseAddress { get; set; }

        public Uri Endpoint { get; set; }

        public int Timeout { get; set; }

        public string ContentType { get; set; }

        public bool AllowAutoRedirect { get; set; }

        public IWebProxy Proxy { get; set; }

        private object DebuggerDisplay()
        {
            if (Endpoint != null)
            {
                return Endpoint;
            }

            return this;
        }
    }
}
