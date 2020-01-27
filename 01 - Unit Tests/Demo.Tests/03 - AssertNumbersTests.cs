using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Tests
{
    public class AssertNumbersTests
    {
        [Fact]
        public void Calculator_Sum_MustBeEqual()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Sum(2, 3);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Calculator_Sum_NotBeEqual()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Sum(1.33333, 1.77778);

            // Assert
            Assert.NotEqual(3.01, result, 5);
        }
    }
}
