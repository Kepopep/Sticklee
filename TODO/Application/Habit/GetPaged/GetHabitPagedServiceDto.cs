namespace TODO.Application.Habit.GetPaged;

public record GetHabitPagedServiceDto(    
    int Page,
    int PageSize,
    DateOnly Date);