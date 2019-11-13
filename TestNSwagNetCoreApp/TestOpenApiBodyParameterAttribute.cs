using System;
using NJsonSchema;
using NSwag;
using NSwag.Annotations;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace TestNSwagNetCoreApp
{
    public class TestOpenApiBodyParameterAttribute : OpenApiOperationProcessorAttribute
    {
        public TestOpenApiBodyParameterAttribute(string mimeType)
            : base(typeof(TestOpenApiBodyParameterProcessor), mimeType)
        {
        }

        internal class TestOpenApiBodyParameterProcessor : IOperationProcessor
        {
            private readonly string _mimeType;

            public TestOpenApiBodyParameterProcessor(string mimeType)
            {
                _mimeType = mimeType ?? throw new ArgumentNullException(nameof(mimeType));
            }

            public bool Process(OperationProcessorContext context)
            {
                if (context.OperationDescription.Operation.RequestBody == null)
                {
                    context.OperationDescription.Operation.RequestBody = new OpenApiRequestBody();
                }

                context.OperationDescription.Operation.RequestBody.Content.Clear();
                context.OperationDescription.Operation.RequestBody.Content[_mimeType] = new OpenApiMediaType
                {
                    Schema = new JsonSchema
                    {
                        Type = JsonObjectType.File
                    }
                };

                return true;
            }
        }
    }
}