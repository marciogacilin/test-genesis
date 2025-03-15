using TestGenesis.Server.Domain.Interfaces;

namespace TestGenesis.Server.Application.Services;

public class CalculatorIncomeTaxService : ICalculatorIncomeTaxService
{
    public decimal Calculate(decimal profit, int months)
    {
        var aliquot = months switch
        {
            int m when (m <= 6) => 0.225m,
            int m when (m <= 12) => 0.20m,
            int m when (m <= 24) => 0.175m,
            _ => 0.15m,
        };

        return profit * aliquot;
    }
}
