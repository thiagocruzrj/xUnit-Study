using Feature.Client;
using System;
using Xunit;

namespace Features.Tests._02___Fixtures
{
    public class ClientInvalidTest
    {
        [Fact(DisplayName = "New Invalid Client")]
        [Trait("Category", "Client Fixture Tests")]
        public void Client_NewClient_MustInvalid()
        {
            // Arrange
            var client = new Client(
                Guid.NewGuid(),
                "",
                "",
                DateTime.Now,
                DateTime.Now,
                "thiago@thi.com.br",
                true);

            // Act
            var result = client.IsValid();

            // Assert
            Assert.False(result);
            Assert.NotEqual(0, client.ValidationResult.Errors.Count);
        }
    }
}
