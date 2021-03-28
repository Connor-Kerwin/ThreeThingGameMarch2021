using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;

[System.Serializable]
public class ScoreData
{
    public string UserName;
    public int Score;

    public void LoadFrom(ScoreData other)
    {
        UserName = other.UserName;
        Score = other.Score;
    }
}

public class HighscoreSystem : GameSystem<HighscoreSystem>
{
    private const int NUM_SCORES = 10;

    private string secret;
    private ScoreData[] scores;
    private int scoreCount;

    public string GameId;

    public event Action OnScoresChanged;
    public event Action<bool> OnScoreUploadFinished;

    protected override void Awake()
    {
        base.Awake();

        secret = HighscoreSecret.Secret;
        scores = new ScoreData[NUM_SCORES];
        for(int i = 0; i < scores.Length; i++)
        {
            scores[i] = new ScoreData();
        }
    }

    public void RefreshScores()
    {
        StartCoroutine(GetScoresAsync());
    }

    public void SubmitScore(int score, string name)
    {
        StartCoroutine(SubmitScoreAsync(score, name));
    }

    public int GetScores(List<ScoreData> inScores)
    {
        for(int i = 0; i < scoreCount; i++)
        {
            inScores.Add(scores[i]);
        }

        return scoreCount;
    }

    public IEnumerator SubmitScoreAsync(int score, string name)
    {
        if(string.IsNullOrEmpty(name)) // If the name is somehow invalid, force it to be valid, this should NEVER happen anyway
        {
            name = "PLAYER";
        }

        var hash = this.GenerateHash(score, name);
        var json = $"{{\"Hash\":\"{hash}\",\"UserName\": \"{name}\", \"Score\": \"{score}\", \"GameId\":\"{this.GameId}\"}}";

        yield return PostScoreAsync(json, "https://chickensimulator.com/api/submit");
    }

    public IEnumerator GetScoresAsync()
    {
        string url = $"https://chickensimulator.com/api/scores/{GameId}";
        using (var request = new UnityWebRequest(url, "GET"))
        {
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();

            ScoreData[] dat = JsonConvert.DeserializeObject<ScoreData[]>(request.downloadHandler.text);
            scoreCount = Mathf.Clamp(dat.Length, 0, NUM_SCORES);
            for(int i = 0; i < scoreCount; i++)
            {
                scores[i].LoadFrom(dat[i]);
            }
        }

        OnScoresChanged?.Invoke();
    }

    public IEnumerator PostScoreAsync(string json, string url)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.error != null)
        {
            OnScoreUploadFinished?.Invoke(false);
            Debug.Log("Erro: " + request.error);
        }
        else
        {
            OnScoreUploadFinished?.Invoke(true);
            Debug.Log("All OK");
            Debug.Log("Status Code: " + request.responseCode);
        }
    }

    private string GenerateHash(int score, string name)
    {
        var verifyString = this.secret + this.GameId + score + name;
        return CryptoUtils.Md5Sum(verifyString);
    }
}
