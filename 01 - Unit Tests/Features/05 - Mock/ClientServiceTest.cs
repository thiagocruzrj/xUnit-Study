using Features.Tests._04___Human_Datas;
using Xunit;

namespace Features.Tests._05___Mock
{
    public class ClientServiceTest
    {
        readonly ClientTestBogusFixture _clientTestBogusFixture;

        public ClientServiceTest(ClientTestBogusFixture clientTestBogusFixture)
        {
            _clientTestBogusFixture = clientTestBogusFixture;
        }

        [Fact(DisplayName = "Add client with success")]
        [Trait("Category", "Client Service Mock Tests")]
        public void ClientService_Add_ShouldExeculteWithSuccess()
        {
            // Arrage
            // Act
            // Assert
        }

        [Fact(DisplayName = "Add client with fail")]
        [Trait("Category", "Client Service Mock Tests")]
        public void ClientService_Add_ShouldFailDueInvalidClient()
        {
            // Arrage
            // Act
            // Assert
        }

        [Fact(DisplayName = "Get active clients")]
        [Trait("Category", "Client Service Mock Tests")]
        public void ClientService_GetAllActives_ShouldReturnOnlyActiveClients()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}
