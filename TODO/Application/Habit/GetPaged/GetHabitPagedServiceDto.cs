namespace TODO.Application.Habit.GetPaged;

public record GetHabitPagedServiceDto(    
    Guid UserId,
    int Page,
    int PageSize,
    DateOnly Date);