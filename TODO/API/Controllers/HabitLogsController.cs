using Microsoft.AspNetCore.Mvc;
using TODO.API.Requests;
using TODO.Application.HabitLog;
using TODO.Application.HabitLog.Create;
using TODO.Application.HabitLog.Delete;
using TODO.Application.HabitLog.Get;
using TODO.Application.HabitLog.GetById;

namespace TODO.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HabitLogsController : ControllerBase
{
    private readonly ICreateHabitLogService _createHabitLogService;
    private readonly IGetHabitLogByIdService _getHabitLogByIdService;
    private readonly IGetHabitLogService _getHabitLogService;
    private readonly IDeleteHabitLogService _deleteHabitLogService;

    public HabitLogsController(
        ICreateHabitLogService createHabitLogService,
        IGetHabitLogByIdService getHabitLogByIdService,
        IGetHabitLogService getHabitLogService,
        IDeleteHabitLogService deleteHabitLogService)
    {
        _createHabitLogService = createHabitLogService;
        _getHabitLogByIdService = getHabitLogByIdService;
        _getHabitLogService = getHabitLogService;
        _deleteHabitLogService = deleteHabitLogService;
    }

    /// <summary>
    /// Создает новую запись журнала привычки
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(HabitLogDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateHabitLogRequest request)
    {
        var userIdString = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var createDto = new CreateHabitLogDto(request.HabitId, request.Date);
        var habitLog = await _createHabitLogService.ExecuteAsync(userId, createDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = habitLog.Id },
            habitLog);
    }

    /// <summary>
    /// Получает запись журнала привычки по идентификатору
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(GetHabitLogByIdDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var habitLog = await _getHabitLogByIdService.ExecuteAsync(id);

        if (habitLog.HabitLog == null)
        {
            return NotFound();
        }

        return Ok(habitLog);
    }

    /// <summary>
    /// Получает запись журнала привычки для пользователя
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(HabitLogDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromQuery] Guid habitLogId)
    {
        var userIdString = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var dto = new GetHabitLogServiceDto(userId, habitLogId);
        var habitLog = await _getHabitLogService.ExecuteAsync(dto);

        return Ok(habitLog);
    }

    /// <summary>
    /// Удаляет запись журнала привычки по идентификатору
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userIdString = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
        {
            return Unauthorized();
        }

        var dto = new DeleteHabitLogServiceDto(userId, id);
        await _deleteHabitLogService.ExecuteAsync(dto);

        return NoContent();
    }
}