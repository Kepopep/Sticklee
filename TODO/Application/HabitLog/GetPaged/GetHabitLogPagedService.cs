using Microsoft.EntityFrameworkCore;
using TODO.Infrastructure;

namespace TODO.Application.HabitLog.GetPaged;

public class GetHabitLogPagedService : IGetHabitLogPagedService
{
    private readonly AppDbContext _dbContext;

    public GetHabitLogPagedService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PagedResult<HabitLogDto>> ExecuteAsync(GetHabitLogPagedServiceDto dto)
    {
        var offset = (dto.Page - 1) * dto.PageSize;
        
        var habitLogs = await _dbContext.HabitLogs
            .AsNoTracking()
            .Where(hl => hl.UserId == dto.UserId)
            .OrderByDescending(hl => hl.Date)
            .Skip(offset)
            .Take(dto.PageSize + 1) // Take one extra to check if there's a next page
            .Select(hl => new HabitLogDto(
                hl.Id,
                hl.Date,
                hl.HabitId,
                hl.UserId))
            .ToListAsync();

        var hasNextPage = habitLogs.Count > dto.PageSize;
        if (hasNextPage)
        {
            habitLogs.RemoveAt(habitLogs.Count - 1); // Remove the extra item
        }

        return new PagedResult<HabitLogDto>(
            Items: habitLogs,
            Page: dto.Page,
            PageSize: dto.PageSize,
            HasNextPage: hasNextPage
        );
    }
}