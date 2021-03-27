using Mirror;
using System;

public class GameNetworkManager : NetworkManager
{
    public event Action OnServerStarted;
    public event Action OnClientStarted;
    public event Action OnServerStopped;
    public event Action OnClientStopped;

    public bool IsServerRunning { get; private set; }
    public bool IsClientRunning { get; private set; }

    public override void OnStartServer()
    {
        base.OnStartServer();
        IsServerRunning = true;
        OnServerStarted?.Invoke();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        IsClientRunning = true;
        OnClientStarted?.Invoke();
    }

    public override void OnStopServer()
    {
        base.OnStopServer();
        IsServerRunning = false;
        OnServerStopped?.Invoke();
    }

    public override void OnStopClient()
    {
        base.OnStopClient();
        IsClientRunning = false;
        OnClientStopped?.Invoke();
    }
}
