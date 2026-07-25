using System.Runtime.CompilerServices;

namespace NatLaOpcUaTest.Core.Contracts;

public record OpcUaConnectionSettings
{
    private string _applicationName = "NatLaOpcUaTest";
    private string? _endpoint;
    private string? _username;
    private string? _password;
    private string? _certificateFilePath;
    private int _defaultSessionTimeout = 60000;
    
    public string ApplicationName
    {
        get => _applicationName;
        set
        {
            _applicationName = value;
            OnOnChanged(new OnChangedEventArgs());
        }
    }

    public string? Endpoint
    {
        get => _endpoint;
        set
        {
            _endpoint = value;
            OnOnChanged(new OnChangedEventArgs());
        }
    }

    public string? Username
    {
        get => _username;
        set
        {
            _username = value;
            OnOnChanged(new OnChangedEventArgs());
        }
    }

    public string? Password
    {
        get => _password;
        set
        {
            _password = value;
            OnOnChanged(new OnChangedEventArgs());
        }
    }

    public string? CertificateFilePath
    {
        get => _certificateFilePath;
        set
        {
            _certificateFilePath = value;

            OnOnChanged(new OnChangedEventArgs());
        }
    }

    public int DefaultSessionTimeout
    {
        get => _defaultSessionTimeout;
        set
        {
            _defaultSessionTimeout = value;
            OnOnChanged(new OnChangedEventArgs());
        }
    }

    public event OnChangedEvent? OnChanged;

    protected virtual void OnOnChanged(OnChangedEventArgs args)
    {
        OnChanged?.Invoke(this, args);
    }
}

public delegate void OnChangedEvent(object sender, OnChangedEventArgs args);

public class OnChangedEventArgs([CallerMemberName] string propertyName = "")
{
    public string ChangedPropertyName { get; init; } = propertyName;
}
