using System.Collections;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;

public class ScoreSystem : GameSystem<ScoreSystem>
{
    public int Score { get; private set; }

    public event Action OnScoreChanged;

    protected override void Awake()
    {
        base.Awake();
    }

    public void ResetScore()
    {
        Score = 0;
        OnScoreChanged?.Invoke();
    }

    public void AddScore(int score)
    {
        Debug.Log($"Adding score {score} to {Score}");
        Score += score;
        OnScoreChanged?.Invoke();
    }
}
