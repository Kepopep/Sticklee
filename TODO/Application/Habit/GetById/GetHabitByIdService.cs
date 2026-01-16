using Microsoft.EntityFrameworkCore;
using TODO.Application.HabitLog.Create;
using TODO.Domain;
using TODO.Infrastructure;

namespace TODO.Application.Habit.GetById;

public class GetHabitByIdService : IGetHabitByIdService
{
    private readonly AppDbContext _dbContext;

    public GetHabitByIdService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<HabitDto> ExecuteAsync(GetHabitByIdDto dto)
    {
        // Шаг 1. Запрос строго по пользователю и Id
        var habit = await _dbContext.Habits
            .AsNoTracking()
            .FirstOrDefaultAsync(h =>
                h.UserId == dto.UserId &&
                h.Id == dto.HabitId);

        // Шаг 2. Проверка существования
        if (habit is null)
        {
            throw new DomainException("Habit not found");
        }

        // Шаг 3. Маппинг в DTO
        return new HabitDto(
            habit.Id,
            habit.UserId,
            habit.Name,
            habit.Frequency);
    }
}