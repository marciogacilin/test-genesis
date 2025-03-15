namespace TestGenesis.Server.Domain.Responses;

public record ResultErrorResponse(int Status, IEnumerable<string> Errors);