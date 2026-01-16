namespace TODO.Application.HabitLog.Update;

public record UpdateHabitLogDto(
    Guid UserId,
    Guid HabitLogId,
    DateOnly Date,
    Guid HabitId);