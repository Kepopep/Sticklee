using System.ComponentModel.DataAnnotations;

namespace TODO.API.Requests;

public record UpdateHabitLogRequest(
    [Required] DateOnly Date,
    [Required] Guid HabitId);