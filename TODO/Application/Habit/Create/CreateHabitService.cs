using TODO.Application.User.Context;
using TODO.Infrastructure;

namespace TODO.Application.Habit.Create;

public class CreateHabitService : ICreateHabitService
{
    private readonly AppDbContext _dbContext;
    private readonly IUserContext _userContext;

    public CreateHabitService(AppDbContext dbContext, IUserContext userContext)
    {
        _dbContext = dbContext;
        _userContext = userContext;
    }
    
    public async Task<HabitDto> ExecuteAsync(CreateHabitServiceDto dto)
    {
        var habit = new Domain.Entities.Habit(
            _userContext.UserId,
            dto.Name,
            dto.Frequency);

        _dbContext.Habits.Add(habit);
        await _dbContext.SaveChangesAsync();

        return new HabitDto(
            habit.Id, 
            habit.UserId, 
            habit.Name, 
            habit.Frequency);
    }
}