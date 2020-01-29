using Feature.Client;
using Features.Tests._04___Human_Datas;
using MediatR;
using Moq;
using System.Linq;
using System.Threading;
using Xunit;

namespace Features.Tests._05___Mock
{
    [Collection(nameof(ClientBogusCollection))]
    public class ClientServiceTest
    {
        private readonly ClientTestBogusFixture _clientTestBogusFixture;

        public ClientServiceTest(ClientTestBogusFixture clientTestBogusFixture)
        {
            _clientTestBogusFixture = clientTestBogusFixture;
        }

        [Fact(DisplayName = "Add client with success")]
        [Trait("Category", "Client Service Mock Tests")]
        public void ClientService_Add_ShouldExeculteWithSuccess()
        {
            // Arrage
            var client = _clientTestBogusFixture.GenerateValidClient();
            var clientRepo = new Mock<IClientRepository>();
            var mediator = new Mock<IMediator>();

            var clientService = new ClientService(clientRepo.Object, mediator.Object);

            // Act
            clientService.Add(client);

            // Assert
            clientRepo.Verify(r => r.Add(client), Times.Once);
            mediator.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Add client with fail")]
        [Trait("Category", "Client Service Mock Tests")]
        public void ClientService_Add_ShouldFailDueInvalidClient()
        {
            // Arrage
            var client = _clientTestBogusFixture.GenerateInvalidClient();
            var clientRepo = new Mock<IClientRepository>();
            var mediator = new Mock<IMediator>();

            var clientService = new ClientService(clientRepo.Object, mediator.Object);

            // Act
            clientService.Add(client);

            // Assert
            clientRepo.Verify(r => r.Add(client), Times.Never);
            mediator.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Get active clients")]
        [Trait("Category", "Client Service Mock Tests")]
        public void ClientService_GetAllActives_ShouldReturnOnlyActiveClients()
        {
            // Arrange
            var clientRepo = new Mock<IClientRepository>();
            var mediator = new Mock<IMediator>();

            clientRepo.Setup(c => c.GetAll())
                .Returns(_clientTestBogusFixture.GetSomeClients());

            var clientService = new ClientService(clientRepo.Object, mediator.Object);

            // Act
            var clients = clientService.GetAllActives();

            // Assert
            Assert.True(clients.Any());
            Assert.False(clients.Count(c => !c.Active) > 0);
        }
    }
}
