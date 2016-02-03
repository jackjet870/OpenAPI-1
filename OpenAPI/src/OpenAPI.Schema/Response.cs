using System.Collections.Generic;

namespace OpenAPI.Schema
{
    /// <summary>Describes a single response from an API Operation.</summary>
    /// <remarks>http://swagger.io/specification/#responseObject</remarks>
    public class Response : IResponseObject
    {
        public Response()
        {
        }

        /// <summary>
        /// Required. A short description of the response. GFM syntax can be used for rich text representation.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// A definition of the response structure. It can be a primitive, an array or an object. If this field does not exist, it means no content is returned as part of the response. As an extension to the Schema Object, its root type value may also be "file". This SHOULD be accompanied by a relevant produces mime-type.
        /// </summary>
        public SchemaObject Schema { get; }

        /// <summary>
        /// A list of headers that are sent with the response.
        /// </summary>
        public Dictionary<string, Header> Headers { get; }

        /// <summary>
        /// An example of the response message.
        /// </summary>
        /// <remarks>The name of the property MUST be one of the Operation produces values (either implicit or inherited). The value SHOULD be an example of what such a response would look like.</remarks>
        public Dictionary<string, string> Examples { get; }
    }
}