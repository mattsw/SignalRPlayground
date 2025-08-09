using SignalRPlayground.Repositories.Users;
using SignalRPlayground.UserTools.AncientUserManager;
using SignalRPlayground.UserTools.Interfaces;

namespace SignalRPlayground.UserTools;

public class UserManagerAdapter(IArchaicUpdater oldUserUserManager) : IUserManager
{
    public UserDto UpdateFirstName(UserDto user)
    {
        var firstName = oldUserUserManager.TransmuteFirstName(user.UserId, user.FirstName);
        user.FirstName = firstName;
        return user;
    }

    public UserDto UpdateLastName(UserDto user)
    {
        var lastName = oldUserUserManager.TransmuteLastName(user.UserId, user.LastName);
        user.LastName = lastName;
        return user;
    }
}