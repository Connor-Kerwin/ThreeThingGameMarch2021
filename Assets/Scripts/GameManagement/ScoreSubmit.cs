using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreSubmit : MonoBehaviour
{
    private bool submitting;

    public Text field;

    public UnityEvent OnScoreSubmitSuccessful;
    public UnityEvent OnScoreSubmitFailed;

    private void Start()
    {
        HighscoreSystem.Instance.OnScoreUploadFinished += OnHighscoreSubmitted;
    }

    public void SubmitScore()
    {
        if (submitting)
        {
            return;
        }

        string name = field.text;
        if (string.IsNullOrEmpty(name))
        {
            return;
        }

        int score = ScoreSystem.Instance.Score;

        StartCoroutine(SubmitScoresAsync(score, name));
    }

    private IEnumerator SubmitScoresAsync(int score, string name)
    {
        submitting = true;

        yield return HighscoreSystem.Instance.SubmitScoreAsync(score, name);

        submitting = false;
    }

    private void OnHighscoreSubmitted(bool obj)
    {
        if (!GameSessionSystem.Instance.InSession)
        {
            return;
        }

        if (obj)
        {
            OnScoreSubmitSuccessful.Invoke();
        }
        else
        {
            OnScoreSubmitFailed.Invoke();
        }
    }
}
