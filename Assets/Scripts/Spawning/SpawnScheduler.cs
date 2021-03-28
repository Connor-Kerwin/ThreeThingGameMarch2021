using UnityEngine;

public class SpawnScheduler : MonoBehaviour
{
    public ZombieSpawner Spawner;
    public bool Running;

    public float Interval;
    public int Number;

    private float time;

    private void Update()
    {
        if (!Running)
        {
            return;
        }

        time += Time.deltaTime;
        if(time >= Interval)
        {
            Spawner.SpawnZombies(Number);
            time = 0.0f;
        }
    }

    public void SetRunning(bool state)
    {
        Running = state;
    }
}
