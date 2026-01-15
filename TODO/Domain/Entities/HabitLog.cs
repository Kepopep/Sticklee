namespace TODO.Domain.Entities;

public class HabitLog
{
    public Guid Id { get; set; }
    
    public DateOnly Date { get; set; }
    
    public Guid HabitId { get; set; }
    public Guid UserId { get; set; }
    
    private HabitLog()
    {
        
    }
    
    public HabitLog(Guid dtoHabitId, Guid userId, DateOnly dtoDate)
    {
        
    }
}