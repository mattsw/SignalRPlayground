using Microsoft.AspNetCore.SignalR;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using SignalRPlayground.Web.Hubs;

namespace SignalRPlayground.Web.Tests.Hubs;

[TestFixture]
public class ChatHubTests
{
    [Test]
    public void ChatHub_ShouldInstantiate()
    {
        var sut = new ChatHub();
        
        Assert.That(sut, Is.Not.Null);
    }
    
    [TestCase(1203213123132L, "TestUser")]
    public async Task ChatHub_ShouldReceiveMessage(long testUserId, string testMessage)
    {
        var sut = new ChatHub();
        
        var mockCaller = new Mock<IHubCallerClients>();
        var mockClientProxy = new Mock<ISingleClientProxy>();
        var mockClientsProxy = new Mock<IClientProxy>();
        mockCaller.Setup(caller => caller.Caller).Returns(mockClientProxy.Object);
        mockCaller.Setup(caller => caller.All).Returns(mockClientsProxy.Object);
        sut.Clients = mockCaller.Object;
        
        await sut.NewMessage(testUserId, testMessage);
        
        mockCaller.Verify(caller => caller.All, Times.Once);
    }
}