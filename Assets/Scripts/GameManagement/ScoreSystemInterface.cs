public class ScoreSystemInterface : GameSystemInterface<ScoreSystem>
{
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