using TODO.Application.HabitLog;

namespace TODO.Application.Habit.Check;

public record CheckHabitDto(
    Guid HabitId,
    DateOnly Date,
    bool IsChecked);