using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum GameTeam
{
    Red,
    Blue
}

public class ScoreSystem : GameSystem<ScoreSystem>
{
    public delegate void TeamEvent(GameTeam team);

    public ScoreHandler Handler;

    public event TeamEvent OnTeamWin;

    public void SetHandler(ScoreHandler handler)
    {
        Handler = handler;
    }
}

public class GameSessionSystem : GameSystem<GameSessionSystem>
{
    public bool InSession { get; private set; }



    private void Start()
    {
        var netSys = NetworkSystem.Instance;
    }

    public void StartSession()
    {
        InSession = true;
    }

    public void EndSession()
    {
        InSession = false;
    }
}