namespace TODO.Model.DTO;

public class HabitLogCreateData
{
    public DateTime Date { get; set; }
    
    public bool Completed { get; set; }
    
    public Guid HabitId { get; set; }
}