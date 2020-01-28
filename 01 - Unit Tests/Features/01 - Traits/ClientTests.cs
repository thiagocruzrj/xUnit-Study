using Feature.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Features.Tests._01___Traits
{
    public class ClientTests
    {
        [Fact(DisplayName = "New Valid Client")]
        [Trait("Category", "Client Trait Tests")]
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

        [Fact(DisplayName = "New Invalid Client")]
        [Trait("Category", "Client Trait Tests")]
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
