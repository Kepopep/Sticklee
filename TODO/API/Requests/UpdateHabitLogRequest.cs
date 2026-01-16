namespace TODO.API.Requests;

public class UpdateHabitLogRequest
{
    public DateOnly Date { get; set; }
    public Guid HabitId { get; set; }
}