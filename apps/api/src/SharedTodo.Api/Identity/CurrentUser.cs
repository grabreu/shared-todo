namespace SharedTodo.Api.Identity;

public class CurrentUser(IHttpContextAccessor accessor)
{
    public Guid UserId =>
        Guid.TryParse(
            accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier),
            out var id)
            ? id
            : throw new InvalidOperationException("User ID claim was not found.");
}
