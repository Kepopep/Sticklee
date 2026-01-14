using TODO.Logic.Interfaces;

namespace TODO.Model;

public class HabitLog : IHasId
{
    public Guid Id { get; set; }
    
    public DateTime Date { get; set; }
    public bool Completed { get; set; }
    
    public Guid HabitId { get; set; }
    
    private Habit _habit;

    public Habit Habit
    {
        get => _habit;
        set
        {
            HabitId = value.Id;
            _habit = value;
        }
    }
}