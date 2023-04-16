using System.ComponentModel.DataAnnotations;

namespace GolfPlatform.Domain.Models;

public class UserModel
{
    [Key]
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    public int Points { get; set; }
}