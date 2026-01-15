using TODO.Application.User.Create;
using TODO.Application.User.Delete;

namespace TODO.Application.HabitLog;

public static class UserServiceExtensions
{
    public static IServiceCollection AddUserServices(
        this IServiceCollection services)
    {
        services.AddScoped<ICreateUserService, CreateUserService>();
        services.AddScoped<IDeleteUserService, DeleteUserService>();

        return services;
    } 
}