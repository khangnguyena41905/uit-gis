using GIS.API.Commons.Helpers;

namespace GIS.API.DependencyInjections.Extensions;

public static class AddApplicationHelper
{
    public static IServiceCollection AddApplicationHelpers(
        this IServiceCollection services)
    {
        services.AddSingleton<IAuthHelper, AuthHelper>();

        return services;
    }
}
