using SignalRPlayground.UserTools.AncientUserManager;
using SignalRPlayground.UserTools.Interfaces;

namespace SignalRPlayground.UserTools.Tests;

[TestFixture]
public class UserManagerAdapterTests
{

    [Test]
    public void UserManagerAdapter_ShouldInstantiateWithOldManager()
    {
        var sut = new UserManagerAdapter(new OldUserManager());
        
        Assert.That(sut, Is.Not.Null);
    }

    [Test]
    public void UserManagerAdapter_ShouldWorkWithNewInterface()
    {
        var sut = new UserManagerAdapter(new OldUserManager());
        
        Assert.That(sut, Is.Not.Null);
        Assert.That(sut, Is.InstanceOf<IUserManager>());
    }
}