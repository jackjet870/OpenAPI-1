namespace OpenAPI.Schema
{
    /// <see cref="T:OpenAPI.Schema.Parameter"/>
    public class BodyParameter : Parameter
    {
        public BodyParameter(string name, SchemaObject schema)
            : base(name, ParameterLocation.Body)
        {
            this.Schema = schema;
        }

        /// <summary>Required. The schema defining the type used for the body parameter.</summary>
        public SchemaObject Schema { get; }
    }
}