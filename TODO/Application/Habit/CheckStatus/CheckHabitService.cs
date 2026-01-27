using System.Data;
using TODO.Application.HabitLog;
using TODO.Application.HabitLog.Create;
using TODO.Application.HabitLog.Delete;
using TODO.Application.HabitLog.GetDay;
using TODO.Application.HabitLog.GetPaged;

namespace TODO.Application.Habit.Check;

public class CheckHabitService : ICheckHabitService
{
    private readonly ICreateHabitLogService _createHabitLogService;
    private readonly IGetHabitLogByDayService _getHabitLogByDayService;
    private readonly IDeleteHabitLogService _deleteHabitLogService;

    private readonly DateOnly _currentDate;

    public CheckHabitService(
        ICreateHabitLogService createHabitLogService,
        IDeleteHabitLogService deleteHabitLogService,
        IGetHabitLogByDayService getHabitLogByDayService)
    {
        _createHabitLogService = createHabitLogService;
        _deleteHabitLogService = deleteHabitLogService;
        _getHabitLogByDayService = getHabitLogByDayService;

        _currentDate = DateOnly.FromDateTime(DateTime.Now);
    }

    public async Task ExecuteAsync(CheckHabitDto dto)
    {
        var existingLogs = await _getHabitLogByDayService.ExecuteAsync(
            new GetHabitLogByDayServiceDto(dto.UserId, dto.Date));

        if(existingLogs.Count(l => l.HabitId == dto.HabitId) != 0 == dto.IsChecked)
        {
            return;
        }

        if (dto.IsChecked)
        {
            await CreateLog(dto);
        }
        else
        {
            var deleteDto = new DeleteHabitLogServiceDto(
                dto.UserId, 
                existingLogs.First(l => l.HabitId == dto.HabitId).Id);
            await DeleteLog(deleteDto);
        }
    }

    private async Task DeleteLog(DeleteHabitLogServiceDto dto)
    {
        var deleteDto = new DeleteHabitLogServiceDto(dto.UserId, dto.HabitLogId);
        await _deleteHabitLogService.ExecuteAsync(deleteDto);
    }

    private async Task CreateLog(CheckHabitDto dto)
    {
        var createDto = new CreateHabitLogDto(dto.HabitId, dto.Date);
        await _createHabitLogService.ExecuteAsync(dto.UserId, createDto);
    }
}