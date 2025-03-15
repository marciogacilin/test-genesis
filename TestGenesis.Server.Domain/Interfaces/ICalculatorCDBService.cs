using TestGenesis.Server.Domain.Responses;

namespace TestGenesis.Server.Domain.Interfaces;

public interface ICalculatorCDBService
{
    Task<ResultCalculationCDBResponse> Calculate(decimal initialValue, int months);
}
