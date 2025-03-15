using MediatR;
using TestGenesis.Server.Application.Commands;
using TestGenesis.Server.Domain.Interfaces;
using TestGenesis.Server.Domain.Responses;

namespace TestGenesis.Server.Application.CommandHandlers;

public class CalculateCDBCommandHandler(ICalculatorCDBService calculatorCDBService) 
    : IRequestHandler<CalculateCDBCommand, ResultCalculationCDBResponse>
{
    public async Task<ResultCalculationCDBResponse> Handle(CalculateCDBCommand request, CancellationToken cancellationToken)
    {
        var result = await calculatorCDBService.Calculate(request.InitialValue, request.Months);

        return result;
    }
}
