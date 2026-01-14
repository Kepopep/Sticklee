using Microsoft.AspNetCore.Mvc;
using TODO.Database;
using TODO.Logic.Fabric;
using TODO.Model;
using TODO.Model.Enum;

namespace TODO.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : Controller
{
    private readonly ApplicationDbContext _context;
    
    /*
    private readonly HasIdFabric<User> _userIdFabric = new();
    private readonly HasIdFabric<Habit> _habitIdFabric = new();
    */

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public async Task<IActionResult> Test()
    {
        /*
        var user = _userIdFabric.GetObject();

        user.Name = "Test";
        
        var habit = _habitIdFabric.GetObject();
        
        habit.Name = "Coding";
        habit.User = user;

        _context.Users.Add(user);
        _context.Habits.Add(habit);
        await _context.SaveChangesAsync();
        
  */
        return NotFound();
    }
}