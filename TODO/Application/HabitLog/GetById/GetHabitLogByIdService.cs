namespace TODO.Application.HabitLog.GetById;

using Microsoft.EntityFrameworkCore;
using TODO.Infrastructure;

public class GetHabitLogByIdService : IGetHabitLogByIdService
{
    private readonly AppDbContext _context;

    public GetHabitLogByIdService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetHabitLogByIdDto> ExecuteAsync(Guid id)
    {
        var habitLog = await _context.HabitLogs
            .Where(hl => hl.Id == id)
            .Select(hl => new HabitLogDto(
                hl.Id,
                hl.Date,
                hl.HabitId,
                hl.UserId))
            .FirstOrDefaultAsync();

        return new GetHabitLogByIdDto(id)
        {
            HabitLog = habitLog
        };
    }
}