using GolfPlatform.Domain.Models;

namespace GolfPlatform.Data.Repositories;

public interface IUserRepository
{
    public UserModel Find(String email, String password);
}