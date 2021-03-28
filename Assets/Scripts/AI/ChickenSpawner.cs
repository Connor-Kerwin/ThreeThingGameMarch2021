using System.Collections;
using UnityEngine;

public class ChickenSpawner : MonoBehaviour 
{
    public Transform[] Spawnpoints;

    public void SpawnChicken()
    {
        var spawn = GetRandomSpawnpoint();
        SpawnChicken(spawn.position, spawn.rotation);
    }

    public void SpawnChicken(int count)
    {
        var spawn = GetRandomSpawnpoint();
        for (int i = 0; i < count; i++)
        {
            SpawnChicken(spawn.position, spawn.rotation);
        }
    }

    public void SpawnChickensRandomly(int count)
    {
        for(int i = 0; i < count; i++)
        {
            SpawnChicken();
        }
    }

    public void SpawnChickensRandomlyDelayed(int count)
    {
        StartCoroutine(SpawnChickensRandomlyDelayedAsync(count, 1.0f));
    }

    private IEnumerator SpawnChickensRandomlyDelayedAsync(int count, float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnChickensRandomly(count);
    }

    private GameObject SpawnChicken(Vector3 position, Quaternion rotation)
    {
        return ChickenSystem.Instance.SpawnChicken(position, rotation);
    }

    private Transform GetRandomSpawnpoint()
    {
        int n = Random.Range(0, Spawnpoints.Length);
        return Spawnpoints[n];
    }
}
