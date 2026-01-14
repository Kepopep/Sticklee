using TODO.Logic.Interfaces;

namespace TODO.Model;

public class User : IHasId
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "none";
}