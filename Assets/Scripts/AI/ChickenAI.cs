using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ChickenAI : MonoBehaviour
{
    public NavMeshAgent Agent;
    public ChickenSystemInterface ChickenInterface;
    public PlayerSystemInterface PlayerInterface;

    public float DistanceThreshold = 0.1f;
    public float PathRate = 1.0f;
    public float RunThreshold = 5.0f;
    public float RunVariation = 25.0f;
    public float NextPathDistance = 5.0f;

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
        ChickenInterface.TrySpawnEgg(transform.position);
    }

    private void GenerateNewPath()
    {
        Vector3 destination = transform.position;

        var player = PlayerInterface.Target.Player;
        if(player != null)
        {
            Vector3 pPos = player.transform.position;
            Vector3 cPos = transform.position;

            float dist = Vector2.Distance(pPos, cPos);
            if(dist < RunThreshold) // RUN AWAY
            {
                Vector3 dir = cPos - pPos;
                var offsetRot = Quaternion.AngleAxis(Random.Range(-RunVariation, RunVariation), Vector2.up);
                dir = (offsetRot * dir).normalized;
                destination += dir * NextPathDistance;
                destination.y = transform.position.y; // Flatten

                Debug.DrawLine(transform.position, destination, Color.red, 10.0f);

                destinationGoal = destination;
                hasPath = Agent.SetDestination(destination);
                return;
            }
        }

        float rand = Random.Range(0.0f, 360.0f);
        destination += PointOnCircle(rand, NextPathDistance);
        destinationGoal = destination;

        hasPath = Agent.SetDestination(destination);
    }

    private Vector3 PointOnCircle(float angle, float distance)
    {
        return new Vector3(distance * Mathf.Sin(angle), 0.0f, distance * Mathf.Cos(angle));
    }
}
