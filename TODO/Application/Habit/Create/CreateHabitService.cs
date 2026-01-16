using Microsoft.EntityFrameworkCore;
using TODO.Domain;
using TODO.Domain.Entities;
using TODO.Infrastructure;

namespace TODO.Application.Habit.Create;

public class CreateHabitService : ICreateHabitService
{
    private readonly AppDbContext _dbContext;
    private readonly AppIdentityDbContext _identityDbContext;

    public CreateHabitService(AppDbContext dbContext, AppIdentityDbContext identityDbContext)
    {
        _dbContext = dbContext;
        _identityDbContext = identityDbContext;
    }
    
    public async Task<HabitDto> ExecuteAsync(CreateHabitServiceDto dto)
    {
        // 1. Проверка пользователя (минимальная)
        var userExists = await _identityDbContext.Set<ApplicationUser>().
            AnyAsync(u => u.Id == dto.UserId);

        if (!userExists)
        {
            throw new DomainException("User not found");
        }

        // 2. Создание доменной сущности
        var habit = new Domain.Entities.Habit(
            dto.UserId,
            dto.Name,
            dto.Frequency);

        // 3. Сохранение
        _dbContext.Habits.Add(habit);
        await _dbContext.SaveChangesAsync();

        return new HabitDto(
            habit.Id, 
            habit.UserId, 
            habit.Name, 
            habit.Frequency);
    }
}