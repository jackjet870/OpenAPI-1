using System.Collections.Generic;

namespace OpenAPI.Schema
{
    /// <summary>This is the root document object for the API specification.</summary>
    /// <remarks>http://swagger.io/specification/#swaggerObject</remarks>
    public class SwaggerObject
    {
        public SwaggerObject(Info info)
        {
            this.Info = info;
        }

        /// <summary>Required. Specifies the Swagger Specification version being used. It can be used by the Swagger UI and other clients to interpret the API listing. The value MUST be "2.0".</summary>
        public string Swagger { get; } = "2.0";

        /// <summary>Required. Provides metadata about the API. The metadata can be used by the clients if needed.</summary>
        public Info Info { get; }

        /// <summary>The host (name or ip) serving the API. This MUST be the host only and does not include the scheme nor sub-paths. It MAY include a port. If the host is not included, the host serving the documentation is to be used (including the port). The host does not support path templating.</summary>
        public string Host { get; set; }

        /// <summary>The base path on which the API is served, which is relative to the host. If it is not included, the API is served directly under the host. The value MUST start with a leading slash (/). The basePath does not support path templating.</summary>
        public string BasePath { get; set; }

        /// <summary>The transfer protocol of the API. Values MUST be from the list: "http", "https", "ws", "wss". If the schemes is not included, the default scheme to be used is the one used to access the Swagger definition itself.</summary>
        public ICollection<string> Schemes { get; set; }

        /// <summary>A list of MIME types the APIs can consume. This is global to all APIs but can be overridden on specific API calls. Value MUST be as described under Mime Types.</summary>
        /// <remarks>http://swagger.io/specification/#mimeTypes</remarks>
        public ICollection<string> Consumes { get; set; }

        /// <summary>A list of MIME types the APIs can produce. This is global to all APIs but can be overridden on specific API calls. Value MUST be as described under Mime Types.</summary>
        /// <remarks>http://swagger.io/specification/#mimeTypes</remarks>
        public ICollection<string> Produces { get; set; }

        /// <summary>Required. The available paths and operations for the API.</summary>
        /// <remarks>A relative path to an individual endpoint. The field name MUST begin with a slash. The path is appended to the basePath in order to construct the full URL. Path templating is allowed.</remarks>
        /// <remarks>http://swagger.io/specification/#pathTemplating</remarks>
        public IDictionary<string, PathItem> Paths { get; } = new Dictionary<string, PathItem>();

        /// <summary>
        /// An object to hold data types produced and consumed by operations.
        /// </summary>
        public ICollection<IDictionary<string, SchemaObject>> Definitions { get; set; }

        /// <summary>
        /// A declaration of which security schemes are applied for the API as a whole. The list of values describes alternative security schemes that can be used (that is, there is a logical OR between the security requirements). Individual operations can override this definition.
        /// </summary>
        public ICollection<IDictionary<string, ICollection<string>>> Security { get; set; }

        /// <summary>
        /// A list of tags used by the specification with additional metadata. The order of the tags can be used to reflect on their order by the parsing tools. Not all tags that are used by the Operation Object must be declared. The tags that are not declared may be organized randomly or based on the tools' logic. Each tag name in the list MUST be unique.
        /// </summary>
        public ICollection<Tag> Tags { get; set; }

        /// <summary>
        /// Additional external documentation.
        /// </summary>
        public ExternalDocumentation ExternamDocs { get; set; }
    }
}
