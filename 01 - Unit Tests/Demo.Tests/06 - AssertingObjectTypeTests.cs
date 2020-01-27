using Xunit;

namespace Demo.Tests
{
    public class AssertingObjectTypeTests
    {
        [Fact]
        public void EmployeeFactory_Create_ShouldReturnEmployeeType()
        {
            // Arrange and Act
            var employee = EmployeeFactory.Create("Thiago", 11000);

            // Assert
            Assert.IsType<Employee>(employee);
        }

        [Fact]
        public void EmployeeFactory_Create_ShouldReturnEmployeeTypeDerivative()
        {
            // Arrange and Act
            var employee = EmployeeFactory.Create("Thiago", 11000);

            // Assert
            Assert.IsAssignableFrom<Person>(employee);
        }
    }
}
