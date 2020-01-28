using Feature.Client;
using System;
using Xunit;

namespace Features.Tests._02___Fixtures
{
    [Collection(nameof(ClientCollection))]
    public class ClientValidTests
    {
        readonly ClientFixtureTests _clientFixtureTests;

        public ClientValidTests(ClientFixtureTests clientFixtureTests)
        {
            _clientFixtureTests = clientFixtureTests;
        }

        [Fact(DisplayName = "New Valid Client")]
        [Trait("Category", "Client Fixture Tests")]
        public void Client_NewClient_MustValid()
        {
            // Arrange
            var client = _clientFixtureTests.GenerateValidClient();

            // Act
            var result = client.IsValid();

            // Assert
            Assert.True(result);
            Assert.Equal(0, client.ValidationResult.Errors.Count);
        }
    }
}
