using System.Collections.Generic;
using UnityEngine;

public class ChickenSystem : GameSystem<ChickenSystem>
{
    public int EggLimit = 128;

    private List<Collectable> eggs;
    private CollectableSystem collectableSystem;

    protected override void Awake()
    {
        base.Awake();
        eggs = new List<Collectable>();
    }

    private void Start()
    {
        collectableSystem = CollectableSystem.Instance;
        collectableSystem.OnSpawned += OnEggSpawned;
        collectableSystem.OnDespawned += OnEggDespawned;
    }

    private void OnEggDespawned(Collectable obj)
    {
        eggs.Remove(obj);
    }

    private void OnEggSpawned(Collectable obj)
    {
        eggs.Add(obj);
    }

    public bool TrySpawnEgg(Vector3 position)
    {
        if(eggs.Count < EggLimit)
        {
            var inst = collectableSystem.SpawnCollectable(CollectableTypes.EGG);
            inst.transform.position = position;
        }

        return false;
    }

    public void ClearEggs()
    {
        int num = eggs.Count;
        for(int i = 0; i < num; i++)
        {
            var egg = eggs[0];
            collectableSystem.DespawnCollectable(egg);
        }

        eggs.Clear();
    }
}
