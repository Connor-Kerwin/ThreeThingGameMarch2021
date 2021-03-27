using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ChickenAI : MonoBehaviour
{
    public NavMeshAgent Agent;
    public ChickenSystemInterface Interface;

    public float DistanceThreshold = 0.1f;
    public float PathRate = 1.0f;

    private Vector3 destinationGoal;
    private float time;
    private bool hasPath;

    private void Update()
    {
        time += Time.deltaTime;

        if (hasPath)
        {
            float dist = Vector3.Distance(transform.position, destinationGoal);
            if(dist <= DistanceThreshold)
            {
                LayEgg();
                hasPath = false;
            }
        }
        else
        {
            if(time >= PathRate)
            {
                GenerateNewPath();
                time = 0.0f;
            }
        }
    }

    private void LayEgg()
    {
        Interface.TrySpawnEgg(transform.position);
    }

    private void GenerateNewPath()
    {
        Vector3 destination = transform.position;

        float rand = Random.Range(0.0f, 360.0f);
        destination += PointOnCircle(rand, 5.0f);
        destinationGoal = destination;

        hasPath = Agent.SetDestination(destination);
    }

    private Vector3 PointOnCircle(float angle, float distance)
    {
        return new Vector3(distance * Mathf.Sin(angle), 0.0f, distance * Mathf.Cos(angle));
    }
}
