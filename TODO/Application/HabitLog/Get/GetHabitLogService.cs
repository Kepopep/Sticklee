using Microsoft.EntityFrameworkCore;
using TODO.Application.HabitLog.Create;
using TODO.Infrastructure;

namespace TODO.Application.HabitLog.Get;

public class GetHabitLogService : IGetHabitLogService
{
    private readonly AppDbContext _dbContext;

    public GetHabitLogService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<HabitLogDto> ExecuteAsync(GetHabitLogServiceDto dto)
    {
        var habitLog = await _dbContext.HabitLogs
            .AsNoTracking()
            .FirstOrDefaultAsync(l =>
                l.Id == dto.HabitLogId &&
                l.UserId == dto.UserId);

        if (habitLog is null)
            throw new DomainException("Habit completion not found");

        return new HabitLogDto(
            Id: habitLog.Id,
            Date: habitLog.Date,
            HabitId: habitLog.HabitId,
            UserId: habitLog.UserId);
    }
}