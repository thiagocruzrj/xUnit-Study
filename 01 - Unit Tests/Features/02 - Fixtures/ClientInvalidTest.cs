using Xunit;

namespace Features.Tests._02___Fixtures
{
    [Collection(nameof(ClientCollection))]
    public class ClientInvalidTest
    {
        readonly ClientFixtureTests _clientFixtureText;

        public ClientInvalidTest(ClientFixtureTests clientFixtureText)
        {
            _clientFixtureText = clientFixtureText;
        }

        [Fact(DisplayName = "New Invalid Client")]
        [Trait("Category", "Client Fixture Tests")]
        public void Client_NewClient_MustInvalid()
        {
            // Arrange
            var client = _clientFixtureText.GenerateInvalidClient();

            // Act
            var result = client.IsValid();

            // Assert
            Assert.False(result);
            Assert.NotEqual(0, client.ValidationResult.Errors.Count);
        }
    }
}
