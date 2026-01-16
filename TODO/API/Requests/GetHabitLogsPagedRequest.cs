namespace TODO.API.Requests;

public record GetHabitLogsPagedRequest(
    int Page = 1,
    int PageSize = 10);