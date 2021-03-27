using UnityEngine.Events;

public class PlayerSystemInterface : GameSystemInterface<PlayerSystem>
{
    protected override void Awake()
    {
        base.Awake();
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