using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public Transform[] Spawnpoints;

    public void SpawnZombie()
    {
        var spawn = GetRandomSpawnpoint();
        SpawnZombie(spawn.position, spawn.rotation);
    }

    public void SpawnZombies(int count)
    {
        var spawn = GetRandomSpawnpoint();
        for(int i = 0; i < count; i++)
        {
            SpawnZombie(spawn.position, spawn.rotation);
        }
    }

    private Zombie SpawnZombie(Vector3 position, Quaternion orientation)
    {
        return ZombieSystem.Instance.Spawn(position, orientation);
    }

    private Transform GetRandomSpawnpoint()
    {
        int n = Random.Range(0, Spawnpoints.Length);
        return Spawnpoints[n];
    }
}
