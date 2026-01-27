namespace TODO.Application.HabitLog.GetDay;

public interface IGetHabitLogByDayService
{
    Task<List<HabitLogDto>> ExecuteAsync(GetHabitLogByDayServiceDto dto);
}