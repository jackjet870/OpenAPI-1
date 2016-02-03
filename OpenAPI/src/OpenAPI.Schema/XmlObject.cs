using System;

namespace OpenAPI.Schema
{
    /// <summary>A metadata object that allows for more fine-tuned XML model definitions.
    /// When using arrays, XML element names are not inferred (for singular/plural forms) and the name property should be used to add that information. See examples for expected behavior.</summary>
    public class XmlObject
    {
        public XmlObject()
        {
        }

        /// <summary>Replaces the name of the element/attribute used for the described schema property. When defined within the Items Object (items), it will affect the name of the individual XML elements within the list. When defined alongside type being array (outside the items), it will affect the wrapping element and only if wrapped is true. If wrapped is false, it will be ignored.</summary>
        public string Name { get; }

        /// <summary>The URL of the namespace definition. Value SHOULD be in the form of a URL.</summary>
        public Uri Namesapce { get; }

        /// <summary>The prefix to be used for the <see cref="P:OpenAPI.Schema.XmlObject.Name"/>.</summary>
        public string Prefix { get; }

        /// <summary>Declares whether the property definition translates to an attribute instead of an element. Default value is false.</summary>
        public bool? Attribute { get; }

        /// <summary>MAY be used only for an array definition. Signifies whether the array is wrapped (for example, &lt;books&gt;&lt;book/&gt;&lt;book/&gt;&lt;/books&gt;) or unwrapped (&lt;book/&gt;&lt;book/&gt;). Default value is false. The definition takes effect only when defined alongside type being array (outside the items).</summary>
        public bool? Wrapped { get; }

    }
}