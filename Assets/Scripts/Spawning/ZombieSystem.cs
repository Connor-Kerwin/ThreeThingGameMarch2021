using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSystem : GameSystem<ZombieSystem>
{
    public Zombie Prefab;
    public int MaxZombies = 128;

    private List<Zombie> zombies;

    protected override void Awake()
    {
        base.Awake();
        zombies = new List<Zombie>();
    }

    public Zombie Spawn(Vector3 position, Quaternion orientation)
    {
        if(zombies.Count >= MaxZombies)
        {
            return null;
        }

        Zombie instance = GameObject.Instantiate<Zombie>(Prefab);
        instance.transform.position = position;
        instance.transform.rotation = orientation;

        zombies.Add(instance);
        return instance;
    }

    public void Despawn(Zombie instance)
    {
        if (zombies.Remove(instance))
        {
            GameObject.Destroy(instance.gameObject);
        }
    }

    public void ClearZombies()
    {
        foreach (var item in zombies)
        {
            if (item == null)
            {
                continue;
            }

            GameObject.Destroy(item.gameObject);
        }

        zombies.Clear();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Spawn(Vector3.zero, Quaternion.identity);
        }
    }
}
