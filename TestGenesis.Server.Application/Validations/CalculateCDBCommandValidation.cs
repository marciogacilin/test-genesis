using FluentValidation;
using TestGenesis.Server.Application.Commands;

namespace TestGenesis.Server.Application.Validations;

public class CalculateCDBCommandValidation : AbstractValidator<CalculateCDBCommand>
{
    public CalculateCDBCommandValidation()
    {
        RuleFor(i => i.InitialValue)
            .GreaterThan(0)
            .WithMessage("Informe um valor monetáio");

        RuleFor(i => i.Months)
            .GreaterThan(1)
            .WithMessage("Informe um prazo em meses maior que 1");
    }
}
