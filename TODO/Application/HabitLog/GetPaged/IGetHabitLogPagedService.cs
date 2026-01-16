namespace TODO.Application.HabitLog.GetPaged;

public interface IGetHabitLogPagedService
{
    Task<PagedResult<HabitLogDto>> ExecuteAsync(GetHabitLogPagedServiceDto dto);
}