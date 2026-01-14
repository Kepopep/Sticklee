using TODO.Logic.Interfaces;
using TODO.Model.Enum;

namespace TODO.Model;

public class Habit : IHasId
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "none";
    public Frequency Frequency { get; set; } = Frequency.Daily;
    
    public Guid UserId { get; set; }

    public User User
    {
        get => _user;
        set
        {
            _user = value;
            UserId = value.Id;
        }
    }

    public ICollection<HabitLog> Logs { get; set; } = new List<HabitLog>();
    
    private User _user;
}