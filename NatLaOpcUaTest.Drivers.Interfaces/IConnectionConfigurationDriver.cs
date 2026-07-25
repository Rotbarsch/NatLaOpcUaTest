namespace NatLaOpcUaTest.Drivers.Interfaces;

public interface IConnectionConfigurationDriver
{
    void SetEndpoint(string endpointAddress);
    void SetCredentials(string user, string password);
    void SetCertificate(string certificateFilePath);
    void SetApplicationName(string applicationName);
    void SetDefaultSessionTimeout(int timeoutMsAsString);
}