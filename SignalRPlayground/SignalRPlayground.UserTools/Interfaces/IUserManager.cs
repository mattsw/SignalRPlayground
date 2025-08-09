using SignalRPlayground.Repositories.Users;

namespace SignalRPlayground.UserTools.Interfaces;

public interface IUserManager
{
    UserDto UpdateFirstName(UserDto user);
    UserDto UpdateLastName(UserDto user);
}