using Microsoft.Extensions.DependencyInjection;
using NatLaOpcUaTest.Drivers.Interfaces;

namespace NatLaOpcUaTest.Drivers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterNatLaOpcUaTestDrivers(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IConnectionConfigurationDriver, ConnectionConfigurationConfigurationDriver>()
            .AddScoped<INodeReadDriver, NodeReadDriver>()
            .AddScoped<INodeWriteDriver, NodeWriteDriver>()
            .AddScoped<INodeMethodDriver, NodeMethodDriver>();
        
        return serviceCollection;
    }
}