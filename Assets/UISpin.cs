using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpin : MonoBehaviour
{
    public float SpinRate = 5.0f;
    public float SpinMagnitude = 5.0f;
    public float BounceRate = 2.0f;
    public float BounceMagnitude = 2.0f;

    private void Update()
    {
        float sin = Mathf.Sin(Time.time * SpinRate) * SpinMagnitude;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, sin);
        transform.position += new Vector3(0.0f, Mathf.Cos(Time.time * BounceRate) * BounceMagnitude, 0.0f);
    }
}
