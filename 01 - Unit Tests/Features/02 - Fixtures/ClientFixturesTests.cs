using Feature.Client;
using System;
using Xunit;

namespace Features.Tests._02___Fixtures
{
    public class ClientFixturesTests
    {
        [Fact(DisplayName = "New Valid Client")]
        [Trait("Category", "Client Fixture Tests")]
        public void Client_NewClient_MustValid()
        {
            // Arrange
            var client = new Client(
                Guid.NewGuid(),
                "Thiago",
                "Cruz",
                DateTime.Now.AddYears(-25),
                DateTime.Now,
                "thiago@thi.com.br",
                true);

            // Act
            var result = client.IsValid();

            // Assert
            Assert.True(result);
            Assert.Equal(0, client.ValidationResult.Errors.Count);
        }
    }
}
