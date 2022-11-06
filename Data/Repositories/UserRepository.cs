using System.Collections.Generic;
using GolfPlatform.Domain.Models;

namespace GolfPlatform.Data.Repositories;

public class UserRepository : IUserRepository
{
    AppDbContext _appDbContext;
    public UserRepository(AppDbContext AppDbContext)
    {
        _appDbContext = AppDbContext;
    }

    public List<UserModel> Get() {
        List<UserModel> users = _appDbContext.UserModel.ToList();
        return users;
    }

    public UserModel? Find(String email, String password)
    {
        return _appDbContext.UserModel.SingleOrDefault(u => u.Email == email && u.Password == password);
    }

    public void Add(String email, String password)
    {
        UserModel user = new UserModel();
        user.Email = email;
        user.Password = password;

        _appDbContext.UserModel.Add(user);
        _appDbContext.SaveChanges();
    }
}