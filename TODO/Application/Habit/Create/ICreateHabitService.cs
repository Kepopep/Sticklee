namespace TODO.Application.Habit.Create;

public interface ICreateHabitService
{
    Task<HabitDto> ExecuteAsync(CreateHabitServiceDto dto); 
}