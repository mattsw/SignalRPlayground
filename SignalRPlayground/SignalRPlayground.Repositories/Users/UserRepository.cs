using SignalRPlayground.Data.Models.Entities;

namespace SignalRPlayground.Repositories.Users;

public interface IUserRepository
{
    User CreateUser(User user);
    User FindUser(string userId);
    User UpdateUser(User user);
    User DeleteUser(User user);
}

public class UserRepository : IUserRepository
{
    public User CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    public User FindUser(string userId)
    {
        throw new NotImplementedException();
    }

    public User UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public User DeleteUser(User user)
    {
        throw new NotImplementedException();
    }
}