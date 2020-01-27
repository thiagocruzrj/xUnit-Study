using System;
using Xunit;

namespace Demo.Tests
{
    public class AssertingExcepitonsTests
    {
        [Fact]
        public void Calculator_Divide_ShouldReturnErroIfDivisionByZero()
        {
            // Arrage
            var calculator = new Calculator();

            // Act and Assert
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
        }

        [Fact]
        public void Employee_Salary_ShouldReturnErrorIfSalaryLessAllowed()
        {
            // Arrange, Act and Assert
            var exception = Assert.Throws<Exception>(() => EmployeeFactory.Create("Thiago", 230.45));

            Assert.Equal("Salary less than allowed", exception.Message);
        }
    }
}
