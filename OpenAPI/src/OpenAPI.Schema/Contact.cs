using System;

namespace OpenAPI.Schema
{
    /// <summary>Contact information for the exposed API.</summary>
    /// <remarks>http://swagger.io/specification/#contactObject</remarks>
    public class Contact
    {
        /// <summary>The identifying name of the contact person/organization.</summary>
        public string Name { get; set; }

        /// <summary>The URL pointing to the contact information. MUST be in the format of a URL.</summary>
        public Uri Url { get; set; }

        /// <summary>The email address of the contact person/organization. MUST be in the format of an email address.</summary>
        public string Email { get; set; }

    }
}