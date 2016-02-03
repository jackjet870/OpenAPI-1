using Newtonsoft.Json.Linq;

namespace OpenAPI.Schema
{
    public interface INotBodyParameter
    {
        /// <summary>Required. The type of the parameter. Since the parameter is not located at the request body, it is limited to simple types (that is, not an object). The value MUST be one of "string", "number", "integer", "boolean", "array" or "file". If type is "file", the consumes MUST be either "multipart/form-data", " application/x-www-form-urlencoded" or both and the parameter MUST be in "formData".</summary>
        ParameterType Type { get; }

        /// <summary>The extending format for the previously mentioned type. See Data Type Formats for further details.</summary>
        /// <remarks>http://swagger.io/specification/#dataTypeFormat</remarks>
        string Format { get; set; }

        /// <summary>Sets the ability to pass empty-valued parameters. This is valid only for either query or formData parameters and allows you to send a parameter with a name only or an empty value. Default value is false.</summary>
        bool? AllowEmptyValue { get; set; }

        /// <summary>Required if type is "array". Describes the type of items in the array.</summary>
        ItemsObject Items { get; }

        /// <summary>Determines the format of the array if type array is used. Possible values are:
        ///  csv - comma separated values foo,bar.
        ///  ssv - space separated values foo bar.
        ///  tsv - tab separated values foo\tbar.
        ///  pipes - pipe separated values foo|bar.
        /// Default value is csv.</summary>
        string CollectionFormat { get; set; }

        /// <summary>Declares the value of the item that the server will use if none is provided. (Note: "default" has no meaning for required items.) See http://json-schema.org/latest/json-schema-validation.html#anchor101. Unlike JSON Schema this value MUST conform to the defined type for the data type.</summary>
        JToken Default { get; set; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor17.
        /// </summary>
        ulong? Maximum { get; set; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor17.
        /// </summary>
        bool? ExclusiveMaximum { get; set; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor21.
        /// </summary>
        ulong? Minimum { get; set; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor21.
        /// </summary>
        bool? ExclusiveMinimum { get; set; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor26.
        /// </summary>
        uint? MaxLength { get; set; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor29.
        /// </summary>
        uint? MinLength { get; set; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor33.
        /// </summary>
        string Pattern { get; set; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor42.
        /// </summary>
        uint? MaxItems { get; set; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor45.
        /// </summary>
        uint? MinItems { get; set; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor49.
        /// </summary>
        bool? UniqueItems { get; set; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor79.
        /// </summary>
        JArray Enum { get; set; }

        /// <summary>See http://json-schema.org/latest/json-schema-validation.html#anchor14.
        /// </summary>
        ulong? MultipleOf { get; set; }
    }
}