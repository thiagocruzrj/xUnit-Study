using Xunit;

namespace Demo.Tests
{
    public class AssertingCollectionsTests
    {
        [Fact]
        public void Employee_Skills_ShouldntHaveEmptySkills()
        {
            // Arrange and Act
            var employee = EmployeeFactory.Create("Thiago", 11000);

            // Assert
            Assert.All(employee.Skills, skill => Assert.False(string.IsNullOrWhiteSpace(skill)));
        }

        [Fact]
        public void Employee_Skills_JuniorShouldHaveBasicSkill()
        {
            // Arrange and Act
            var employee = EmployeeFactory.Create("Thiago", 1000);

            // Assert 
            Assert.Contains("OOP", employee.Skills);
        }

        [Fact]
        public void Employee_Skills_JuniorShouldntHaveAdvancedSkill()
        {
            // Arrange and Act
            var employee = EmployeeFactory.Create("Thiago", 1000);

            // Assert 
            Assert.DoesNotContain("Microservices", employee.Skills);
        }

        [Fact]
        public void Employee_Skills_SeniorShouldHaveAllSkills()
        {
            // Arrange and Act
            var employee = EmployeeFactory.Create("Thiago", 15000);

            var basicSkills = new[]
            {
                "Programming logic",
                "OOP",
                "Tests",
                "Microservices"
            };

            // Assert 
            Assert.Equal(basicSkills, employee.Skills);
        }
    }
}
