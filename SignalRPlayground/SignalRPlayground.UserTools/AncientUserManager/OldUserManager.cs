using SignalRPlayground.Repositories.Users;
using SignalRPlayground.UserTools.Interfaces;

namespace SignalRPlayground.UserTools.AncientUserManager;

public class OldUserManager(IUserRepository userRepository) : IArchaicUpdater
{
    private readonly IUserRepository _userRepository = userRepository;

    public string TransmuteFirstName(string userId, string firstName)
    {
        var user =  _userRepository.Find(userId);
        if (user == null)
        {
            throw new ArgumentNullException(userId);
        }
        user.FirstName = firstName;
        _userRepository.Update(user);
        return user.FirstName;
    }

    public string TransmuteLastName(string userId, string lastName)
    {
        var user =  _userRepository.Find(userId);
        if (user == null)
        {
            throw new ArgumentNullException(userId);
        }
        user.LastName = lastName;
        _userRepository.Update(user);
        return user.LastName;
    }
}