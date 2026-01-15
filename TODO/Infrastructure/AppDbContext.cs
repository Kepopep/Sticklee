using Microsoft.EntityFrameworkCore;
using TODO.Domain;
using TODO.Domain.Entities;

namespace TODO.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Habit> Habits => Set<Habit>();
    public DbSet<HabitLog> HabitLogs => Set<HabitLog>();
}