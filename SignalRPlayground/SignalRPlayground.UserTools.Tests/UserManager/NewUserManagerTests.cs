using Moq;
using SignalRPlayground.Repositories.Users;

//Should have named this better the ambiguous reference is suboptimal
namespace SignalRPlayground.UserTools.Tests.UserManager;

[TestFixture]
public class NewUserManagerTests
{

    [Test]
    public void NewUserManager_ShouldInstantiate()
    {
        var mockRepository = new Mock<IUserRepository>();
        var sut = new UserTools.UserManager.NewUserManager(mockRepository.Object);
        Assert.That(sut, Is.Not.Null);
    }

    [TestCase("Marcus", "Wins")]
    [TestCase("Abe", "Blackberry")]
    public void NewUserManager_ShouldCreateNewUser(string firstName, string lastName)
    {
        var mockRepository = new Mock<IUserRepository>();
        var testUser = new UserDto
        {
            FirstName = firstName,
            LastName = lastName
        };
        mockRepository.Setup(mockRepo => mockRepo.Create(It.IsAny<UserDto>()))
            .Returns(testUser);
        
        var sut = new UserTools.UserManager.NewUserManager(mockRepository.Object);
        
        var result = sut.CreateUser(firstName, lastName);
        
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.FirstName, Is.EqualTo(testUser.FirstName));
            Assert.That(result.LastName, Is.EqualTo(testUser.LastName));
        });
    }
    
    [TestCase("Marcus", "Wins", "123")]
    public void NewUserManager_ShouldUpdateUser(string firstName, string lastName, string userId)
    {
        var mockRepository = new Mock<IUserRepository>();
        var testUser = new UserDto
        {
            FirstName = firstName,
            LastName = lastName,
            UserId = userId
        };
        mockRepository.Setup(mockRepo => mockRepo.Update(It.IsAny<UserDto>()))
            .Returns(testUser);
        
        var sut = new UserTools.UserManager.NewUserManager(mockRepository.Object);
        
        var result = sut.UpdateUser(testUser);
        
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.FirstName, Is.EqualTo(testUser.FirstName));
            Assert.That(result.LastName, Is.EqualTo(testUser.LastName));
            Assert.That(result.UserId, Is.EqualTo(userId));
        });
    }

    [TestCase("Marcus", "Wins", "123")]
    public void NewUserManager_ShouldDeleteUser(string firstName, string lastName, string userId)
    {
        var mockRepository = new Mock<IUserRepository>();
        var testUser = new UserDto
        {
            UserId = userId,
            FirstName = firstName,
            LastName = lastName
        };
        mockRepository.Setup(mockRepo => mockRepo.Delete(It.IsAny<string>()))
            .Returns(testUser);
        
        var sut = new UserTools.UserManager.NewUserManager(mockRepository.Object);
        
        var result = sut.DeleteUser(userId);
        
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.FirstName, Is.EqualTo(testUser.FirstName));
            Assert.That(result.LastName, Is.EqualTo(testUser.LastName));
            Assert.That(result.UserId, Is.EqualTo(userId));
        });
    }
    
    [TestCase("Marcus", "Wins", "123")]
    [TestCase("Willie", "Ambercone", "125435")]
    public void NewUserManager_ShouldGetUser(string firstName, string lastName, string userId)
    {
        var mockRepository = new Mock<IUserRepository>();
        var testUser = new UserDto
        {
            UserId = userId,
            FirstName = firstName,
            LastName = lastName
        };
        mockRepository.Setup(mockRepo => mockRepo.Find(It.IsAny<string>()))
            .Returns(testUser);
        
        var sut = new UserTools.UserManager.NewUserManager(mockRepository.Object);
        
        var result = sut.GetUser(userId);
        
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.FirstName, Is.EqualTo(testUser.FirstName));
            Assert.That(result.LastName, Is.EqualTo(testUser.LastName));
            Assert.That(result.UserId, Is.EqualTo(userId));
        });
    }
    
    [TestCase("Willie", "Ambercone", "125435")]
    public void NewUserManager_ShouldUpdateFirstName(string firstName, string lastName, string userId)
    {
        var mockRepository = new Mock<IUserRepository>();
        var testUser = new UserDto
        {
            UserId = userId,
            FirstName = firstName,
            LastName = lastName
        };
        mockRepository.Setup(mockRepo => mockRepo.Update(It.IsAny<UserDto>()))
            .Returns(testUser);
        
        var sut = new UserTools.UserManager.NewUserManager(mockRepository.Object);
        
        var result = sut.UpdateFirstName(testUser);
        
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.FirstName, Is.EqualTo(testUser.FirstName));
            Assert.That(result.LastName, Is.EqualTo(testUser.LastName));
            Assert.That(result.UserId, Is.EqualTo(userId));
        });
    }
    
    [TestCase("Box", "Topper", "125435123")]
    public void NewUserManager_ShouldUpdateLastName(string firstName, string lastName, string userId)
    {
        var mockRepository = new Mock<IUserRepository>();
        var testUser = new UserDto
        {
            UserId = userId,
            FirstName = firstName,
            LastName = lastName
        };
        mockRepository.Setup(mockRepo => mockRepo.Update(It.IsAny<UserDto>()))
            .Returns(testUser);
        
        var sut = new UserTools.UserManager.NewUserManager(mockRepository.Object);
        
        var result = sut.UpdateLastName(testUser);
        
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.FirstName, Is.EqualTo(testUser.FirstName));
            Assert.That(result.LastName, Is.EqualTo(testUser.LastName));
            Assert.That(result.UserId, Is.EqualTo(userId));
        });
    }
}