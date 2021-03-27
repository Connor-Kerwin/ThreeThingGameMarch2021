using Mirror;
using System;

public class GameNetworkManager : NetworkManager
{
    public event Action OnServerStarted;
    public event Action OnClientStarted;

    public event Action OnServerStopped;
    public event Action OnClientStopped;

    public override void OnStartServer()
    {
        base.OnStartServer();
        OnServerStarted?.Invoke();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        OnClientStarted?.Invoke();
    }

    public override void OnStopServer()
    {
        base.OnStopServer();
        OnServerStopped?.Invoke();
    }

    public override void OnStopClient()
    {
        base.OnStopClient();
        OnClientStopped?.Invoke();
    }
}
