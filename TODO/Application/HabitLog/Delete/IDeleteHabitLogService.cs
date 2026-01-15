namespace TODO.Application.HabitLog.Delete;

public interface IDeleteHabitLogService
{
    Task ExecuteAsync(DeleteHabitLogServiceDto dto);
}