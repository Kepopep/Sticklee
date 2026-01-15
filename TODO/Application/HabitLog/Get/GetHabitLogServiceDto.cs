namespace TODO.Application.HabitLog.Get;

public record GetHabitLogServiceDto(
    Guid UserId,
    Guid HabitLogId
);