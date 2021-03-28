using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float SpeedupScale;
    private NavMeshAgent navMeshAgent;
    private void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (navMeshAgent)
        {
            navMeshAgent.speed += SpeedupScale * Time.deltaTime;
        }
    }
}
