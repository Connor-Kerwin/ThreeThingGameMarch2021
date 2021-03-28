using System.Collections;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class ScoreSystem : GameSystem<ScoreSystem>
{
    public int Score { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    public void ResetScore()
    {
        Score = 0;
    }

    public void AddScore(int score)
    {
        Score += score;
    }
}
