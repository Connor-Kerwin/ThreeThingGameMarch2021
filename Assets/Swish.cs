using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swish : Attack
{
    public float SwishDuration;
    public float Swishtance;
    public GameObject swishPefab;

    public override void Invoke(Vector3 sourcePos, Vector3 sourceDir)
    {
        var obj = GameObject.Instantiate(swishPefab, new Vector3(sourcePos.x, sourcePos.y + 0.7f, sourcePos.z), Quaternion.identity);
        obj.transform.forward = sourceDir;
        obj.transform.position = obj.transform.position + (obj.transform.forward * Swishtance);
        var dmg = obj.AddComponent<Damage>();
        dmg.DamageAmount = damage;
        dmg.destryOnContact = false;
        dmg.Ignore = this.Ignore;
        GameObject.Destroy(obj, SwishDuration);
    }
}
