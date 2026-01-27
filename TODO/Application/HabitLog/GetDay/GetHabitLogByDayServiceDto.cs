namespace TODO.Application.HabitLog.GetDay;

public record GetHabitLogByDayServiceDto(
    Guid UserId,
    DateOnly Date);
