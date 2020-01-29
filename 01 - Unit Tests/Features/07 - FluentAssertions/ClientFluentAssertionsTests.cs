using Features.Tests._06___AutoMock;
using Moq;
using Xunit;

namespace Features.Tests._07___FluentAssertions
{
    [Collection(nameof(ClientAutoMockerCollection))]
    public class ClientFluentAssertionsTests
    {
        readonly ClientServiceAutoMockerFixture _clientServiceAutoMockerFixture;

        public ClientFluentAssertionsTests(ClientServiceAutoMockerFixture clientServiceAutoMockerFixture)
        {
            _clientServiceAutoMockerFixture = clientServiceAutoMockerFixture;
        }

        [Fact(DisplayName = "New Valid Client")]
        [Trait("Category", "Client Fluent Assertion Tests")]
        public void Client_NewClient_ShouldBeValid()
        {
            // Arrage
            var client = _clientServiceAutoMockerFixture.GenerateValidClient();

            // Act
            var result = client.IsValid();

            // Assert
            Assert.True(result);
            Assert.Equal(0, client.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "New Invalid Client")]
        [Trait("Category", "Client Fluent Assertion Tests")]
        public void Client_NewClient_ShouldBeInvalid()
        {
            // Arrage
            var client = _clientServiceAutoMockerFixture.GenerateValidClient();

            // Act
            var result = client.IsValid();

            // Assert
            Assert.False(result);
            Assert.NotEqual(0, client.ValidationResult.Errors.Count);
        }
    }
}
