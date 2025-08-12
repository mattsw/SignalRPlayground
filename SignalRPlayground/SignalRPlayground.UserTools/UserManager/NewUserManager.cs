using SignalRPlayground.Repositories.Users;
using SignalRPlayground.UserTools.Interfaces;

namespace SignalRPlayground.UserTools.UserManager;

public interface INewUserManager
{
    UserDto CreateUser(string firstName, string lastName);
    UserDto GetUser(string userId);
    UserDto DeleteUser(string userId);
    UserDto UpdateUser(UserDto user);
}

public class NewUserManager(IUserRepository userRepository) : IUserManager, INewUserManager
{
    private readonly IUserRepository _repository = userRepository;

    public UserDto UpdateFirstName(UserDto user)
    {
        return UpdateUser(user);
    }

    public UserDto UpdateLastName(UserDto user)
    {
        return UpdateUser(user);
    }
    
    public UserDto CreateUser(string firstName, string lastName)
    {
        var newUser = new UserDto
        {
            FirstName = firstName,
            LastName = lastName
        };
        
        return _repository.Create(newUser);
    }

    //TODO error handling around no user found
    public UserDto GetUser(string userId)
    {
        return _repository.Find(userId);
    }

    public UserDto DeleteUser(string userId)
    {
        return _repository.Delete(userId);
    }

    public UserDto UpdateUser(UserDto user)
    {
        return _repository.Update(user);
    }
}