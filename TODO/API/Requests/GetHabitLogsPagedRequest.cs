namespace TODO.API.Requests;

public class GetHabitLogsPagedRequest
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}