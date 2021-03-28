using System.Collections.Generic;
using UnityEngine;

public class ChickenSystem : GameSystem<ChickenSystem>
{
    // TODO: Handle despawning eggs + remove ref...

    public int EggLimit = 128;
    public Egg EggPrefab;

    private List<Egg> eggs;

    protected override void Awake()
    {
        base.Awake();
        eggs = new List<Egg>();
    }

    public bool TrySpawnEgg(Vector3 position)
    {
        if(eggs.Count < EggLimit)
        {
            Egg instance = GameObject.Instantiate<Egg>(EggPrefab);
            eggs.Add(instance);

            instance.transform.position = position;
        }

        return false;
    }

    public void Despawn(Egg egg)
    {

    }

    public void ClearEggs()
    {
        foreach(var item in eggs)
        {
            if(item == null)
            {
                continue;
            }

            GameObject.Destroy(item.gameObject);
        }

        eggs.Clear();
    }
}
