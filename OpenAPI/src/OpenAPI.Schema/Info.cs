﻿namespace OpenAPI.Schema
{
    /// <summary>The object provides metadata about the API. The metadata can be used by the clients if needed, and can be presented in the Swagger-UI for convenience.</summary>
    /// <remarks>http://swagger.io/specification/#infoObject</remarks>
    public class Info
    {
        public Info(string title)
        {
            this.Title = title;
        }

        /// <summary>Required. The title of the application.</summary>
        public string Title { get; }

        /// <summary>A short description of the application. GFM syntax can be used for rich text representation.</summary>
        public string Description { get; set; }

        /// <summary>The Terms of Service for the API.</summary>
        public string TermsOfService { get; set; }

        /// <summary>The contact information for the exposed API.</summary>
        public Contact Contact { get; set; }

        /// <summary>The contact information for the exposed API.</summary>
        public License License { get; set; }

        /// <summary>The contact information for the exposed API.</summary>
        public string Version { get; set; }
    }
}