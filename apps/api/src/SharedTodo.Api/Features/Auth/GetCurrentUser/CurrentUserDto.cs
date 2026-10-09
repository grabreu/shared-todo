namespace SharedTodo.Api.Features.Auth.GetCurrentUser;

public record CurrentUserDto(Guid Id, string Email, string DisplayName);
