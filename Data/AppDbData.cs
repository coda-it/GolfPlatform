using Microsoft.EntityFrameworkCore;
using GolfPlatform.Domain.Models;

namespace GolfPlatform.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserModel> UserModel { get; set; } = default!;
}