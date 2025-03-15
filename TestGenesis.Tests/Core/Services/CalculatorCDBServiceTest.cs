using TestGenesis.Server.Application.Services;
using TestGenesis.Server.Domain.Responses;

namespace TestGenesis.Tests.Core.Services;

public class CalculatorCDBServiceTest
{
    public static IEnumerable<object[]> TestData
        => new List<object[]>
        {
            new object[] { 500, 6, new ResultCalculationCDBResponse(529.87m, 523.15m) },
            new object[] { 600, 12, new ResultCalculationCDBResponse(673.84m, 659.07m) },
            new object[] { 800, 24, new ResultCalculationCDBResponse(1009.05m, 972.46m) },
            new object[] { 1000, 30, new ResultCalculationCDBResponse(1336.68m, 1286.18m) }
        };

    [Theory]
    [MemberData(nameof(TestData))]
    public async Task Calculate(decimal value, int months, ResultCalculationCDBResponse expected)
    {
        // Arrange
        var cdbCalculateService = new CalculatorCDBService(new CalculatorIncomeTaxService());

        // Act
        var result = await cdbCalculateService.Calculate(value, months);

        // Assert
        Assert.Equal(expected, result);
    }
}
