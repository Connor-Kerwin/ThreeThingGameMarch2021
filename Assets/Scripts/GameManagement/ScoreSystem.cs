using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

[System.Serializable]
public class ScoreData
{
    public string UserName;
    public int Score;
}

public class HighscoreSystem : GameSystem<HighscoreSystem>
{
    private string secret;
    private ScoreData[] scores;

    public string GameId;

    protected override void Awake()
    {
        base.Awake();

        secret = HighscoreSecret.Secret;
        scores = new ScoreData[10];
    }

    public void RefreshScores()
    {
        StartCoroutine(GetScoresAsync());
    }

    public void SubmitScore(int score, string name)
    {
        StartCoroutine(SubmitScoreAsync(score, name));
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

            int t1 = 0;
        }
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
            Debug.Log("Erro: " + request.error);
        }
        else
        {
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

public class ScoreSystem : GameSystem<ScoreSystem>
{
    public string GameId;

    public int Score { get; private set; }

    private string secret;

    protected override void Awake()
    {
        secret = HighscoreSecret.Secret;

        base.Awake();
        StartCoroutine(GetScoresAsync());
    }

    public void ResetScore()
    {
        Score = 0;
    }

    public void AddScore(int score)
    {
        Score += score;
    }

    public IEnumerator SubmitScoreAsync(int score, string name)
    {
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

            int t1 = 0;
        }
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
            Debug.Log("Erro: " + request.error);
        }
        else
        {
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