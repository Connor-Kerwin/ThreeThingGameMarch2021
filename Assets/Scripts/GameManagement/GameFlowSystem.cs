public enum GameFlowState
{
    None,
    Joining,
    TeamSelect,
    Playing
}

public class GameFlowSystem : GameSystem<GameFlowSystem>
{
    public delegate void StateChangedEvent(GameFlowState state);

    public GameFlowState State { get; private set; }

    public event StateChangedEvent OnStateChanged;

    public void SetState(GameFlowState state)
    {
        State = state;
        OnStateChanged?.Invoke(state);
    }
}