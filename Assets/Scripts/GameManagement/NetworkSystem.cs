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
        OnClientStarted?.Invoke();
    }

    private void OnServerStopped_Internal()
    {
        Debug.Log("Server stopped");
        OnServerStarted?.Invoke();
    }
}
