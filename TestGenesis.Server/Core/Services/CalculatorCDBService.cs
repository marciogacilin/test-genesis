using TestGenesis.Server.Core.Interfaces;
using TestGenesis.Server.Core.Responses;

namespace TestGenesis.Server.Core.Services;

public class CalculatorCDBService(ICalculatorIncomeTaxService calculatorIncomeTaxService) : ICalculatorCDBService
{
    private const decimal TB = 1.08m;
    private const decimal CDI = 0.009m;

    public async Task<ResultCalculationResponse> Calculate(decimal initialValue, int months)
    {
        if (initialValue <= 0 || months <= 0)
            throw new ArgumentException("Forneça um valor inicial e prazo em meses maiores que zero.");
        
        decimal gross = initialValue;
        decimal tax = 0;
        decimal liquid = 0;

        await Task.Run(() =>
        {
            for (int i = 0; i < months; i++)
            {
                gross *= (1 + (CDI * TB));
            }

            tax = calculatorIncomeTaxService.Calculate(gross - initialValue, months);

            liquid = gross - tax;
            gross = Math.Truncate(gross * 100) / 100m;
            liquid = Math.Truncate(liquid * 100) / 100m;
        });

        return new ResultCalculationResponse(gross, liquid);
    }
}
