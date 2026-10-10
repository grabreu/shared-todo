namespace SharedTodo.Api.OpenApi;

public class OpenApiVersioningTransformer : IOpenApiDocumentTransformer
{
    public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
    {
        document.Info = new OpenApiInfo
        {
            Title = "SharedTodo API",
            Version = "v1",
            Description = "API for managing shared todo items.",
            Contact = new OpenApiContact
            {
                Name = "Gabriel Abreu",
                Url = new Uri("https://grabreu.dev")
            }
        };

        return Task.CompletedTask;
    }
}
