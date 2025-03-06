using Newtonsoft.Json.Linq;
using TestGenesis.Server.Core.Responses;
using TestGenesis.Server.Core.Services;

namespace TestGenesis.Tests.Core.Services;

public class CalculatorCDBServiceTest
{
    public static IEnumerable<object[]> TestData
        => new List<object[]>
        {
            new object[] { 500, 6, new ResultCalculationResponse(529.87m, 523.15m) },
            new object[] { 600, 12, new ResultCalculationResponse(673.84m, 659.07m) },
            new object[] { 800, 24, new ResultCalculationResponse(1009.05m, 972.46m) },
            new object[] { 1000, 30, new ResultCalculationResponse(1336.68m, 1286.18m) }
        };

    [Theory]
    [MemberData(nameof(TestData))]
    public async Task Calculate(decimal value, int months, ResultCalculationResponse expected)
    {
        // Arrange
        var cdbCalculateService = new CalculatorCDBService(new CalculatorIncomeTaxService());

        // Act
        var result = await cdbCalculateService.Calculate(value, months);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task Calculate_Execute_WithExceptionError()
    {
        // Arrange
        var cdbCalculateService = new CalculatorCDBService(new CalculatorIncomeTaxService());

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => cdbCalculateService.Calculate(-1, 0));

        Assert.Equal("Forneça um valor inicial e prazo em meses maiores que zero.", exception.Message);
    }
}
