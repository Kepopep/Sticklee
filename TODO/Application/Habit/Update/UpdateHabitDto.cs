using TODO.Domain.Enum;

namespace TODO.Application.Habit.Update;

public record UpdateHabitDto(
    Guid UserId,
    Guid HabitId,
    string Name,
    Frequency Frequency
);