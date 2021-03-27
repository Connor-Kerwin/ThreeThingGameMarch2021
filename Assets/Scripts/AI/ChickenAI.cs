using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickenAI : MonoBehaviour
{
    public NavMeshAgent Agent;

    private Vector3 destinationGoal;
    private float destinationRate;
    private float time;
    private bool hasPath;

    private void Update()
    {
        time += Time.deltaTime;
    }
}
