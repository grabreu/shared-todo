using SharedTodo.Api.Identity;

namespace SharedTodo.Api.Features.Auth.Register;

public class RegisterCommandHandler(UserManager<ApplicationUser> userManager) : ICommandHandler<RegisterCommand, Result<Unit>>
{
    public async ValueTask<Result<Unit>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            Email = command.Email,
            UserName = command.Email,
            DisplayName = command.DisplayName,
        };

        var result = await userManager.CreateAsync(user, command.Password);

        if (!result.Succeeded)
        {
            return result.Errors
                .Select(e => Error.Validation(e.Code, e.Description))
                .ToList();
        }

        return Unit.Value;
    }
}
