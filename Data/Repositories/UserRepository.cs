using GolfPlatform.Domain.Models;

namespace GolfPlatform.Data.Repositories;

public class UserRepository: IUserRepository
{
    AppDbContext _appDbContext;
    public UserRepository(AppDbContext AppDbContext)
    {
        _appDbContext = AppDbContext;
    }

    public UserModel Find(String email, String password)
    {
        return _appDbContext.UserModel.Where(u => u.Name == email && u.Password == password).First<UserModel>();
    }
}