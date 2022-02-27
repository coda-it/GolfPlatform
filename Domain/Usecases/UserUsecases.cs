using GolfPlatform.Data.Repositories;
using GolfPlatform.Domain.Models;

namespace GolfPlatform.Domain.Usecases;

public class UserUsecases : IUserUsecases
{
    IUserRepository _userRepository;
    public UserUsecases(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public UserModel LogIn(String email, String password)
    {
        return _userRepository.Find(email, password);
    }
}