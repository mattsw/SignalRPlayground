using Moq;
using SignalRPlayground.Repositories.Users;
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
    
    [TestCase("Ferdinand", "Fisher", "1234")]
    [TestCase("Talker", "Eggbert", "asdf12")]
    public void UserManagerAdapter_ShouldUpdateFirstName(string firstName, string lastName, string userId)
    {
        var user = new UserDto
        {
            FirstName = firstName,
            LastName = lastName,
            UserId = userId
        };
        var oldUserManager = new Mock<IArchaicUpdater>();
        oldUserManager.Setup(old => old.TransmuteFirstName(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(firstName);
        
        var sut = new UserManagerAdapter(oldUserManager.Object);
        
        var result = sut.UpdateFirstName(user);
        
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.FirstName, Is.EqualTo(firstName));
            Assert.That(result.LastName, Is.EqualTo(lastName));
            Assert.That(result.UserId, Is.EqualTo(userId));
        });
    }
    
    [TestCase("Ferdinand", "Fisher", "1234")]
    [TestCase("Talker", "Eggbert", "asdf12")]
    public void UserManagerAdapter_ShouldUpdateLastName(string firstName, string lastName, string userId)
    {
        var user = new UserDto
        {
            FirstName = firstName,
            LastName = lastName,
            UserId = userId
        };
        var oldUserManager = new Mock<IArchaicUpdater>();
        oldUserManager.Setup(old => old.TransmuteLastName(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(lastName);
        
        var sut = new UserManagerAdapter(oldUserManager.Object);
        
        var result = sut.UpdateLastName(user);
        
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.FirstName, Is.EqualTo(firstName));
            Assert.That(result.LastName, Is.EqualTo(lastName));
            Assert.That(result.UserId, Is.EqualTo(userId));
        });
    }
}