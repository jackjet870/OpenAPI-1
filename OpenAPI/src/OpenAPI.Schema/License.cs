using System;

namespace OpenAPI.Schema
{
    /// <summary>License information for the exposed API.</summary>
    /// <remarks>http://swagger.io/specification/#licenseObject</remarks>
    public class License
    {
        public License()
        {
        }

        /// <summary>Required. The license name used for the API.</summary>
        public string Name { get; }

        /// <summary>A URL to the license used for the API. MUST be in the format of a URL.</summary>
        public Uri Url { get; }
    }
}