using SharedTodo.Api.Identity;

namespace SharedTodo.Api.Features.Auth.Login;

public class LoginCommandHandler(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager,
    JwtTokenProvider jwtTokenProvider) : ICommandHandler<LoginCommand, Result<TokenDto>>
{
    public async ValueTask<Result<TokenDto>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(command.Email);

        if (user is null)
        {
            return Error.Unauthorized(code: "Auth.InvalidCredentials", description: "Invalid credentials.");
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, command.Password, lockoutOnFailure: true);

        if (!result.Succeeded)
        {
            return Error.Unauthorized(code: "Auth.InvalidCredentials", description: "Invalid credentials.");
        }

        var accessToken = jwtTokenProvider.GenerateAccessToken(user);

        return new TokenDto(accessToken);
    }
}
