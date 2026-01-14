using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TODO.Database.Repository;
using TODO.Model;
using TODO.Model.DTO;

namespace TODO.Controllers;

[ApiController]
[Route("[controller]")]
public class HabitLogsController : Controller
{
    private readonly IRepository<HabitLog> _logRepository;
    private readonly HabitLogger _logger;
 
    public HabitLogsController(DbContext context)
    {
        _logRepository = new HabitLogsRepository(context);
        
        _logger = new HabitLogger(_logRepository, new HabitRepository(context));
    }
    
    [HttpPost("create/{data}")]
    public async Task<IActionResult> CreateLog(HabitLogCreateData data)
    {
        var log = await _logger.CreateLog(data);
        
        return log == null ? NotFound() : Ok(log);
    }
     
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLog(Guid id)
    {
        var result = await _logRepository.Get(id);
         
        return result == null ? NotFound() : Ok(result);
    }
     
    [HttpGet("")]
    public async Task<IActionResult> GetAllHabits()
    {
        return Ok(_logRepository.GetAll());
    }
 
    [HttpPut("update/{id}/{data}")]
    public async Task<IActionResult> UpdateLog(Guid id, HabitLogUpdate data)
    {
        var log = await _logger.UpdateLog(id, data);
        
        return log == null ? NotFound() : Ok(log);
    }
     
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteLog(Guid id)
    {
        await _logger.DeleteLog(id);
         
        return NoContent();
    }
}