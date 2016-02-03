using System.Collections.Generic;
using System.Net;

namespace OpenAPI.Schema
{
    /// <summary>Describes a single API operation on a path.</summary>
    /// <remarks>http://swagger.io/specification/#operationObject</remarks>
    public class Operation
    {
        public Operation()
        {
        }

        /// <summary>A list of tags for API documentation control. Tags can be used for logical grouping of operations by resources or any other qualifier.</summary>
        public string[] Tags { get; }

        /// <summary>A short summary of what the operation does. For maximum readability in the swagger-ui, this field SHOULD be less than 120 characters.</summary>
        public string Summary { get; }

        /// <summary>A verbose explanation of the operation behavior. GFM syntax can be used for rich text representation.</summary>
        public string Description { get; }

        /// <summary>Additional external documentation for this operation.</summary>
        public ExternalDocumentation ExternalDocs { get; }

        /// <summary>Unique string used to identify the operation. The id MUST be unique among all operations described in the API. Tools and libraries MAY use the operationId to uniquely identify an operation, therefore, it is recommended to follow common programming naming conventions.</summary>
        public string OperationId { get; }

        /// <summary>A list of MIME types the operation can consume. This overrides the consumes definition at the Swagger Object. An empty value MAY be used to clear the global definition. Value MUST be as described under Mime Types.</summary>
        /// <remarks>http://swagger.io/specification/#mimeTypes</remarks>
        public string[] Consumes { get; }

        /// <summary>A list of MIME types the operation can produce. This overrides the produces definition at the Swagger Object. An empty value MAY be used to clear the global definition. Value MUST be as described under Mime Types.</summary>
        /// <remarks>http://swagger.io/specification/#mimeTypes</remarks>
        public string[] Produces { get; }

        /// <summary>A list of parameters that are applicable for this operation. If a parameter is already defined at the Path Item, the new definition will override it, but can never remove it. The list MUST NOT include duplicated parameters. A unique parameter is defined by a combination of a name and location. The list can use the Reference Object to link to parameters that are defined at the Swagger Object's parameters. There can be one "body" parameter at most.</summary>
        public IOperationParameter[] Parameters { get; }

        /// <summary>Required. The list of possible responses as they are returned from executing this operation.</summary>
        public Dictionary<HttpStatusCode?, IResponseObject> Responses { get; } = new Dictionary<HttpStatusCode?, IResponseObject>();

        /// <summary>
        /// The transfer protocol for the operation. Values MUST be from the list: "http", "https", "ws", "wss". The value overrides the Swagger Object schemes definition.
        /// </summary>
        public string[] Schemes { get; }

        /// <summary>
        /// Declares this operation to be deprecated. Usage of the declared operation should be refrained. Default value is false.
        /// </summary>
        public bool? Deprecated { get; }

        /// <summary>
        /// A declaration of which security schemes are applied for this operation. The list of values describes alternative security schemes that can be used (that is, there is a logical OR between the security requirements). This definition overrides any declared top-level security. To remove a top-level security declaration, an empty array can be used.
        /// </summary>
        /// <remarks>
        /// Lists the required security schemes to execute this operation. The object can have multiple security schemes declared in it which are all required (that is, there is a logical AND between the schemes).
        /// The name used for each property MUST correspond to a security scheme declared in the Security Definitions.
        /// Each name must correspond to a security scheme which is declared in the Security Definitions. If the security scheme is of type "oauth2", then the value is a list of scope names required for the execution. For other security scheme types, the array MUST be empty.
        /// </remarks>
        public Dictionary<string, string[]>[] Security { get; }
    }
}