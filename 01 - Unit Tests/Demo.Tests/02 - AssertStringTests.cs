using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Tests
{
    public class AssertStringTests
    {
        [Fact]
        public void StringTools_JoinNames_ReturnFullName()
        {
            // Arrage
            var sut = new StringTools();

            // Act
            var fullName = sut.Join("Thiago", "Cruz");

            // Assert
            Assert.Equal("Thiago Cruz", fullName);
        }

        [Fact]
        public void StringTools_JoinNames_MustIgnoreCase()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var fullName = sut.Join("Thiago", "Cruz");

            // Assert
            Assert.Equal("THIAGO CRUZ", fullName, true);
        }

        [Fact]
        public void StringTools_JoinNames_MustContainSection()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var fullName = sut.Join("Thiago", "Cruz");

            // Assert
            Assert.Contains("ruz", fullName);
        }

        [Fact]
        public void StringTools_JoinNames_MustStartWith()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var fullName = sut.Join("Thiago", "Cruz");

            // Assert
            Assert.StartsWith("Thi", fullName);
        }

        [Fact]
        public void StringTools_JoinNames_MustEndWith()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var fullName = sut.Join("Thiago", "Cruz");

            // Assert
            Assert.EndsWith("ruz", fullName);
        }

        [Fact]
        public void StringTools_JoinNames_MustValidateRegularExpression()
        {
            // Arrange
            var sut = new StringTools();

            // Act
            var fullName = sut.Join("Thiago", "Cruz");

            // Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", fullName);
        }
    }
}
