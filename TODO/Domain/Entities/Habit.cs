using TODO.Application.Exceptions;
using TODO.Domain.Enum;

namespace TODO.Domain.Entities;

public class Habit
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Name { get; set; }
    public Frequency Frequency { get; set; }

    private Habit() { } // EF

    public Habit(Guid userId, string name, Frequency frequency)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException("Habit name is required");
        }

        Id = Guid.NewGuid();
        UserId = userId;
        Name = name;
        Frequency = frequency;
    }
}