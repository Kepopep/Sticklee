namespace TODO.API.Requests;

public class CreateHabitLogRequest
{
    public Guid HabitId { get; set; }
    public DateOnly Date { get; set; }
}