using NatLaOpcUaTest.Drivers.Interfaces;
using NUnit.Framework;
using Reqnroll;

namespace NatLaOpcUaTest.Bindings.Setup;

[Binding]
public class ConnectionSetupBindings(IConnectionConfigurationDriver connectionConfigurationDriver)
{
    /// <summary>
    /// Sets the OPC UA client application name used when establishing a session with the server.
    /// </summary>
    /// <param name="applicationName">The application name to register with the OPC UA server.</param>
    [Given("the application name '(.*)'")]
    public void SetApplicationName(string applicationName)
    {
        connectionConfigurationDriver.SetApplicationName(applicationName);
    }

    /// <summary>
    /// Sets the OPC UA server endpoint URL to connect to.
    /// </summary>
    /// <param name="endpointAddress">The endpoint URL of the OPC UA server (e.g. <c>opc.tcp://localhost:4840</c>).</param>
    [Given("the endpoint '(.*)'")]
    public void SetEndpoint(string endpointAddress)
    {
        connectionConfigurationDriver.SetEndpoint(endpointAddress);
    }

    /// <summary>
    /// Sets the default OPC UA session timeout in milliseconds.
    /// </summary>
    /// <param name="timeoutMsAsString">The session timeout in milliseconds, supplied as a string. Must be parseable as a valid integer.</param>
    [Given("the default session timeout of '(.*)' ms")]
    public void SetDefaultTimeout(string timeoutMsAsString)
    {
        if (!int.TryParse(timeoutMsAsString, out int timeoutMs)) Assert.Fail($"{timeoutMsAsString} is not a valid integer.");
        connectionConfigurationDriver.SetDefaultSessionTimeout(timeoutMs);
    }

    /// <summary>
    /// Sets the username and password credentials used to authenticate with the OPC UA server.
    /// </summary>
    /// <param name="user">The username for authentication.</param>
    /// <param name="password">The password for authentication.</param>
    [Given("the credentials as username '(.*)' and password '(.*)'")]
    public void SetUserNameAndPassword(string user, string password)
    {
        connectionConfigurationDriver.SetCredentials(user, password);
    }
}