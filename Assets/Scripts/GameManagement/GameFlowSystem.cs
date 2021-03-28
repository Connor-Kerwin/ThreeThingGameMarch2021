public enum GameFlowState
{
    Menu,
    Game,
    Death
}

public class GameFlowSystem : GameSystem<GameFlowSystem>
{
    public delegate void StateChangedEvent(GameFlowState state);

    public GameFlowState State { get; private set; }

    public event StateChangedEvent OnStateChanged;

    public void SetState(GameFlowState state)
    {
        UnityEngine.Debug.Log($"Changing state to {state}");

        State = state;
        OnStateChanged?.Invoke(state);
    }

    private void Update()
    {
        if(UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Escape))
        {
            SetState(GameFlowState.Death);
        }
    }
}