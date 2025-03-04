namespace TestGenesis.Server.Core.Interfaces;

public interface ICalculatorIncomeTaxService
{
    decimal Calculate(decimal profit, int months);
}
