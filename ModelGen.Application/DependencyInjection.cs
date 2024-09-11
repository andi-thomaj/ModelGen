using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ModelGen.Application.Validations;

namespace ModelGen.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        
        return services;
    }
}