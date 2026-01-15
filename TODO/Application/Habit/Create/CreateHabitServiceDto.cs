using TODO.Domain.Enum;

namespace TODO.Application.Habit.Create;

public record CreateHabitServiceDto(
    Guid UserId,
    string Name,
    Frequency Frequency);