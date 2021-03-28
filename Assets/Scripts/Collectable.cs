using Mirror;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public interface ICollector
{
    bool TryCollect(Collectable target);
}

public static class CollectableTypes
{
    public const string EGG = "EGG";
    public const string HEALTH = "HEALTH";
    public const string AMMO = "AMMO";
}

public class Collectable : MonoBehaviour
{
    public string CollectableType;
    public UnityEvent OnCollected;

    private void OnTriggerEnter(Collider other)
    {
        var collector = other.GetComponent<ICollector>();
        if (collector != null && collector.TryCollect(this))
        {
            OnCollected.Invoke();
            CollectableSystem.Instance.DespawnCollectable(this);
        }
    }
}
