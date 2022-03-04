using GolfPlatform.Domain.Models;

namespace GolfPlatform.Data.Repositories;

public class UserRepository : IUserRepository
{
    AppDbContext _appDbContext;
    public UserRepository(AppDbContext AppDbContext)
    {
        _appDbContext = AppDbContext;
    }

    public UserModel Find(String email, String password)
    {
        return _appDbContext.UserModel.Single(u => u.Name == email && u.Password == password);
    }

    public void Add(String email, String password)
    {
        UserModel user = new UserModel();
        user.Name = email;
        user.Password = password;

        _appDbContext.UserModel.Add(user);
    }
}