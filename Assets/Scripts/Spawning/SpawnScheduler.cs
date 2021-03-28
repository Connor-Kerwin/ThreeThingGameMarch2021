using UnityEngine;

public class SpawnScheduler : MonoBehaviour
{
    public ZombieSpawner Spawner;

    public float Interval;
    public int Number;

    private float time;

    private void Update()
    {
        time += Time.deltaTime;
        if(time >= Interval)
        {
            Spawner.SpawnZombies(Number);
            time = 0.0f;
        }
    }
}
