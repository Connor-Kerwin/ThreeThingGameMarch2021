using UnityEngine;
using UnityEngine.UI;

public class ScoreSetter : MonoBehaviour
{
    public Text Text;

    private ScoreSystem scoreSystem;

    private void Start()
    {
        scoreSystem = ScoreSystem.Instance;
        UpdateScore();
    }

    public void UpdateScore()
    {
        int score = scoreSystem.Score;
        Text.text = $"SCORE: {score}";
    }
}