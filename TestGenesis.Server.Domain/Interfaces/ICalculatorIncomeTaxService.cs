namespace TestGenesis.Server.Domain.Interfaces;

public interface ICalculatorIncomeTaxService
{
    decimal Calculate(decimal profit, int months);
}
