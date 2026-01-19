using GIS.API.DependencyInjections.Options;

namespace GIS.API.DependencyInjections.Extensions;

public static class AddOptionRegister
{
    public static IServiceCollection AddOptionsRegister(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<SqlServerRetryOptions>(
            configuration.GetSection("SqlServerRetryOptions"));

        services.Configure<JwtSettings>(
            configuration.GetSection("Jwt"));

        return services;
    }
}
