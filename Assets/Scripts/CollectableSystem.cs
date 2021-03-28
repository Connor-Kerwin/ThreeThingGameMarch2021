using System;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSystem : GameSystem<CollectableSystem>
{
    public Collectable[] Prefabs;

    private List<Collectable> active;

    public event Action<Collectable> OnSpawned;
    public event Action<Collectable> OnDespawned;

    protected override void Awake()
    {
        base.Awake();
        active = new List<Collectable>();
    }

    public Collectable SpawnCollectable(string identifier)
    {
        foreach(var item in Prefabs)
        {
            if(item.CollectableType == identifier)
            {
                var inst = GameObject.Instantiate<Collectable>(item);
                active.Add(inst);

                OnSpawned?.Invoke(inst);
                return inst;
            }
        }

        return null;
    }

    public void DespawnCollectable(Collectable target)
    {
        if(target == null)
        {
            return;
        }

        if (active.Remove(target))
        {
            OnDespawned?.Invoke(target);
            GameObject.Destroy(target.gameObject);
        }
    }
}
