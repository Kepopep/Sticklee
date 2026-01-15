using TODO.Application.Habit;
using TODO.Application.HabitLog;
using TODO.Application.User.Create;

namespace TODO.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddHabitServices();
        services.AddHabitLogServices();
        services.AddUserServices();

        return services;
    }
}