namespace SharedTodo.Api.Features.Auth.GetCurrentUser;

public static class GetCurrentUserEndpoint
{
    public static void MapGetCurrentUserEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/auth/me", async (ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetCurrentUserQuery();
            var result = await sender.Send(query, cancellationToken);
            return result.ToOk();
        })
        .RequireAuthorization()
        .WithTags("Auth")
        .WithName("GetCurrentUser")
        .Produces<CurrentUserDto>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status401Unauthorized);
    }
}
