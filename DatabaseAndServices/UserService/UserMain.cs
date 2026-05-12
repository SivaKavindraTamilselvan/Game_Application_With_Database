using WordGame.Models;
using WordGame.Interfaces;
using WordGame.Repositories;

namespace WordGame.Service;

public class UserService
{
    protected readonly UserRepository userRepository;
    public UserService(UserRepository _userRepository)
    {
        userRepository = _userRepository;
    }

    public Users? GetUsersByEmail(string email)
    {
        return userRepository.GetUsersByEmail(email);
    }
    
    public Users AddUserService(Users users)
    {
        var createduser = userRepository.Create(users);
        Console.WriteLine(createduser);
        return createduser;
    }
    public Users? LoginUser(string email,string password)
    {
        var user = userRepository.LoginUser("sivakavindra@gmail.com","siva");
        if(user == null)
        {
            return null;
        }
        Console.WriteLine(user);
        return user;
    }
    public List<UserHistoryDto> UserHistory(Users user)
    {
        var list = userRepository.UserHistory(user.Email);
        foreach(var item in list)
        {
            Console.WriteLine(item);
        }
        return list;
    }
}