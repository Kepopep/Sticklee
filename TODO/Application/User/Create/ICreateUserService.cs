namespace TODO.Application.User.Create;

public interface ICreateUserService
{
    Task<UserDto> ExecuteAsync(CreateUserServiceDto serviceDto);
}