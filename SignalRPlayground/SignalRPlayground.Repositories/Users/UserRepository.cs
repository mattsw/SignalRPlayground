using SignalRPlayground.Data.Models.Contexts;
using SignalRPlayground.Data.Models.Entities;

namespace SignalRPlayground.Repositories.Users;

public interface IUserRepository
{
    User Create(User user);
    User? Find(string userId);
    User Update(User user);
    User Delete(User user);
}

public class UserRepository(LocalPlaygroundContext context) : IUserRepository
{
    private readonly LocalPlaygroundContext _context = context;

    public User Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public User? Find(string userId)
    {
        return _context.Users.Find(userId);
    }

    public User Update(User user)
    {
        _context.Users.Update(user);
        return user;
    }

    public User Delete(User user)
    {
        _context.Users.Remove(user);
        return user;
    }
}