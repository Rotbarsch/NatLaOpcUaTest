using NatLaOpcUaTest.Services.Interfaces;
using NatLaOpcUaTest.Core.Contracts;

namespace NatLaOpcUaTest.Services;

internal class ConnectionConfigurationService : IConnectionConfigurationService
{
    public OpcUaConnectionSettings ConnectionSettings { get; init; } = new();

    public void SetEndpoint(string endpointAddress)
    {
        ConnectionSettings.Endpoint = endpointAddress;
    }

    public void SetCredentials(string user, string password)
    {
        ConnectionSettings.Username = user;
        ConnectionSettings.Password = password;
    }

    public void SetCertificate(string certificateFilePath)
    {
        ConnectionSettings.CertificateFilePath = certificateFilePath;
    }

    public void SetApplicationName(string applicationName)
    {
        ConnectionSettings.ApplicationName = applicationName;
    }

    public void SetDefaultSessionTimeout(int timeoutMs)
    {
        ConnectionSettings.DefaultSessionTimeout = timeoutMs;
    }
}