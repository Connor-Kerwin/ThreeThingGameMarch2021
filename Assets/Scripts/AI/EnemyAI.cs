using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent Agent;
    public PlayerSystemInterface PlayerInterface;
    public float NavRecalculationInterval;

    private Transform target;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInterface.Target.OnPlayerSpawned += OnPlayerSpawned;
        PlayerInterface.Target.OnPlayerDespawned += OnPlayerDespawned;

        var curPlayer = PlayerInterface.Target.Player;
        if(curPlayer != null)
        {
            target = curPlayer.transform;
        }
    }

    private void OnPlayerDespawned(GamePlayer obj)
    {

    }

    private void OnPlayerSpawned(GamePlayer obj)
    {
        target = obj.transform;
        RecalculatePath();
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (target == null)
        {
            return;
        }

        if(time >= NavRecalculationInterval)
        {
            RecalculatePath();
            time = 0.0f;
        }
    }

    private void RecalculatePath()
    {
        if (target != null)
        {
            Agent.SetDestination(target.position);
        }
    }
}
