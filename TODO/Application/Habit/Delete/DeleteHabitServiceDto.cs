namespace TODO.Application.Habit.Delete;

public record DeleteHabitServiceDto(
    Guid UserId,
    Guid HabitId);