namespace OpenAPI.Schema
{
    /// <summary>A simple object to allow referencing other definitions in the specification. It can be used to reference parameters and responses that are defined at the top level for reuse.
    /// The Reference Object is a JSON Reference that uses a JSON Pointer as its value. For this specification, only canonical dereferencing is supported.</summary>
    public class Reference : IOperationParameter, IResponseObject
    {
        public Reference()
        {
        }

        /// <summary>Required. The reference string.</summary>
        public string Ref { get; }
    }
}