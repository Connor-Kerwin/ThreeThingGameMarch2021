using UnityEngine;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour
{
    public ScoreEntry[] scores;

    private void Start()
    {
        HighscoreSystem.Instance.OnScoresChanged += OnScoresChanged;
        Refresh();
    }

    public void Refresh()
    {
        List<ScoreData> temp = new List<ScoreData>();
        HighscoreSystem.Instance.GetScores(temp);

        // Reset
        for(int i = 0; i < scores.Length; i++)
        {
            ScoreEntry entry = scores[i];
            entry.SetValues("---", 0);
        }

        int num = Mathf.Clamp(temp.Count, 0, scores.Length);
        for(int i = 0; i < num; i++)
        {
            ScoreEntry entry = scores[i];
            entry.SetValues(temp[i].UserName, temp[i].Score);
        }
    }

    private void OnScoresChanged()
    {
        Refresh();
    }
}
