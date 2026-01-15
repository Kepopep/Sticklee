namespace TODO.Application.Habit.GetPaged;

public interface IGetHabitPagedService
{
    Task<PagedResult<HabitDto>> ExecuteAsync(GetHabitPagedServiceDto dto); 
}