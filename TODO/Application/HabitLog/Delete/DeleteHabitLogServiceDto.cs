namespace TODO.Application.HabitLog.Delete;

public record DeleteHabitLogServiceDto(
    Guid UserId,
    Guid HabitLogId);