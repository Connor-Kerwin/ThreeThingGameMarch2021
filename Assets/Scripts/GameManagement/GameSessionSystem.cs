using System;

public class GameSessionSystem : GameSystem<GameSessionSystem>
{
    public bool InSession { get; private set; }

    public event Action OnStartSession;
    public event Action OnEndSession;

    public void StartSession()
    {
        InSession = true;
        OnStartSession?.Invoke();
    }

    public void EndSession()
    {
        InSession = false;
        OnEndSession?.Invoke();
    }
}
