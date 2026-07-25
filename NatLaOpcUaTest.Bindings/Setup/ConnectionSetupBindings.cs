using NatLaOpcUaTest.Bindings.Interfaces.Setup;
using NatLaOpcUaTest.Drivers.Interfaces;
using NUnit.Framework;
using Reqnroll;

namespace NatLaOpcUaTest.Bindings.Setup;

[Binding]
public class ConnectionSetupBindings(IConnectionConfigurationDriver connectionConfigurationDriver): IConnectionSetupBindings
{
    [Given("the application name '(.*)'")]
    public void SetApplicationName(string applicationName)
    {
        connectionConfigurationDriver.SetApplicationName(applicationName);
    }

    [Given("the endpoint '(.*)'")]
    public void SetEndpoint(string endpointAddress)
    {
        connectionConfigurationDriver.SetEndpoint(endpointAddress);
    }

    [Given("the default session timeout of '(.*)' ms")]
    public void SetDefaultTimeout(string timeoutMsAsString)
    {
        if (!int.TryParse(timeoutMsAsString, out int timeoutMs)) Assert.Fail($"{timeoutMsAsString} is not a valid integer.");
        connectionConfigurationDriver.SetDefaultSessionTimeout(timeoutMs);
    }

    [Given("the credentials as username '(.*)' and password '(.*)'")]
    public void SetUserNameAndPassword(string user, string password)
    {
        connectionConfigurationDriver.SetCredentials(user, password);
    }
}