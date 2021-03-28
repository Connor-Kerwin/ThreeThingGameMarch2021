using UnityEngine.Events;

public class PlayerSystemInterface : GameSystemInterface<PlayerSystem>
{
    public UnityEvent OnPlayerSpawned;
    public UnityEvent OnPlayerDespawned;

    protected override void Awake()
    {
        base.Awake();

        Target.OnPlayerSpawned += OnPlayerSpawned_Internal;
        Target.OnPlayerDespawned += OnPlayerDespawned_Internal;
    }

    private void OnDestroy()
    {
        if (Target != null)
        {
            Target.OnPlayerSpawned += OnPlayerSpawned_Internal;
            Target.OnPlayerDespawned += OnPlayerDespawned_Internal;
        }
    }

    private void OnPlayerSpawned_Internal(GamePlayer obj)
    {
        OnPlayerSpawned.Invoke();
    }

    private void OnPlayerDespawned_Internal(GamePlayer obj)
    {
        OnPlayerDespawned.Invoke();
    }

    public void SpawnPlayer()
    {
        Target.SpawnPlayer();
    }

    public void DespawnPlayer()
    {
        Target.DespawnPlayer();
    }

    protected override PlayerSystem GetTarget()
    {
        return PlayerSystem.Instance;
    }

    [System.Serializable]
    public class UnityEvent_GamePlayer : UnityEvent<GamePlayer> { }
}