using Newtonsoft.Json.Linq;

namespace OpenAPI.Schema
{
    /// <summary>A limited subset of JSON-Schema's items object. It is used by parameter definitions that are not located in "body".</summary>
    /// <remarks>http://swagger.io/specification/#itemsObject</remarks>
    public class ItemsObject
    {
        public ItemsObject()
        {
        }

        /// <summary>Required. The internal type of the array. The value MUST be one of "string", "number", "integer", "boolean", or "array". Files and models are not allowed.</summary>
        public ItemsType Type { get; }


        /// <summary>The extending format for the previously mentioned type. See Data Type Formats for further details.</summary>
        /// <remarks>http://swagger.io/specification/#dataTypeFormat</remarks>
        public string Format { get; }


        /// <summary>Required if type is "array". Describes the type of items in the array.</summary>
        public ItemsObject Items { get; }

        /// <summary>Determines the format of the array if type array is used. Possible values are:
        ///  csv - comma separated values foo,bar.
        ///  ssv - space separated values foo bar.
        ///  tsv - tab separated values foo\tbar.
        ///  pipes - pipe separated values foo|bar.
        /// Default value is csv.</summary>
        public string CollectionFormat { get; }

        /// <summary>Declares the value of the item that the server will use if none is provided. (Note: "default" has no meaning for required items.) See http://json-schema.org/latest/json-schema-validation.html#anchor101. Unlike JSON Schema this value MUST conform to the defined type for the data type.</summary>
        public JToken Default { get; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor17.
        /// </summary>
        public ulong? Maximum { get; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor17.
        /// </summary>
        public bool? ExclusiveMaximum { get; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor21.
        /// </summary>
        public ulong? Minimum { get; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor21.
        /// </summary>
        public bool? ExclusiveMinimum { get; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor26.
        /// </summary>
        public uint? MaxLength { get; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor29.
        /// </summary>
        public uint? MinLength { get; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor33.
        /// </summary>
        public string Pattern { get; }
 
        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor42.
        /// </summary>
        public uint? MaxItems { get; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor45.
        /// </summary>
        public uint? MinItems { get; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor49.
        /// </summary>
        public bool? UniqueItems { get; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor79.
        /// </summary>
        public JArray Enum { get; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor14.
        /// </summary>
        public ulong? MultipleOf { get; }

    }
}