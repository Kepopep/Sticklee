using TODO.Application.HabitLog.Create;
using TODO.Application.HabitLog.Delete;
using TODO.Application.HabitLog.GetById;
using TODO.Application.HabitLog.GetPaged;
using TODO.Application.HabitLog.GetDay;
using TODO.Application.HabitLog.Update;

namespace TODO.Application.HabitLog;

public static class HabitLogServiceExtensions
{
    public static IServiceCollection AddHabitLogServices(
        this IServiceCollection services)
    {
        services.AddScoped<ICreateHabitLogService, CreateHabitLogService>();
        services.AddScoped<IGetHabitLogByIdService, GetHabitLogByIdService>();
        services.AddScoped<IGetHabitLogPagedService, GetHabitLogPagedService>();
        services.AddScoped<IGetHabitLogByDayService, GetHabitLogByDayService>();
        services.AddScoped<IUpdateHabitLogService, UpdateHabitLogService>();
        services.AddScoped<IDeleteHabitLogService, DeleteHabitLogService>();

        return services;
    } 
}