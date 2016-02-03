using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using Newtonsoft.Json.Linq;

namespace OpenAPI.Schema
{
    public static class SerializationExtensions
    {
        public static JObject ToJson(this SwaggerObject root)
        {
            var jRoot = new JObject
                        {
                            { "swagger", root.Swagger.ToJson() }
                        };
            jRoot.AddOptional("info", root.Info.ToJson());
            jRoot.AddOptional("host", root.Host.ToJson());
            jRoot.AddOptional("basePath", root.BasePath.ToJson());
            jRoot.AddOptional("schemes", root.Schemes.ToJson());
            jRoot.AddOptional("consumes", root.Consumes.ToJson());
            jRoot.AddOptional("produces", root.Produces.ToJson());
            jRoot.AddOptional("paths", root.Paths.ToJson());
            return jRoot;
        }

        private static JObject ToJson(this Info info)
        {
            if (info == null)
            {
                return null;
            }
            var jInfo = new JObject
                        {
                            { "title", info.Title.ToJson() }
                        };
            jInfo.AddOptional("description", info.Description.ToJson());
            jInfo.AddOptional("termsOfService", info.TermsOfService.ToJson());
            jInfo.AddOptional("contact", info.Contact.ToJson());
            jInfo.AddOptional("license", info.License.ToJson());
            jInfo.AddOptional("version", info.Version.ToJson());
            return jInfo;
        }

        private static JObject ToJson(this Contact contact)
        {
            if (contact == null)
            {
                return null;
            }
            var jContact = new JObject();
            jContact.AddOptional("name", contact.Name.ToJson());
            jContact.AddOptional("url", contact.Url.ToJson());
            jContact.AddOptional("rmail", contact.Email.ToJson());
            return jContact;
        }

        private static JObject ToJson(this License license)
        {
            if (license == null)
            {
                return null;
            }
            var jLicense = new JObject
                           {
                               { "name", license.Name.ToJson() }
                           };
            jLicense.AddOptional("url", license.Url.ToJson());
            return jLicense;
        }

        private static JToken ToJson(this PathItem path)
        {
            if (path == null)
            {
                return JValue.CreateNull();
            }
            var jPath = new JObject();
            jPath.AddOptional("$ref", path.Ref.ToJson());
            jPath.AddOptional("get", path.Get.ToJson());
            jPath.AddOptional("put", path.Put.ToJson());
            jPath.AddOptional("post", path.Post.ToJson());
            jPath.AddOptional("delete", path.Delete.ToJson());
            jPath.AddOptional("options", path.Options.ToJson());
            jPath.AddOptional("head", path.Head.ToJson());
            jPath.AddOptional("patch", path.Patch.ToJson());
            jPath.AddOptional("parameters", path.Parameters.ToJson());
            return jPath;
        }

        private static JObject ToJson(this Operation operation)
        {
            if (operation == null)
            {
                return null;
            }
            var jOperation = new JObject
                             {
                                 { "responses", operation.Responses.ToJson() }
                             };
            jOperation.AddOptional("tags", operation.Tags.ToJson());
            jOperation.AddOptional("summary", operation.Summary.ToJson());
            jOperation.AddOptional("description", operation.Description.ToJson());
            jOperation.AddOptional("externalDocs", operation.ExternalDocs.ToJson());
            jOperation.AddOptional("operationId", operation.OperationId.ToJson());
            jOperation.AddOptional("consumes", operation.Consumes.ToJson());
            jOperation.AddOptional("produces", operation.Produces.ToJson());
            jOperation.AddOptional("parameters", operation.Parameters.ToJson());
            jOperation.AddOptional("schemes", operation.Schemes.ToJson());
            jOperation.AddOptional("deprecated", operation.Deprecated.ToJson());
            jOperation.AddOptional("security", operation.Security.ToJson());
            return jOperation;
        }

        private static JToken ToJson(this IOperationParameter operationParameter)
        {
            if (operationParameter == null)
            {
                return JValue.CreateNull();
            }
            var reference = operationParameter as Reference;
            if (reference != null)
            {
                return reference.ToJson();
            }

            var parameter = operationParameter as Parameter;
            if (parameter == null)
            {
                throw new ArgumentException($"Invalid operation parameter type {operationParameter.GetType()}", nameof(operationParameter));
            }

            var jParameter = new JObject
                             {
                { "name", parameter.Name.ToJson() },
                { "in", parameter.In.ToJson() }
                             };
            jParameter.AddOptional("description", parameter.Description.ToJson());
            jParameter.AddOptional("required", parameter.Required.ToJson());

            var body = parameter as BodyParameter;
            if (body != null)
            {
                jParameter.Add("schema", body.Schema.ToJson());
                return jParameter;
            }

            var notBody = parameter as INotBodyParameter;
            if (notBody == null)
            {
                throw new ArgumentException($"Invalid operation parameter type {operationParameter.GetType()}", nameof(operationParameter));
            }

            jParameter.Add("type", notBody.Type.ToJson());
            jParameter.AddOptional("format", notBody.Format.ToJson());
            jParameter.AddOptional("allowEmptyValue", notBody.AllowEmptyValue.ToJson());
            if (notBody.Type == ParameterType.Array)
            {
                if (notBody.Items == null)
                {
                    throw new ArgumentException("Parameter type is array but items not specified", nameof(operationParameter));
                }
                jParameter.Add("items", notBody.Items.ToJson());
            }
            else
            {
                jParameter.AddOptional("items", notBody.Items.ToJson());
            }
            jParameter.AddOptional("collectionFormat", notBody.CollectionFormat.ToJson());
            jParameter.AddOptional("default", notBody.Default);
            jParameter.AddOptional("maximum", notBody.Maximum.ToJson());
            jParameter.AddOptional("exclusiveMaximum", notBody.ExclusiveMaximum.ToJson());
            jParameter.AddOptional("minimum", notBody.Minimum.ToJson());
            jParameter.AddOptional("exclusiveMinimum", notBody.ExclusiveMinimum.ToJson());
            jParameter.AddOptional("maxLength", notBody.MaxLength.ToJson());
            jParameter.AddOptional("minLength", notBody.MinLength.ToJson());
            jParameter.AddOptional("pattern", notBody.Pattern.ToJson());
            jParameter.AddOptional("maxItems", notBody.MaxItems.ToJson());
            jParameter.AddOptional("minItems", notBody.MinItems.ToJson());
            jParameter.AddOptional("uniqueItems", notBody.UniqueItems.ToJson());
            jParameter.AddOptional("enum", notBody.Enum);
            jParameter.AddOptional("multipleOf", notBody.MultipleOf.ToJson());
            return jParameter;
        }

        private static JObject ToJson(this SchemaObject schema) => schema == null ? null : JObject.Parse(schema.ToString());

        public static JObject ToJson(this XmlObject xml)
        {
            if (xml == null)
            {
                return null;
            }
            var jXml = new JObject();
            jXml.AddOptional("name", xml.Name.ToJson());
            jXml.AddOptional("namesapce", xml.Namesapce.ToJson());
            jXml.AddOptional("prefix", xml.Prefix.ToJson());
            jXml.AddOptional("attribute", xml.Attribute.ToJson());
            jXml.AddOptional("wrapped", xml.Wrapped.ToJson());
            return jXml;
        }

        public static JObject ToJson(this ExternalDocumentation doc)
        {
            if (doc == null)
            {
                return null;
            }
            var jDoc = new JObject
                       {
                           { "url", doc.Url.ToJson() }
                       };
            jDoc.AddOptional("description", doc.Description.ToJson());
            return jDoc;
        }

        private static JObject ToJson(this ItemsObject items)
        {
            if (items == null)
            {
                return null;
            }
            var jItems = new JObject
                         {
                             { "type", items.Type.ToJson() }
                         };
            jItems.AddOptional("format", items.Format.ToJson());
            if (items.Type == ItemsType.Array)
            {
                if (items.Items == null)
                {
                    throw new ArgumentException("Items type is array but items not specified", nameof(items));
                }
                jItems.Add("items", items.Items.ToJson());
            }
            else
            {
                jItems.AddOptional("items", items.Items.ToJson());
            }
            jItems.AddOptional("collectionFormat", items.CollectionFormat.ToJson());
            jItems.AddOptional("default", items.Default);
            jItems.AddOptional("maximum", items.Maximum.ToJson());
            jItems.AddOptional("exclusiveMaximum", items.ExclusiveMaximum.ToJson());
            jItems.AddOptional("minimum", items.Minimum.ToJson());
            jItems.AddOptional("exclusiveMinimum", items.ExclusiveMinimum.ToJson());
            jItems.AddOptional("maxLength", items.MaxLength.ToJson());
            jItems.AddOptional("minLength", items.MinLength.ToJson());
            jItems.AddOptional("pattern", items.Pattern.ToJson());
            jItems.AddOptional("maxItems", items.MaxItems.ToJson());
            jItems.AddOptional("minItems", items.MinItems.ToJson());
            jItems.AddOptional("uniqueItems", items.UniqueItems.ToJson());
            jItems.AddOptional("enum", items.Enum);
            jItems.AddOptional("multipleOf", items.MultipleOf.ToJson());
            return jItems;
        }

        private static JObject ToJson(this IResponseObject responseObject)
        {
            if (responseObject == null)
            {
                throw new ArgumentNullException(nameof(responseObject));
            }
            var reference = responseObject as Reference;
            if (reference != null)
            {
                return reference.ToJson();
            }
            var response = responseObject as Response;
            if (response == null)
            {
                throw new ArgumentException($"Invalid operation parameter type {responseObject.GetType()}", nameof(responseObject));
            }
            var jResponse = new JObject
                            {
                                { "description", response.Description.ToJson() }
                            };
            jResponse.AddOptional("schema", response.Schema.ToJson());
            jResponse.AddOptional("headers", response.Headers.ToJson());
            jResponse.AddOptional("examples", response.Examples.ToJson());
            return jResponse;
        }

        private static JToken ToJson(this Header header)
        {
            if (header == null)
            {
                return JValue.CreateNull();
            }
            var jHeader = new JObject();
            jHeader.AddOptional("description", header.Description.ToJson());
            jHeader.Add("type", header.Type.ToJson());
            jHeader.AddOptional("format", header.Format.ToJson());
            jHeader.Add("items", header.Items.ToJson());
            jHeader.AddOptional("collectionFormat", header.CollectionFormat.ToJson());
            jHeader.AddOptional("default", header.Default);
            jHeader.AddOptional("maximum", header.Maximum.ToJson());
            jHeader.AddOptional("exclusiveMaximum", header.ExclusiveMaximum.ToJson());
            jHeader.AddOptional("minimum", header.Minimum.ToJson());
            jHeader.AddOptional("exclusiveMinimum", header.ExclusiveMinimum.ToJson());
            jHeader.AddOptional("maxLength", header.MaxLength.ToJson());
            jHeader.AddOptional("minLength", header.MinLength.ToJson());
            jHeader.AddOptional("pattern", header.Pattern.ToJson());
            jHeader.AddOptional("maxItems", header.MaxItems.ToJson());
            jHeader.AddOptional("minItems", header.MinItems.ToJson());
            jHeader.AddOptional("uniqueItems", header.UniqueItems.ToJson());
            jHeader.AddOptional("enum", header.Enum);
            jHeader.AddOptional("multipleOf", header.MultipleOf.ToJson());
            return jHeader;
        }

        private static JObject ToJson(this Reference reference)
        {
            if (reference == null)
            {
                return null;
            }
            return new JObject
                   {
                       { "$ref", reference.Ref.ToJson() }
                   };
        }

        private static JValue ToJson(this ParameterLocation location)
        {
            switch (location)
            {
                case ParameterLocation.Query:
                    return "query".ToJson();
                case ParameterLocation.Header:
                    return "header".ToJson();
                case ParameterLocation.Path:
                    return "path".ToJson();
                case ParameterLocation.FormData:
                    return "formData".ToJson();
                case ParameterLocation.Body:
                    return "body".ToJson();
                default:
                    throw new ArgumentOutOfRangeException(nameof(location), location, null);
            }
        }

        private static JValue ToJson(this ParameterType type)
        {
            switch (type)
            {
                case ParameterType.String:
                    return "string".ToJson();
                case ParameterType.Number:
                    return "number".ToJson();
                case ParameterType.Integer:
                    return "integer".ToJson();
                case ParameterType.Boolean:
                    return "boolean".ToJson();
                case ParameterType.Array:
                    return "array".ToJson();
                case ParameterType.File:
                    return "file".ToJson();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private static JValue ToJson(this ItemsType type)
        {
            switch (type)
            {
                case ItemsType.String:
                    return "string".ToJson();
                case ItemsType.Number:
                    return "number".ToJson();
                case ItemsType.Integer:
                    return "integer".ToJson();
                case ItemsType.Boolean:
                    return "boolean".ToJson();
                case ItemsType.Array:
                    return "array".ToJson();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private static string GetCode(this HttpStatusCode? code) => code.HasValue ? ((int)code.Value).ToString() : "default";

        public static JValue ToJson(this bool? value) => value.ToJson(v => v.ToJson());
        private static JValue ToJson(this bool value) => new JValue(value);
        private static JValue ToJson(this ulong? value) => value.ToJson(v => v.ToJson());
        private static JValue ToJson(this ulong value) => new JValue(value);
        private static JValue ToJson(this uint? value) => value.ToJson(v => v.ToJson());
        private static JValue ToJson(this uint value) => new JValue(value);

        public static JValue ToJson(this string value) => value == null ? null : JValue.CreateString(value);

        private static JValue ToJson(this Uri value) => value?.ToString().ToJson();

        private static JValue ToJson<T>(this T? value, Func<T, JValue> toJson) where T : struct => value == null ? null : toJson(value.Value);

        private static JArray ToJson<T>(this T[] values, Func<T, JToken> toJson) => values == null ? null : new JArray(values.Select(toJson));

        private static JToken ToJson<T>(this Dictionary<string, T> values, Func<T, JToken> toJson, JToken nullToken = null) => values.ToJson(k => k, toJson, nullToken);

        private static JToken ToJson<TKey, TValue>(this Dictionary<TKey, TValue> values, Func<TKey, string> toString, Func<TValue, JToken> toJson, JToken nullToken = null)
        {
            if (values == null)
            {
                return nullToken;
            }
            var jItems = new JObject();
            foreach (var item in values)
            {
                jItems.Add(toString(item.Key), toJson(item.Value));
            }
            return jItems;
        }

        private static JArray ToJson(this IOperationParameter[] values) => values.ToJson(v => v.ToJson());
        private static JArray ToJson(this string[] values) => values.ToJson(v => v.ToJson());

        private static JArray ToJson(this Dictionary<string, string[]>[] values) => values.ToJson(v => v.ToJson());

        private static JToken ToJson(this Dictionary<string, string[]> values) => values.ToJson(a => a.ToJson(s => s.ToJson()), JValue.CreateNull());
        private static JToken ToJson(this Dictionary<string, string> values) => values.ToJson(a => a.ToJson());

        private static JToken ToJson(this Dictionary<string, PathItem> values) => values.ToJson(p => p.ToJson());
        private static JToken ToJson(this Dictionary<string, Header> values) => values.ToJson(p => p.ToJson());
        private static JToken ToJson(this Dictionary<HttpStatusCode?, IResponseObject> values) => values.ToJson(k => k.GetCode(), r => r.ToJson());

        private static void AddOptional(this JObject target, string name, JToken value)
        {
            if (value != null)
            {
                target.Add(name, value);
            }
        }
    }
}