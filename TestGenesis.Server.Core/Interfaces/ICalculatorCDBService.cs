using TestGenesis.Server.Core.Responses;

namespace TestGenesis.Server.Core.Interfaces;

public interface ICalculatorCDBService
{
    Task<ResultCalculationResponse> Calculate(decimal initialValue, int months);
}
