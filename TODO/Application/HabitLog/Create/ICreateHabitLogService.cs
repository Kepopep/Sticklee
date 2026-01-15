namespace TODO.Application.HabitLog.Create;

public interface ICreateHabitLogService
{
    public Task<HabitLogDto> ExecuteAsync(Guid userId, CreateHabitLogDto dto);
}