using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int DamageAmount;
    public bool destryOnContact;

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Health>();
        if (enemy)
        {
            enemy.TakeDamage(DamageAmount);
            if (destryOnContact)
                GameObject.Destroy(this.gameObject);
        }
    }
}
