namespace TODO.Application.HabitLog.GetPaged;

public record GetHabitLogPagedServiceDto(
    Guid UserId,
    int Page,
    int PageSize);