namespace TODO.Application.User.Create;

public record class CreateUserServiceDto(
    string Email,
    string Name,
    string Password);