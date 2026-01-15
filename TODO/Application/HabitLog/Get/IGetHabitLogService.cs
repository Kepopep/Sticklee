namespace TODO.Application.HabitLog.Get;

public interface IGetHabitLogService
{
    Task<HabitLogDto> ExecuteAsync(GetHabitLogServiceDto dto);
}