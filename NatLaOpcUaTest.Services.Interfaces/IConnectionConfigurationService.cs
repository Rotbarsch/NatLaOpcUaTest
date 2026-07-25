using NatLaOpcUaTest.Core.Contracts;

namespace NatLaOpcUaTest.Services.Interfaces;

public interface IConnectionConfigurationService
{
    OpcUaConnectionSettings ConnectionSettings { get; init; }
    void SetEndpoint(string endpointAddress);
    void SetCredentials(string user, string password);
    void SetCertificate(string certificateFilePath);
    void SetApplicationName(string applicationName);
    void SetDefaultSessionTimeout(int timeoutMs);
}