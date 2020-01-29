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
    [Collection(nameof(ClientBogusCollection))]
    public class ClientServiceAutoMockerTests
    {
        readonly ClientTestBogusFixture _clientTestBogusFixture;

        public ClientServiceAutoMockerTests(ClientTestBogusFixture clientTestBogusFixture)
        {
            _clientTestBogusFixture = clientTestBogusFixture;
        }

        [Fact(DisplayName = "Add client with success")]
        [Trait("Category", "Client Service Auto Mock Tests")]
        public void ClientService_Add_ShouldExeculteWithSuccess()
        {
            // Arrage
            var client = _clientTestBogusFixture.GenerateValidClient();
            var mocker = new AutoMocker();

            var clientService = mocker.CreateInstance<ClientService>();

            // Act
            clientService.Add(client);

            // Assert
            mocker.GetMock<IClientRepository>().Verify(r => r.Add(client), Times.Once);
            mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Add client with fail")]
        [Trait("Category", "Client Service Auto Mock Tests")]
        public void ClientService_Add_ShouldFailDueInvalidClient()
        {
            // Arrage
            var client = _clientTestBogusFixture.GenerateInvalidClient();
            var mocker = new AutoMocker();

            var clientService = mocker.CreateInstance<ClientService>();

            // Act
            clientService.Add(client);

            // Assert
            mocker.GetMock<IClientService>().Verify(r => r.Add(client), Times.Never);
            mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Get active clients")]
        [Trait("Category", "Client Service Auto Mock Tests")]
        public void ClientService_GetAllActives_ShouldReturnOnlyActiveClients()
        {
            // Arrange
            var mocker = new AutoMocker();
            var clientService = mocker.CreateInstance<ClientService>();

            mocker.GetMock<IClientRepository>().Setup(c => c.GetAll())
                .Returns(_clientTestBogusFixture.GetSomeClients());

            // Act
            var clients = clientService.GetAllActives();

            // Assert
            Assert.True(clients.Any());
            Assert.False(clients.Count(c => !c.Active) > 0);
        }
    }
}
