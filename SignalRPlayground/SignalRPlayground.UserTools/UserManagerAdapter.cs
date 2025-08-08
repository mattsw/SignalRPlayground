using SignalRPlayground.UserTools.AncientUserManager;
using SignalRPlayground.UserTools.Interfaces;

namespace SignalRPlayground.UserTools;

public class UserManagerAdapter(IArchaicUpdater oldUserUserManager) : IUserManager
{
    public string UpdateFirstName(string firstName)
    {
        return oldUserUserManager.TransmuteFirstName(firstName);
    }

    public string UpdateLastName(string lastName)
    {
        return oldUserUserManager.TransmuteFirstName(lastName);
    }
}