using TODO.Domain.Enum;

namespace TODO.API.Requests;

public record CreateHabitRequest(
    string Name,
    Frequency Frequency);