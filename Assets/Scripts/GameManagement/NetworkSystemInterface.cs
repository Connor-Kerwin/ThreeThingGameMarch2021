using UnityEngine.Events;

public class NetworkSystemInterface : GameSystemInterface<NetworkSystem>
{
    public UnityEvent OnServerStarted;
    public UnityEvent OnClientStarted;
    public UnityEvent OnServerStopped;
    public UnityEvent OnClientStopped;

    private void Start()
    {
        Target.OnServerStarted += OnServerStarted.Invoke;
        Target.OnServerStopped += OnServerStopped.Invoke;
        Target.OnClientStarted += OnClientStarted.Invoke;
        Target.OnClientStopped += OnClientStopped.Invoke;
    }

    private void OnDestroy()
    {
        if (Target != null)
        {
            Target.OnServerStarted -= OnServerStarted.Invoke;
            Target.OnServerStopped -= OnServerStopped.Invoke;
            Target.OnClientStarted -= OnClientStarted.Invoke;
            Target.OnClientStopped -= OnClientStopped.Invoke;
        }
    }

    protected override NetworkSystem GetTarget()
    {
        return NetworkSystem.Instance;
    }
}