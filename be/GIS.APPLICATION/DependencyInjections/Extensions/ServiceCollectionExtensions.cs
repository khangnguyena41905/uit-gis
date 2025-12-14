using FluentValidation;
using GIS.APPLICATION.Abstractions.Behaviors;
using GIS.APPLICATION.Commons.Helpers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GIS.APPLICATION.DependencyInjections.Extensions;


public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConffigMediatR(this IServiceCollection services)
        => services.AddMediatR(opt => opt.RegisterServicesFromAssembly(AssemblyReference.Assembly))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
            .AddValidatorsFromAssembly(AssemblyReference.Assembly, includeInternalTypes: true);

    public static IServiceCollection AddApplicationHelper(this IServiceCollection services)
    {
        services.AddSingleton<IAuthHelper, AuthHelper>();
        return services;
    }
}