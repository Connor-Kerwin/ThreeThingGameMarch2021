using UnityEngine.Events;

public class GameSessionSystemInterface : GameSystemInterface<GameSessionSystem>
{
    public UnityEvent OnSessionStarted;
    public UnityEvent OnSessionEnded;

    private void Start()
    {
        Target.OnStartSession += OnStartSession;
        Target.OnEndSession += OnEndSession;
    }

    private void OnDestroy()
    {
        if(Target != null)
        {
            Target.OnStartSession -= OnStartSession;
            Target.OnEndSession -= OnEndSession;
        }
    }

    private void OnStartSession()
    {
        OnSessionStarted.Invoke();
    }

    private void OnEndSession()
    {
        OnSessionEnded.Invoke();
    }

    public void StartSession()
    {
        Target.StartSession();
    }

    public void EndSession()
    {
        Target.EndSession();
    }

    protected override GameSessionSystem GetTarget()
    {
        return GameSessionSystem.Instance;
    }
}