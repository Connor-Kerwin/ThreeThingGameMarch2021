using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swish : Attack
{
    public GameObject swishObject;
    public override void Invoke(Vector3 sourcePos, Vector3 sourceDir)
    {
        GameObject.Instantiate(swishObject, sourceDir, Quaternion.identity);
    }
}
