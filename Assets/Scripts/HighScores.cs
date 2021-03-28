using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

public class HighScores : MonoBehaviour
{
    public string Secret;
    public string GameId;

    private void Start()
    {
        submitScore(420, "Daniel Craig jr.");
    }

    public void submitScore(int score, string name)
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
        var verifyString = this.Secret + this.GameId + score + name;
        return CryptoUtils.Md5Sum(verifyString);
    }
}