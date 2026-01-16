namespace TODO.Application.HabitLog.GetById;

using TODO.Application.HabitLog;

public record class GetHabitLogByIdDto(Guid Id)
{
    public HabitLogDto? HabitLog { get; set; }
}