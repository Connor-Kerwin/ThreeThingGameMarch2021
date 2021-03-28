using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int DamageAmount;
    public bool destryOnContact;
    public GameObject Ignore;

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Health>();
        if (enemy & other.gameObject != Ignore)
        {
            enemy.TakeDamage(DamageAmount);
            if (destryOnContact)
                GameObject.Destroy(this.gameObject);
        }
    }
}
