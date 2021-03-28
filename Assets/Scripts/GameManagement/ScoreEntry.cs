using UnityEngine;
using UnityEngine.UI;

public class ScoreEntry : MonoBehaviour
{
    public Text Title;
    public Text Score;

    public void SetValues(string title, int score)
    {
        Title.text = title;
        Score.text = $"{score}";
    }
}
