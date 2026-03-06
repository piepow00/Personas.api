using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personas.api.Filter
{
    using Swashbuckle.Swagger;
    using System.Collections.Generic;
    using System.Web.Http.Description;

    public class AddAuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();

            operation.parameters.Add(new Parameter
            {
                name = "Authorization",
                @in = "header",
                description = "Bearer token",
                required = false,
                type = "string"
            });
        }
    }
}