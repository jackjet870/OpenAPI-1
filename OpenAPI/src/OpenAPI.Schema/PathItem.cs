﻿namespace OpenAPI.Schema
{
    /// <summary>Describes the operations available on a single path. A Path Item may be empty, due to ACL constraints. The path itself is still exposed to the documentation viewer but they will not know which operations and parameters are available.</summary>
    /// <remarks>http://swagger.io/specification/#securityFiltering</remarks>
    /// <remarks>http://swagger.io/specification/#pathItemObject</remarks>
    public class PathItem
    {
        public PathItem()
        {
        }

        /// <summary>Allows for an external definition of this path item. The referenced structure MUST be in the format of a Path Item Object. If there are conflicts between the referenced definition and this Path Item's definition, the behavior is undefined.</summary>
        public string Ref { get; }

        /// <summary>
        /// A definition of a GET operation on this path.
        /// </summary>
        public Operation Get { get; }

        /// <summary>
        /// A definition of a PUT operation on this path.
        /// </summary>
        public Operation Put { get; }

        /// <summary>
        /// A definition of a POST operation on this path.
        /// </summary>
        public Operation Post { get; }

        /// <summary>
        /// A definition of a DELETE operation on this path.
        /// </summary>
        public Operation Delete { get; }

        /// <summary>
        /// A definition of a OPTIONS operation on this path.
        /// </summary>
        public Operation Options { get; }

        /// <summary>
        /// A definition of a HEAD operation on this path.
        /// </summary>
        public Operation Head { get; }

        /// <summary>
        /// A definition of a PATCH operation on this path.
        /// </summary>
        public Operation Patch { get; }

        /// <summary>
        /// A list of parameters that are applicable for all the operations described under this path. These parameters can be overridden at the operation level, but cannot be removed there. The list MUST NOT include duplicated parameters. A unique parameter is defined by a combination of a name and location. The list can use the Reference Object to link to parameters that are defined at the Swagger Object's parameters. There can be one "body" parameter at most.
        /// </summary>
        public IOperationParameter[] Parameters { get; }
    }
}