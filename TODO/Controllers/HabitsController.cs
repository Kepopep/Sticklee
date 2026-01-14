using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TODO.Database;
using TODO.Database.Repository;
using TODO.Model;

namespace TODO.Controllers;

[ApiController]
[Route("[controller]")]
public class HabitsController : Controller
{
    private IRepository<Habit> _habitRepository;

    public HabitsController(ApplicationDbContext context)
    {
        _habitRepository = new HabitRepository(context);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateHabit()
    {
        return Ok(_habitRepository.Create(true));
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetHabit(Guid id)
    {
        var result = await _habitRepository.Get(id);
        
        return result == null ? NotFound() : Ok(result);
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetAllHabits()
    {
        return Ok(_habitRepository.GetAll());
    }

    [HttpPut("update/{id}/{data}")]
    public async Task<IActionResult> UpdateHabit(Guid id, Habit data)
    {
        return Ok(_habitRepository.Update(id, data, true));
    }
    
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> UpdateHabit(Guid id)
    {
        return Ok(_habitRepository.Delete(id, true));
    }
}