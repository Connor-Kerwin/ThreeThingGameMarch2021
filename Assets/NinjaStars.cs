using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStars : Attack
{
    public float Duration;
    public float speed;
    public GameObject ninjaStarPrefab;
    public override void Invoke(Vector3 sourcePos, Vector3 sourceDir)
    {
        var obj = GameObject.Instantiate(ninjaStarPrefab, new Vector3(sourcePos.x, sourcePos.y + 1f, sourcePos.z), Quaternion.identity);
        obj.transform.forward = sourceDir;
        var dmg = obj.AddComponent<Damage>();
        dmg.DamageAmount = damage;
        dmg.destryOnContact = true;
        dmg.Ignore = this.Ignore;
        obj.GetComponent<Rigidbody>().AddForce(sourceDir * speed);
        GameObject.Destroy(obj, Duration);
    }
}
