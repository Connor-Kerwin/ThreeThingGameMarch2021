using UnityEngine.Events;

public class ScoreSystemInterface : GameSystemInterface<ScoreSystem>
{
    public UnityEvent OnScoreChanged;

    private void Start()
    {
        Target.OnScoreChanged += OnScoreChanged.Invoke;
    }

    public void ResetScore()
    {
        Target.ResetScore();
    }

    public void AddScore(int score)
    {
        Target.AddScore(score);
    }

    protected override ScoreSystem GetTarget()
    {
        return ScoreSystem.Instance;
    }
}
