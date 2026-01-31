using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StackErp.Application.Common.Behaviors;
using System.Reflection;

namespace StackErp.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Registra o MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // Registra os validadores do FluentValidation manualmente
        RegisterValidators(services);

        // Registra o ValidationBehavior no pipeline do MediatR
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }

    private static void RegisterValidators(IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var validatorTypes = assembly.GetTypes()
            .Where(t => t.BaseType != null &&
                        t.BaseType.IsGenericType &&
                        t.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>));

        foreach (var validatorType in validatorTypes)
        {
            var validatorInterface = typeof(IValidator<>).MakeGenericType(validatorType.BaseType.GetGenericArguments()[0]);
            services.AddTransient(validatorInterface, validatorType);
        }
    }
}