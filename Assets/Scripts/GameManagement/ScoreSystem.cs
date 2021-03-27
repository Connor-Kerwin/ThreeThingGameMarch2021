using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : GameSystem<ScoreSystem>
{
    public ScoreHandler Handler;

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