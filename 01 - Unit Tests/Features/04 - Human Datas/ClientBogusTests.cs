using Xunit;

namespace Features.Tests._04___Human_Datas
{
    [Collection(nameof(ClientBogusCollection))]
    public class ClientBogusTests
    {
        private readonly ClientTestBogusFixture _clientTestsFixture;

        public ClientBogusTests(ClientTestBogusFixture clientTestsFixture)
        {
            _clientTestsFixture = clientTestsFixture;
        }

        [Fact(DisplayName = "New Valid Client")]
        [Trait("Category", "Client Bogus Test")]
        public void Client_NewClient_ShouldValid()
        {
            // Arrange
            var client = _clientTestsFixture.GenerateValidClient();

            // Act
            var result = client.IsValid();

            // Assert
            Assert.True(result);
            Assert.Equal(0, client.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "New Invalid Client")]
        [Trait("Category", "Client Bogus Test")]
        public void Client_NewClient_ShouldInvalid()
        {
            // Arrange
            var client = _clientTestsFixture.GenerateInvalidClient();

            var result = client.IsValid();

            // Assert
            Assert.False(result);
            Assert.NotEqual(0, client.ValidationResult.Errors.Count);
        }
    }
}
