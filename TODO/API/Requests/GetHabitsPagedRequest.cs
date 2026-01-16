namespace TODO.API.Requests;

public record GetHabitsPagedRequest(
    int Page = 1,
    int PageSize = 10);