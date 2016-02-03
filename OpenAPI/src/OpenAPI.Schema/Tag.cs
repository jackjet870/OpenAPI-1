namespace OpenAPI.Schema
{
    /// <summary>
    /// Allows adding meta data to a single tag that is used by the Operation Object. It is not mandatory to have a Tag Object per tag used there.
    /// </summary>
    /// <remarks>http://swagger.io/specification/#tagObject</remarks>
    public class Tag
    {
        public Tag(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Required. The name of the tag.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// A short description for the tag. GFM syntax can be used for rich text representation.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Additional external documentation for this tag.
        /// </summary>
        public ExternalDocumentation ExternamDocs { get; set; }
    }
}