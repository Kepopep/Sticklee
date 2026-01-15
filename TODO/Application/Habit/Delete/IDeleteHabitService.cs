namespace TODO.Application.Habit.Delete;

public interface IDeleteHabitService
{
    Task ExecuteAsync(DeleteHabitServiceDto dto);
}