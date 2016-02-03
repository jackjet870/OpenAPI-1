namespace OpenAPI.Schema
{
    /// <summary>Describes a single operation parameter.
    /// A unique parameter is defined by a combination of a name and location.
    /// There are five possible parameter types.
    ///  Path - Used together with Path Templating, where the parameter value is actually part of the operation's URL. This does not include the host or base path of the API. For example, in /items/{itemId}, the path parameter is itemId.
    ///  Query - Parameters that are appended to the URL. For example, in /items?id=###, the query parameter is id.
    ///  Header - Custom headers that are expected as part of the request.
    ///  Body - The payload that's appended to the HTTP request. Since there can only be one payload, there can only be one body parameter. The name of the body parameter has no effect on the parameter itself and is used for documentation purposes only. Since Form parameters are also in the payload, body and form parameters cannot exist together for the same operation.
    ///  Form - Used to describe the payload of an HTTP request when either application/x-www-form-urlencoded, multipart/form-data or both are used as the content type of the request (in Swagger's definition, the consumes property of an operation). This is the only parameter type that can be used to send files, thus supporting the file type. Since form parameters are sent in the payload, they cannot be declared together with a body parameter for the same operation. Form parameters have a different format based on the content-type used (for further details, consult http://www.w3.org/TR/html401/interact/forms.html#h-17.13.4):
    ///   application/x-www-form-urlencoded - Similar to the format of Query parameters but as a payload. For example, foo=1&bar=swagger - both foo and bar are form parameters. This is normally used for simple parameters that are being transferred.
    ///   multipart/form-data - each parameter takes a section in the payload with an internal header. For example, for the header Content-Disposition: form-data; name="submit-name" the name of the parameter is submit-name. This type of form parameters is more commonly used for file transfers.</summary>
    /// <remarks>http://swagger.io/specification/#parameterObject</remarks>
    public abstract class Parameter : IOperationParameter
    {
        protected Parameter(string name, ParameterLocation location)
        {
            this.In = location;
            this.Name = name;
        }

        /// <summary>Required. The name of the parameter. Parameter names are case sensitive.
        /// If in is "path", the name field MUST correspond to the associated path segment from the path field in the Paths Object. See Path Templating for further information.
        /// For all other cases, the name corresponds to the parameter name used based on the in property.</summary>
        public string Name { get; }

        /// <summary>Required. The location of the parameter. Possible values are "query", "header", "path", "formData" or "body".</summary>
        public ParameterLocation In { get; }

        /// <summary>A brief description of the parameter. This could contain examples of use. GFM syntax can be used for rich text representation.</summary>
        public string Description { get; set; }


        /// <summary>Determines whether this parameter is mandatory. If the parameter is in "path", this property is required and its value MUST be true. Otherwise, the property MAY be included and its default value is false.</summary>
        public bool? Required { get; set; }
    }
}