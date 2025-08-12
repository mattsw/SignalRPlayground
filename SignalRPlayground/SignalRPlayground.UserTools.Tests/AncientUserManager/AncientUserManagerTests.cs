using Moq;
using SignalRPlayground.Data.Models.Entities;
using SignalRPlayground.Repositories.Users;
using SignalRPlayground.UserTools.AncientUserManager;

namespace SignalRPlayground.UserTools.Tests.AncientUserManager;

[TestFixture]
public class AncientUserManagerTests
{

    [Test]
    public void AncientUserManager_ShouldInstantiate()
    {
        var mockRepository = new Mock<IUserRepository>();
        var sut = new OldUserManager(mockRepository.Object);
        
        Assert.That(sut, Is.Not.Null);
    }

    [TestCase("Jerry", "123")]
    [TestCase("James", "1234")]
    [TestCase("Jessie", "12345")]
    public void OldUserManager_ShouldUpdateFirstName(string firstName, string userId)
    {
        var mockRepository = new Mock<IUserRepository>();
        var testUser = new UserDto
        {
            FirstName = firstName,
            UserId = userId
        };
        mockRepository.Setup(mockRepo => mockRepo.Update(It.IsAny<UserDto>()))
            .Returns(testUser);
        mockRepository.Setup(mockRepo => mockRepo.Find(It.IsAny<string>()))
            .Returns(testUser);
        
        var sut = new OldUserManager(mockRepository.Object);

        var result = sut.TransmuteFirstName(userId, firstName);

        Assert.That(result, Is.EqualTo(testUser.FirstName));

    }
    
    [TestCase("Mako", "123")]
    [TestCase("Tai", "1234")]
    [TestCase("Kiri", "12345")]
    public void OldUserManager_ShouldUpdateLastName(string lastName, string userId)
    {
        var mockRepository = new Mock<IUserRepository>();
        var testUser = new UserDto
        {
            LastName = lastName,
            UserId = userId
        };
        mockRepository.Setup(mockRepo => mockRepo.Update(It.IsAny<UserDto>()))
            .Returns(testUser);
        mockRepository.Setup(mockRepo => mockRepo.Find(It.IsAny<string>()))
            .Returns(testUser);
        
        var sut = new OldUserManager(mockRepository.Object);

        var result = sut.TransmuteFirstName(userId, lastName);

        Assert.That(result, Is.EqualTo(testUser.LastName));

    }
}