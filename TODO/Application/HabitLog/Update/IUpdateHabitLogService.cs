namespace TODO.Application.HabitLog.Update;

public interface IUpdateHabitLogService
{
    Task ExecuteAsync(UpdateHabitLogDto dto);
}