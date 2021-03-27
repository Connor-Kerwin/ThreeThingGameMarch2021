using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ScoreSystem : GameSystem<ScoreSystem>
{
    public int Score { get; private set; }

    public void ResetScore()
    {
        Score = 0;
    }

    public void AddScore(int score)
    {
        Score += score;
    }

    public async Task SubmitScoreToRemote(string username)
    {
        await Task.Delay(1000);
    }
}
