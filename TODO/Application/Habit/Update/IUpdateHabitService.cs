namespace TODO.Application.Habit.Update;

public interface IUpdateHabitService
{
    Task ExecuteAsync(UpdateHabitDto dto);
}