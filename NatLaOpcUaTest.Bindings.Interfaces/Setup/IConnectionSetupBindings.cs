namespace NatLaOpcUaTest.Bindings.Interfaces.Setup;

public interface IConnectionSetupBindings
{
    void SetEndpoint(string endpointAddress);
    void SetUserNameAndPassword(string user, string password);
}