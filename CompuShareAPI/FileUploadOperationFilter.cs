using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CompuShareAPI
{
    public class FileUploadOperationFilter: IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var fileParameter = context.MethodInfo
                .GetParameters()
                .Any(p => p.ParameterType == typeof(IFormFile));

            if (fileParameter)
            {
                operation.Parameters.Clear();
                operation.RequestBody = new OpenApiRequestBody
                {
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["multipart/form-data"] = new OpenApiMediaType
                        {
                            Schema = new OpenApiSchema
                            {
                                Type = "object",
                                Properties = new Dictionary<string, OpenApiSchema>
                                {
                                    ["file"] = new OpenApiSchema
                                    {
                                        Type = "string",
                                        Format = "binary"
                                    }
                                }
                            }
                        }
                    }
                };
            }
        }
    }
}
