using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ICollector
{
    bool TryCollect(Collectable target);
}

public static class CollectableTypes
{
    public const string GOLDEN_CHICK = "GOLDEN_CHICK";
}

public class Collectable : NetworkBehaviour
{
    public string CollectableType;
    public UnityEvent OnCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (!isServer)
        {
            return;
        }

        var collector = other.GetComponent<ICollector>();
        if (collector != null && collector.TryCollect(this))
        {
            OnCollected.Invoke();
            NetworkServer.Destroy(gameObject);
        }
    }
}