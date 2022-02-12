using GolfPlatform.Domain.Models;

namespace GolfPlatform.Data.Repositories;

public class UserRepository: IUserRepository
{
    AppDbContext AppDbContext;
    public UserRepository(AppDbContext AppDbContext)
    {
        this.AppDbContext = AppDbContext;
    }

    public UserModel Find(String email, String password)
    {
        return this.AppDbContext.UserModel.Where(u => u.Name == email && u.Password == password).First<UserModel>();
    }
}