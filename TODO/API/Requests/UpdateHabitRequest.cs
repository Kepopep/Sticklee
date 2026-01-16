using TODO.Domain.Enum;

namespace TODO.API.Requests;

public record UpdateHabitRequest(
    string Name,
    Frequency Frequency);