using Microsoft.EntityFrameworkCore;
using TODO.Infrastructure;

namespace TODO.Application.HabitLog.GetDay;

public class GetHabitLogByDayService : IGetHabitLogByDayService
{
    private readonly AppDbContext _dbContext;

    public GetHabitLogByDayService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<HabitLogDto>> ExecuteAsync(GetHabitLogByDayServiceDto dto)
    {
        var habitLogs = await _dbContext.HabitLogs
            .AsNoTracking()
            .Where(hl => hl.UserId == dto.UserId && hl.Date == dto.Date)
            .Select(hl => new HabitLogDto(
                hl.Id,
                hl.Date,
                hl.HabitId,
                hl.UserId))
            .ToListAsync();

        return habitLogs;
    }
}