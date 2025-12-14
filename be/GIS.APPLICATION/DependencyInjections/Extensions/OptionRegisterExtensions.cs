using GIS.DOMAIN.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GIS.APPLICATION.DependencyInjections.Extensions;

public static class OptionRegisterExtensions
{
    public static IServiceCollection AddOptionRegister(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddOptions<JwtSettings>()
            .Bind(configuration.GetSection("Jwt"))
            .ValidateDataAnnotations()
            .ValidateOnStart();
        
        return services;
    }
}