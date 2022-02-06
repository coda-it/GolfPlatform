using Microsoft.EntityFrameworkCore;
using GolfPlatform.Models;

namespace GolfPlatform.Data;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }

    public DbSet<UserModel> UserModel { get; set; } = default!;
}