namespace SharedTodo.Api.Features.Auth.Register;

public static class RegisterEndpoint
{
    public static void MapRegisterEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/auth/register", async (RegisterRequest request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new RegisterCommand(request.Email, request.Password, request.DisplayName);
            var result = await sender.Send(command, cancellationToken);
            return result.ToNoContent();
        })
        .WithTags("Auth")
        .WithName("Register")
        .Produces(StatusCodes.Status204NoContent)
        .ProducesValidationProblem();
    }

    public record RegisterRequest(string Email, string Password, string DisplayName);
}
