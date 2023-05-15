using FootballStats.WebApi.FunctionalTests.Drivers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using SolidToken.SpecFlow.DependencyInjection;

namespace FootballStats.WebApi.FunctionalTests.Steps;

public class ServiceCollectionExtensions
{
    private static readonly IConfigurationRoot Configuration = new ConfigurationBuilder()
        .AddUserSecrets<ServiceCollectionExtensions>()
        .AddEnvironmentVariables()
        .Build();
    
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var baseAddress = Configuration.GetValue<string>("FootballStatsWebApi:Url");
        var services = new ServiceCollection()
            .AddTransient<HttpDriver>()
            .AddRefitClient<IFootballStatusApi>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(baseAddress!);
            })
            .Services;

        return services;
    }
}