using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class ScoreSystem : GameSystem<ScoreSystem>
{
    public string GameId;

    public int Score { get; private set; }

    private string secret;

    protected override void Awake()
    {
        secret = HighscoreSecret.Secret;

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

    public async Task SubmitScoreToRemote(string username)
    {
        await Task.Delay(1000);
    }

    public async Task FetchScores()
    {
        await Task.Delay(1000);
    }




    public void SubmitScore(int score, string name)
    {
        var hash = this.generateHash(score, name);
        var json = $"{{\"Hash\":\"{hash}\",\"UserName\": \"{name}\", \"Score\": \"{score}\", \"GameId\":\"{this.GameId}\"}}";

        StartCoroutine(POST(json, "https://chickensimulator.com/api/submit"));
    }

    public IEnumerator POST(string json, string url)
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


    private string generateHash(int score, string name)
    {
        var verifyString = this.secret + this.GameId + score + name;
        return CryptoUtils.Md5Sum(verifyString);
    }

}