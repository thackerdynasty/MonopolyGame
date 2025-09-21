using Microsoft.EntityFrameworkCore;

namespace MonopolyGame.Models;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Game> Games { get; set; }
    public DbSet<User> Users { get; set; }
}