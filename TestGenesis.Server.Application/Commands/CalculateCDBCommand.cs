using MediatR;
using TestGenesis.Server.Domain.Responses;

namespace TestGenesis.Server.Application.Commands;

public record CalculateCDBCommand(decimal InitialValue, int Months) : IRequest<ResultCalculationCDBResponse>;