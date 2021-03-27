using UnityEngine.Events;

public class PlayerSystemInterface : GameSystemInterface<PlayerSystem>
{
    public UnityEvent_GamePlayer OnPlayerChanged;

    protected override void Awake()
    {
        base.Awake();

        Target.OnPlayerChanged += OnPlayerChangedInternal;
    }

    private void OnPlayerChangedInternal(GamePlayer obj)
    {
        OnPlayerChanged.Invoke(obj);
    }

    protected override PlayerSystem GetTarget()
    {
        return PlayerSystem.Instance;
    }

    [System.Serializable]
    public class UnityEvent_GamePlayer : UnityEvent<GamePlayer> { }
}