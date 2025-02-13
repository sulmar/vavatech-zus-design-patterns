using Xunit;

namespace DecoratorPattern.UnitTests;

public class EmployeeLeaveTests
{

    [Fact]
    public void CalculateLeaveDays_WhenNoAdditionalConditions_ShouldReturnBaseLeave()
    {
        // Arrange
        ILeaveCalculator employeeLeave = new BaseLeave(baseLeaveDays: 20);

        // Act
        int result = employeeLeave.CalculateLeaveDays();

        // Assert
        Assert.Equal(20, result);
    }

    [Fact]
    public void CalculateLeaveDays_ForSeniorityOf5OrMoreYears_ShouldAdd5Days()
    {
        // Arrange
        ILeaveCalculator employeeLeave = new SeniorityLeaveDecorator(
                                            new BaseLeave(baseLeaveDays: 20), seniorityYears: 5);

        // Act
        int result = employeeLeave.CalculateLeaveDays();

        // Assert
        Assert.Equal(25, result);
    }

    [Fact]
    public void CalculateLeaveDays_ForCompletedTraining_ShouldAdd3Days()
    {
        // Arrange
        var employeeLeave = new CompletedTrainingLeaveDecorator(
                                                        new BaseLeave(baseLeaveDays: 20), hasCompletedTraining: true);

        // Act
        int result = employeeLeave.CalculateLeaveDays();

        // Assert
        Assert.Equal(23, result);
    }

    [Fact]
    public void CalculateLeaveDays_ForSpecialBenefits_ShouldAdd2Days()
    {
        // Arrange
        var employeeLeave = new SpecialBenefitsLeaveDecorator(new BaseLeave(baseLeaveDays: 20), hasSpecialBenefits: true);

        // Act
        int result = employeeLeave.CalculateLeaveDays();

        // Assert
        Assert.Equal(22, result);
    }

    [Fact]
    public void CalculateLeaveDays_ForAllConditionsMet_ShouldReturn30()
    {
        // Arrange
        var employeeLeave = new SpecialBenefitsLeaveDecorator(
                                                    new CompletedTrainingLeaveDecorator(
                                                            new SeniorityLeaveDecorator(
                                                                    new BaseLeave(baseLeaveDays: 20), seniorityYears: 5), hasCompletedTraining: true), hasSpecialBenefits: true);

        // Act
        int result = employeeLeave.CalculateLeaveDays();

        // Assert
        Assert.Equal(30, result);
    }

    

}
