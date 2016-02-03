using System;

namespace OpenAPI.Schema
{
    /// <summary>Allows referencing an external resource for extended documentation.</summary>
    /// <remarks>http://swagger.io/specification/#externalDocumentationObject</remarks>
    public class ExternalDocumentation
    {
        public ExternalDocumentation(Uri url, string description = null)
        {
            this.Url = url;
            this.Description = description;
        }

        /// <summary>A short description of the target documentation. GFM syntax can be used for rich text representation.</summary>
        public string Description { get; }

        /// <summary>Required. The URL for the target documentation. Value MUST be in the format of a URL.</summary>
        public Uri Url { get; }
    }
}