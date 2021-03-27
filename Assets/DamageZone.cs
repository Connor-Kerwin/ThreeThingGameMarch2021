using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int DamageValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        IHealth health = other.GetComponent<IHealth>();
        if(health != null)
        {
            health.TakeDamage(DamageValue);
        }
    }
}
