using NatLaOpcUaTest.Drivers.Interfaces;
using NatLaOpcUaTest.Services.Interfaces;

namespace NatLaOpcUaTest.Drivers;

internal class ConnectionConfigurationConfigurationDriver(IConnectionConfigurationService connectionConfigurationService) : IConnectionConfigurationDriver
{
    public void SetEndpoint(string endpointAddress)
    {
        connectionConfigurationService.SetEndpoint(endpointAddress);
    }

    public void SetCredentials(string user, string password)
    {
        connectionConfigurationService.SetCredentials(user, password);
    }

    public void SetCertificate(string certificateFilePath)
    {
        connectionConfigurationService.SetCertificate(certificateFilePath);
    }

    public void SetApplicationName(string applicationName)
    {
        connectionConfigurationService.SetApplicationName(applicationName);
    }
        
    public void SetDefaultSessionTimeout(int timeoutMs)
    {
        connectionConfigurationService.SetDefaultSessionTimeout(timeoutMs);
    }
}