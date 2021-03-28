using UnityEngine.Events;

public class GameFlowSystemInterface : GameSystemInterface<GameFlowSystem>
{
    [System.Serializable]
    public class UnityEvent_GameFlowState : UnityEvent<GameFlowState> { }

    public UnityEvent_GameFlowState OnFlowStateChanged;

    protected override void Awake()
    {
        base.Awake();
        Target.OnStateChanged += OnFlowStateChanged.Invoke;
    }

    private void OnDestroy()
    {
        if(Target != null)
        {
            Target.OnStateChanged -= OnFlowStateChanged.Invoke;
        }
    }

    protected override GameFlowSystem GetTarget()
    {
        return GameFlowSystem.Instance;
    }

    public void SetStateMenu()
    {
        Target.SetState(GameFlowState.Menu);
    }

    public void SetStatePlaying()
    {
        Target.SetState(GameFlowState.Game);
    }

    public void SetStateDeath()
    {
        Target.SetState(GameFlowState.Death);
    }
}