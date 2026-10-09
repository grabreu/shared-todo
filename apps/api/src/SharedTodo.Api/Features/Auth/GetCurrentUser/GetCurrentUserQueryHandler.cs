using SharedTodo.Api.Identity;

namespace SharedTodo.Api.Features.Auth.GetCurrentUser;

public class GetCurrentUserQueryHandler(
    CurrentUser currentUser,
    UserManager<ApplicationUser> userManager)
    : IQueryHandler<GetCurrentUserQuery, Result<CurrentUserDto>>
{
    public async ValueTask<Result<CurrentUserDto>> Handle(GetCurrentUserQuery query, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(currentUser.UserId.ToString());

        if (user is null)
        {
            return Error.NotFound("User.NotFound", $"User with ID '{currentUser.UserId}' was not found.");
        }

        return new CurrentUserDto(
            user.Id,
            user.Email!,
            user.DisplayName);
    }
}
