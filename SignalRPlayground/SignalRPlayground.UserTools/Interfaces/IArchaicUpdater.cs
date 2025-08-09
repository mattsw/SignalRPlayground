namespace SignalRPlayground.UserTools.Interfaces;

public interface IArchaicUpdater
{
    string TransmuteFirstName(string userId, string firstName);
    string TransmuteLastName(string userId, string lastName);
}