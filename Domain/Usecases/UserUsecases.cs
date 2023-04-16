
using System.Collections.Generic;
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

    public List<UserModel> Get() {
        return _userRepository.Get();
    }

    public UserModel? LogIn(String email, String password)
    {
        return _userRepository.Find(email, password);
    }

    public void Add(String email, String password)
    {
        _userRepository.Add(email, password);
    }

    public void Hit(int id) {
        _userRepository.Edit(id);
    }
}