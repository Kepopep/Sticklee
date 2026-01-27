namespace TODO.API.Requests;

public record GetHabitsPagedRequest(
    DateOnly Date,
    int Page = 1,
    int PageSize = 10);