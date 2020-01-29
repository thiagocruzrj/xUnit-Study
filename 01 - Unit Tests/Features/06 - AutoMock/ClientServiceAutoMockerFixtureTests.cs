using Feature.Client;
using Features.Tests._04___Human_Datas;
using MediatR;
using Moq;
using Moq.AutoMock;
using System.Linq;
using System.Threading;
using Xunit;

namespace Features.Tests._06___AutoMock
{
    [Collection(nameof(ClientAutoMockerCollection))]
    public class ClientServiceAutoMockerFixtureTests
    {
        readonly ClientServiceAutoMockerFixture _clientTestAutoMockerFixture;
        readonly ClientService _clientService;

        public ClientServiceAutoMockerFixtureTests(ClientServiceAutoMockerFixture clientTestBogusFixture)
        {
            _clientTestAutoMockerFixture = clientTestBogusFixture;
            _clientService = _clientTestAutoMockerFixture.GetClientService();
        }

        [Fact(DisplayName = "Add client with success")]
        [Trait("Category", "Client Service Auto Mock Tests")]
        public void ClientService_Add_ShouldExeculteWithSuccess()
        {
            // Arrage
            var client = _clientTestAutoMockerFixture.GenerateValidClient();

            // Act
            _clientService.Add(client);

            // Assert
            _clientTestAutoMockerFixture.Mocker.GetMock<IClientRepository>().Verify(r => r.Add(client), Times.Once);
            _clientTestAutoMockerFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Add client with fail")]
        [Trait("Category", "Client Service Auto Mock Tests")]
        public void ClientService_Add_ShouldFailDueInvalidClient()
        {
            // Arrage
            var client = _clientTestAutoMockerFixture.GenerateInvalidClient();

            // Act
            _clientService.Add(client);

            // Assert
            _clientTestAutoMockerFixture.Mocker.GetMock<IClientService>().Verify(r => r.Add(client), Times.Never);
            _clientTestAutoMockerFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Get active clients")]
        [Trait("Category", "Client Service Auto Mock Tests")]
        public void ClientService_GetAllActives_ShouldReturnOnlyActiveClients()
        {
            // Arrange

            _clientTestAutoMockerFixture.Mocker.GetMock<IClientRepository>().Setup(c => c.GetAll())
                .Returns(_clientTestAutoMockerFixture.GetSomeClients());

            // Act
            var clients = _clientService.GetAllActives();

            // Assert
            Assert.True(clients.Any());
            Assert.False(clients.Count(c => !c.Active) > 0);
        }
    }
}
