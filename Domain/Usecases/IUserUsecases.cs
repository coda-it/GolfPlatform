using GolfPlatform.Domain.Models;

namespace GolfPlatform.Domain.Usecases;

public interface IUserUsecases
{
    public UserModel LogIn(String email, String password);
    public void Add(String email, String password);
}