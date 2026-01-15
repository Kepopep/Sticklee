using TODO.Application.HabitLog.Create;
using TODO.Application.HabitLog.Delete;
using TODO.Application.HabitLog.Get;

namespace TODO.Application.HabitLog;

public static class HabitLogServiceExtensions
{
    public static IServiceCollection AddHabitLogServices(
        this IServiceCollection services)
    {
        services.AddScoped<ICreateHabitLogService, CreateHabitLogService>();
        services.AddScoped<IGetHabitLogService, GetHabitLogService>();
        services.AddScoped<IDeleteHabitLogService, DeleteHabitLogService>();

        return services;
    } 
}