using Newtonsoft.Json.Linq;
using TestGenesis.Server.Core.Responses;
using TestGenesis.Server.Core.Services;

namespace TestGenesis.Tests.Core.Services;

public class CalculatorCDBServiceTest
{
    public static IEnumerable<object[]> TestData
        => new List<object[]>
        {
            new object[] { 500, 6, new ResultCalculationResponse(529.87783850744922505941944115m, 523.15532484327314942105006689m) },
            new object[] { 600, 12, new ResultCalculationResponse(673.84925697918345791046217450m, 659.07940558334676632836973960m) },
            new object[] { 800, 24, new ResultCalculationResponse(1009.0507136253280581327661022m, 972.4668387408956479595320343m) },
            new object[] { 1000, 30, new ResultCalculationResponse(1336.6840277004699403973882803m, 1286.1814235453994493377800383m) }
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

        Assert.Equal("Forneça um valor inicial e prazo em meses maior que zero.", exception.Message);
    }
}
