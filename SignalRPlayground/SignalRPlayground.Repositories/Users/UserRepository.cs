using SignalRPlayground.Data.Models.Contexts;
using SignalRPlayground.Data.Models.Entities;

namespace SignalRPlayground.Repositories.Users;

public interface IUserRepository
{
    UserDto Create(UserDto user);
    UserDto? Find(string userId);
    UserDto Update(UserDto user);
    UserDto Delete(string userId);
}

public class UserRepository(LocalPlaygroundContext context) : IUserRepository
{
    private readonly LocalPlaygroundContext _context = context;

    public UserDto Create(UserDto user)
    {
        var userToCreate = new User
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserId = user.UserId
        };
        _context.Users.Add(userToCreate);
        _context.SaveChanges();
        return user;
    }

    //could use a mapper here, for this app it might not happen
    public UserDto? Find(string userId)
    {
        var user = _context.Users.Find(userId);
        //Could error handle here, this app might not care about it
        if (user == null) return null;
        
        return new UserDto
        {
            FirstName = user.FirstName!,
            LastName = user.LastName!,
        };
    }

    public UserDto Update(UserDto user)
    {
        if (!_context.Users.Any(val => val.UserId == user.UserId))
        {
            //guard to preserve put method create if not exists
            //this introduces a read before write data integrity issue, but for this small app it should be okay
            Create(user);
            return user;
        }
        
        var userToUpdate = new User
        {
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
        _context.Users.Update(userToUpdate);
        _context.SaveChanges();
        return user;
    }

    public UserDto Delete(string userId)
    {
        var userToDelete = _context.Users.Find(userId);
        if(userToDelete == null) throw new ArgumentException("User not found, cannot delete invalid user.");
        
        _context.Users.Remove(userToDelete);
        _context.SaveChanges();
        return new UserDto
        {
            FirstName = userToDelete.FirstName!,
            LastName = userToDelete.LastName!,
            UserId = userId
        };
    }
}