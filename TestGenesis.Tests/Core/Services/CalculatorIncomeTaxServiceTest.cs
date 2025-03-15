using TestGenesis.Server.Application.Services;

namespace TestGenesis.Tests.Core.Services;

public class CalculatorIncomeTaxServiceTest
{
    [Theory]
    [InlineData(500, 6, 112.5)]
    [InlineData(1000, 12, 200)]
    [InlineData(2000, 24, 350)]
    [InlineData(3000, 30, 450)]
    public void Calculate(decimal profit, int months, decimal expected)
    {
        // Arrange
        var calculatorIncomeTaxService = new CalculatorIncomeTaxService();

        // Act
        var result = calculatorIncomeTaxService.Calculate(profit, months);

        // Assert
        Assert.Equal(expected, result);
    }
}
