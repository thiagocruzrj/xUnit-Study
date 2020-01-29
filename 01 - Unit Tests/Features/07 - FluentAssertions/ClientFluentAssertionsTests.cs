using Features.Tests._06___AutoMock;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Features.Tests._07___FluentAssertions
{
    [Collection(nameof(ClientAutoMockerCollection))]
    public class ClientFluentAssertionsTests
    {
        readonly ClientServiceAutoMockerFixture _clientServiceAutoMockerFixture;
        readonly ITestOutputHelper _outputHelper;

        public ClientFluentAssertionsTests(ClientServiceAutoMockerFixture clientServiceAutoMockerFixture, ITestOutputHelper outputHelper)
        {
            _clientServiceAutoMockerFixture = clientServiceAutoMockerFixture;
            _outputHelper = outputHelper;
        }

        [Fact(DisplayName = "New Valid Client")]
        [Trait("Category", "Client Fluent Assertion Tests")]
        public void Client_NewClient_ShouldBeValid()
        {
            // Arrage
            var client = _clientServiceAutoMockerFixture.GenerateValidClient();

            // Act
            var result = client.IsValid();

            // Old Assert
            //Assert.True(result);
            //Assert.Equal(0, client.ValidationResult.Errors.Count);

            // Assert
            result.Should().BeTrue();
            client.ValidationResult.Errors.Should().HaveCount(0);

            _outputHelper.WriteLine($"Was found {client.ValidationResult.Errors.Count} errors on this validation");
        }

        [Fact(DisplayName = "New Invalid Client")]
        [Trait("Category", "Client Fluent Assertion Tests")]
        public void Client_NewClient_ShouldBeInvalid()
        {
            // Arrage
            var client = _clientServiceAutoMockerFixture.GenerateInvalidClient();

            // Act
            var result = client.IsValid();

            // Assert
            result.Should().BeFalse();
            client.ValidationResult.Errors.Should().HaveCountGreaterOrEqualTo(1, "Should have validation erros");

            _outputHelper.WriteLine($"Was found {client.ValidationResult.Errors.Count} errors on this validation");
        }
    }
}
