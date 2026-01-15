namespace TODO.Application.Habit.GetById;

public interface IGetHabitByIdService
{
    Task<HabitDto> ExecuteAsync(GetHabitByIdDto dto);
}