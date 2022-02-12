using GolfPlatform.Data.Repositories;
using GolfPlatform.Domain.Models;

namespace GolfPlatform.Domain.Usecases;

public class UserUsecases : IUserUsecases
{
    IUserRepository userRepository;
    public UserUsecases(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public UserModel LogIn(String email, String password)
    {
        return this.userRepository.Find(email, password);
    }
}