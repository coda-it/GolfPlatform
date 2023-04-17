using GolfPlatform.Domain.Models;
using System.Collections.Generic;

namespace GolfPlatform.Domain.Usecases;

public interface IUserUsecases
{
    public UserModel? LogIn(String email, String password);
    public void Add(String email, String password);
    public List<UserModel> Get();
    public void Hit(int id);
}
