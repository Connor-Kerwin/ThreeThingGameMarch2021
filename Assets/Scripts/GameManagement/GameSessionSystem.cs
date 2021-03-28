using System;

public class GameSessionSystem : GameSystem<GameSessionSystem>
{
    public bool InSession { get; private set; }

    public event Action OnStartSession;
    public event Action OnEndSession;

    public void StartSession()
    {
        UnityEngine.Debug.Log($"Starting session");

        InSession = true;
        OnStartSession?.Invoke();
    }

    public void EndSession()
    {
        UnityEngine.Debug.Log($"Ending session");

        InSession = false;
        OnEndSession?.Invoke();
    }
}
