namespace SharedTodo.Api.Features.Auth.Login;

public record LoginCommand(string Email, string Password) : ICommand<Result<TokenDto>>;
