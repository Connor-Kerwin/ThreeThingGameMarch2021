using System.Collections.Generic;
using UnityEngine;

public class ChickenSystem : GameSystem<ChickenSystem>
{
    public GameObject Prefab;

    private List<GameObject> chickens;

    protected override void Awake()
    {
        base.Awake();
        chickens = new List<GameObject>();
    }

    public GameObject SpawnChicken(Vector3 position, Quaternion rotation)
    {
        var inst = GameObject.Instantiate<GameObject>(Prefab);
        chickens.Add(inst);

        inst.transform.position = position;
        inst.transform.rotation = rotation;

        return inst;
    }

    public void DespawnChicken(GameObject instance)
    {
        if(chickens.Remove(instance))
        {
            GameObject.Destroy(instance);
        }
    }

    public void CleanupChickens()
    {
        int num = chickens.Count;
        for (int i = 0; i < num; i++)
        {
            DespawnChicken(chickens[0]);
        }

        chickens.Clear();
    }
}
