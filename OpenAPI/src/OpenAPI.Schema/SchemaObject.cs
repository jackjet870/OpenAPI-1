using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace OpenAPI.Schema
{
    /// <summary>The Schema Object allows the definition of input and output data types. These types can be objects, but also primitives and arrays. This object is based on the JSON Schema Specification Draft 4 and uses a predefined subset of it. On top of this subset, there are extensions provided by this specification to allow for more complete documentation.
    /// Further information about the properties can be found in JSON Schema Core and JSON Schema Validation. Unless stated otherwise, the property definitions follow the JSON Schema specification as referenced here.
    /// The following properties are taken directly from the JSON Schema definition and follow the same specifications:
    ///  $ref - As a JSON Reference
    ///  format (See Data Type Formats for further details)
    ///  title
    ///  description (GFM syntax can be used for rich text representation)
    ///  default (Unlike JSON Schema, the value MUST conform to the defined type for the Schema Object)
    ///  multipleOf
    ///  maximum
    ///  exclusiveMaximum
    ///  minimum
    ///  exclusiveMinimum
    ///  maxLength
    ///  minLength
    ///  pattern
    ///  maxItems
    ///  minItems
    ///  uniqueItems
    ///  maxProperties
    ///  minProperties
    ///  required
    ///  enum
    ///  type
    /// The following properties are taken from the JSON Schema definition but their definitions were adjusted to the Swagger Specification. Their definition is the same as the one from JSON Schema, only where the original definition references the JSON Schema definition, the Schema Object definition is used instead.
    ///  items
    ///  allOf
    ///  properties
    ///  additionalProperties
    /// Other than the JSON Schema subset fields, the following fields may be used for further schema documentation.</summary>
    /// <remarks>http://swagger.io/specification/#schemaObject</remarks>
    public class SchemaObject : JSchema
    {
        private string discriminator;

        private bool? readOnly;

        private XmlObject xml;

        private ExternalDocumentation externalDocs;

        private string example;

        /// <summary>Adds support for polymorphism. The discriminator is the schema property name that is used to differentiate between other schema that inherit this schema. The property name used MUST be defined at this schema and it MUST be in the required property list. When used, the value MUST be the name of this schema or any schema that inherits it.</summary>
        public string Discriminator
        {
            get
            {
                return this.discriminator;
            }
            set
            {
                this.discriminator = value;
                if (value == null)
                {
                    this.ExtensionData.Remove("discriminator");
                }
                else
                {
                    this.ExtensionData["discriminator"] = value.ToJson();
                }
            }
        }

        /// <summary>Relevant only for Schema "properties" definitions. Declares the property as "read only". This means that it MAY be sent as part of a response but MUST NOT be sent as part of the request. Properties marked as readOnly being true SHOULD NOT be in the required list of the defined schema. Default value is false.</summary>
        public bool? ReadOnly
        {
            get
            {
                return this.readOnly;
            }
            set
            {
                this.readOnly = value;
                if (value == null)
                {
                    this.ExtensionData.Remove("readOnly");
                }
                else
                {
                    this.ExtensionData["readOnly"] = value.ToJson();
                }
            }
        }

        /// <summary>This MAY be used only on properties schemas. It has no effect on root schemas. Adds Additional metadata to describe the XML representation format of this property.</summary>
        public XmlObject Xml
        {
            get
            {
                return this.xml;
            }
            set
            {
                this.xml = value;
                if (value == null)
                {
                    this.ExtensionData.Remove("xml");
                }
                else
                {
                    this.ExtensionData["xml"] = value.ToJson();
                }
            }
        }

        /// <summary>Additional external documentation for this schema.</summary>
        public ExternalDocumentation ExternalDocs
        {
            get
            {
                return this.externalDocs;
            }
            set
            {
                this.externalDocs = value;
                if (value == null)
                {
                    this.ExtensionData.Remove("externalDocs");
                }
                else
                {
                    this.ExtensionData["externalDocs"] = value.ToJson();
                }
            }
        }

        /// <summary>A free-form property to include a an example of an instance for this schema.</summary>
        public string Example
        {
            get
            {
                return this.example;
            }
            set
            {
                this.example = value;
                if (value == null)
                {
                    this.ExtensionData.Remove("example");
                }
                else
                {
                    this.ExtensionData["example"] = value.ToJson();
                }
            }
        }
    }
}