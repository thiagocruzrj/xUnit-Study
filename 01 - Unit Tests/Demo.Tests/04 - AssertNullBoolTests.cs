using Xunit;

namespace Demo.Tests
{
    public class AssertNullBoolTests
    {
        [Fact]
        public void Employer_Name_CannotBeNullOrEmpty()
        {
            // Arrange and Act
            var employee = new Employee("", 1000);

            // Assert
            Assert.False(string.IsNullOrEmpty(employee.Name));
        }

        [Fact]
        public void Employee_Nickname_ShouldNotHaveNickname()
        {
            // Arrange and Act
            var employee = new Employee("Thiago", 1000);

            // Assert
            Assert.Null(employee.Nickname);

            // Assert Bool
            Assert.True(string.IsNullOrEmpty(employee.Nickname));
            Assert.False(employee.Nickname?.Length > 0);
        }
    }
}
