using Microsoft.EntityFrameworkCore;
using TODO.Application.HabitLog.Create;
using TODO.Infrastructure;

namespace TODO.Application.Habit.Update;

public class UpdateHabitService : IUpdateHabitService
{
    private readonly AppDbContext _dbContext;

    public UpdateHabitService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ExecuteAsync(UpdateHabitDto dto)
    {
        // Шаг 1. Получение сущности
        var habit = await _dbContext.Habits
            .FirstOrDefaultAsync(h =>
                h.Id == dto.HabitId &&
                h.UserId == dto.UserId);

        // Шаг 2. Проверка доступа и существования
        if (habit is null)
        {
            throw new DomainException("Habit not found");
        }

        // Шаг 3. Обновление состояния доменной сущности
        habit.Name = dto.Name;
        habit.Frequency = dto.Frequency;

        // Шаг 4. Сохранение изменений
        await _dbContext.SaveChangesAsync();
    }
}