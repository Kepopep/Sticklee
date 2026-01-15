namespace TODO.Application.HabitLog;

public record class HabitLogDto (
    Guid Id, 
    DateOnly Date, 
    Guid HabitId,
    Guid UserId);