using System.Collections.Generic;
using UnityEngine;

public class ChickenSystem : GameSystem<ChickenSystem>
{
    public int EggLimit = 128;
    public GameObject EggPrefab;

    private List<GameObject> eggs;

    protected override void Awake()
    {
        base.Awake();
        eggs = new List<GameObject>();
    }

    public bool TrySpawnEgg(Vector3 position)
    {
        if(eggs.Count < EggLimit)
        {
            GameObject instance = GameObject.Instantiate<GameObject>(EggPrefab);
            eggs.Add(instance);

            instance.transform.position = position;
        }

        return false;
    }
}
