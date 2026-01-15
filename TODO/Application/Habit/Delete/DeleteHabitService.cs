using Microsoft.EntityFrameworkCore;
using TODO.Application.HabitLog.Create;
using TODO.Infrastructure;

namespace TODO.Application.Habit.Delete;

public class DeleteHabitService : IDeleteHabitService
{
    private readonly AppDbContext _dbContext;

    public DeleteHabitService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ExecuteAsync(DeleteHabitServiceDto dto)
    {
        // Шаг 1. Получение сущности
        var habit = await _dbContext.Habits
            .FirstOrDefaultAsync(h =>
                h.Id == dto.HabitId &&
                h.UserId == dto.UserId);

        // Шаг 2. Проверка существования и доступа
        if (habit is null)
            throw new DomainException("Habit not found");

        // Шаг 3. Удаление
        _dbContext.Habits.Remove(habit);

        // Шаг 4. Сохранение изменений
        await _dbContext.SaveChangesAsync();
    }
}