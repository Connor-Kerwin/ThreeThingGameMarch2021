using Mirror;
using System;
using UnityEngine;

public class NetworkSystem : GameSystem<NetworkSystem>
{
    public GameNetworkManager NetworkManager;

    public event Action OnServerStarted;
    public event Action OnClientStarted;
    public event Action OnServerStopped;
    public event Action OnClientStopped;

    private void Start()
    {
        NetworkManager.OnServerStarted += OnServerStarted_Internal;
        NetworkManager.OnClientStarted += OnClientStarted_Internal;
        NetworkManager.OnServerStopped += OnServerStopped_Internal;
        NetworkManager.OnClientStopped += OnClientStopped_Internal;
    }

    private void OnClientStarted_Internal()
    {
        Debug.Log("Client started");
        OnClientStarted?.Invoke();
    }

    private void OnServerStarted_Internal()
    {
        Debug.Log("Server started");
        OnServerStarted?.Invoke();
    }

    private void OnClientStopped_Internal()
    {
        Debug.Log("Client stopped");
        OnClientStopped?.Invoke();
    }

    private void OnServerStopped_Internal()
    {
        Debug.Log("Server stopped");
        OnServerStopped?.Invoke();
    }

    public void Disconnect()
    {
        // stop host if host mode
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            NetworkManager.StopHost();
        }
        // stop client if client-only
        else if (NetworkClient.isConnected)
        {
            NetworkManager.StopClient();
        }
        // stop server if server-only
        else if (NetworkServer.active)
        {
            NetworkManager.StopServer();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            Disconnect();
        }
    }
}
