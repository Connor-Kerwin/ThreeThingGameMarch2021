using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float DamageAmount;
    public bool destryOnContact;

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<EnemyAI>();
        if (enemy)
        {
            //TODO DAMAGE THE ENEMY
            if (destryOnContact)
                GameObject.Destroy(this);
        }
    }
}
