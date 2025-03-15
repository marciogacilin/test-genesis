using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TestGenesis.Server.Application.Services;
using TestGenesis.Server.Application.Validations;
using TestGenesis.Server.Domain.Interfaces;

namespace TestGenesis.Server.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectReferencies(this IServiceCollection services)
    {
        services.AddScoped<ICalculatorIncomeTaxService, CalculatorIncomeTaxService>();
        services.AddScoped<ICalculatorCDBService, CalculatorCDBService>();

        var handlers = AppDomain.CurrentDomain.Load("TestGenesis.Server.Application");
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(handlers);
            cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.Load("TestGenesis.Server.Application"));

        return services;
    }
}
