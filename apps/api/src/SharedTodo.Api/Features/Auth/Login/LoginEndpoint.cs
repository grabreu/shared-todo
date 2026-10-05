namespace SharedTodo.Api.Features.Auth.Login;

public static class LoginEndpoint
{
    public static void MapLoginEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/auth/login", async (LoginRequest request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new LoginCommand(request.Email, request.Password);
            var result = await sender.Send(command, cancellationToken);
            return result.ToOk();
        })
        .WithTags("Auth")
        .WithName("Login")
        .Produces<TokenDto>(StatusCodes.Status200OK)
        .ProducesValidationProblem()
        .ProducesProblem(StatusCodes.Status401Unauthorized);
    }

    public record LoginRequest(string Email, string Password);
}
