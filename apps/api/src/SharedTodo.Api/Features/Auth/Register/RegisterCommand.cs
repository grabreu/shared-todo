namespace SharedTodo.Api.Features.Auth.Register;

public record RegisterCommand(string Email, string Password, string DisplayName) : ICommand<Result<Unit>>;
