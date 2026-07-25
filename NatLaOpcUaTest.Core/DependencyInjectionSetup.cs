using Microsoft.Extensions.DependencyInjection;
using NatLaOpcUaTest.Drivers;
using Reqnroll.Microsoft.Extensions.DependencyInjection;
using Rotbarsch.Reqnroll.Drivers;
using Rotbarsch.Reqnroll.Services;
using NatLaOpcUaTest.Services;

namespace NatLaOpcUaTest.Core;

/// <summary>
///     Provides setup for dependency injection per scenario using Reqnroll.
/// </summary>
public static class DependencyInjectionSetup
{
    private static IServiceCollection? _services;

    /// <summary>
    ///     Gets the service collection with registered Service services, creating it if necessary.
    /// </summary>
    public static IServiceCollection Services
    {
        get
        {
            _services ??= new ServiceCollection()
                .RegisterRotbarschReqnrollServices()
                .RegisterRotbarschReqnrollDrivers()
                .RegisterNatLaOpcUaTestServices()
                .RegisterNatLaOpcUaTestDrivers();

            return _services;
        }
    }

    /// <summary>
    ///     Configures dependency injection for a scenario.
    /// </summary>
    /// <returns>The configured <see cref="IServiceCollection" />.</returns>
    [ScenarioDependencies]
    public static IServiceCollection SetupDependencyInjection()
    {
        return Services;
    }
}