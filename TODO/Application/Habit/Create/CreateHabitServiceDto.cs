using TODO.Domain.Enum;

namespace TODO.Application.Habit.Create;

public record CreateHabitServiceDto(
    string Name,
    Frequency Frequency);