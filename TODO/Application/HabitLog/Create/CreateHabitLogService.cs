using Microsoft.EntityFrameworkCore;
using TODO.Application.Exceptions;
using TODO.Infrastructure;

namespace TODO.Application.HabitLog.Create;

public class CreateHabitLogService : ICreateHabitLogService
{
    private readonly AppDbContext _db;

    public CreateHabitLogService(AppDbContext db)
    {
        _db = db;
    } 
    
    public async Task<HabitLogDto> ExecuteAsync(Guid userId, CreateHabitLogDto dto)
    {
        // 1. Проверяем, что привычка существует и принадлежит пользователю
        var habitExists = await _db.Habits.AnyAsync(h =>
            h.Id == dto.HabitId &&
            h.UserId == userId);

        if (!habitExists)
            throw new KeyNotFoundException("Habit not found");

        // 2. Проверяем, что лог за эту дату ещё не существует
        var alreadyLogged = await _db.HabitLogs.AnyAsync(l =>
            l.HabitId == dto.HabitId &&
            l.UserId == userId &&
            l.Date == dto.Date);

        if (alreadyLogged)
        {
            throw new DomainException("Habit already logged for this date");
        }

        // 3. Создаём domain-объект
        var log = new Domain.Entities.HabitLog(
            dto.HabitId,
            userId,
            dto.Date
        );

        // 4. Сохраняем
        _db.HabitLogs.Add(log);
        await _db.SaveChangesAsync();

        return new HabitLogDto(
            Id: log.Id, 
            Date: log.Date, 
            HabitId: log.HabitId,
            UserId: userId); 
    }
}