using Microsoft.Extensions.DependencyInjection;
using NatLaOpcUaTest.Services.Interfaces;

namespace NatLaOpcUaTest.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterNatLaOpcUaTestServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddSingleton<IConnectionConfigurationService, ConnectionConfigurationService>()
            .AddScoped<IOpcUaConnectionService, OpcUaConnectionService>()
            .AddScoped<INodeService, NodeService>();

        return serviceCollection;
    }
}