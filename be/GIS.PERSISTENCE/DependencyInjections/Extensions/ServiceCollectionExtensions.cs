using System.Reflection;
using GIS.DOMAIN.Abstractions;
using GIS.DOMAIN.Repositories;
using GIS.PERSISTENCE.Abstractions;
using GIS.PERSISTENCE.DependencyInjections.Options;
using GIS.PERSISTENCE.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GIS.PERSISTENCE.DependencyInjections.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddSqlConfiguration(this IServiceCollection services) 
    {
        services.AddDbContextPool<DbContext, ApplicationDbContext>((provider, builder) =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            var options = provider.GetRequiredService<IOptionsMonitor<SqlServerRetryOptions>>();

            builder
                .EnableDetailedErrors(true)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer(
                    connectionString: configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptionsAction: optionsBuilder =>
                        optionsBuilder.ExecutionStrategy(
                                dependencies => new SqlServerRetryingExecutionStrategy(
                                    dependencies: dependencies,
                                    maxRetryCount: options.CurrentValue.MaxRetryCount,
                                    maxRetryDelay: options.CurrentValue.MaxRetryDelay,
                                    errorNumbersToAdd: options.CurrentValue.ErrorNumbersToAdd))
                            .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name));
        });

    }

    public static void AddRepositoryBaseConfiguration(this IServiceCollection services)
    {
        var assembly = AssemblyReference.Assembly;
        var repositoryTypes = assembly.GetTypes()
            .Where(t =>
                t.IsClass &&
                !t.IsAbstract &&
                t.Name.EndsWith("Repository"));

        foreach (var implementation in repositoryTypes)
        {
            var interfaceType = implementation.GetInterfaces()
                .FirstOrDefault(i =>
                    i.Name == $"I{implementation.Name}");

            if (interfaceType != null)
            {
                services.AddScoped(interfaceType, implementation);
            }
        }

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }


    public static OptionsBuilder<SqlServerRetryOptions> ConfigureSqlServerRetryOptions(this IServiceCollection services, IConfigurationSection section)
        => services
            .AddOptions<SqlServerRetryOptions>()
            .Bind(section)
            .ValidateDataAnnotations()
            .ValidateOnStart();
    
    
}