using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public Transform Target;
    public float LerpRate;

    public void SetTarget(Transform target)
    {
        Target = target;
    }

    public void SetLerp(float lerp)
    {
        LerpRate = lerp;
    }

    private void LateUpdate()
    {
        if (Target != null)
        {
            Vector3 cPos = transform.position;
            Quaternion cRot = transform.rotation;

            transform.position = Vector3.Lerp(cPos, Target.position, LerpRate);
            transform.rotation = Quaternion.Lerp(cRot, Target.rotation, LerpRate);
        }
    }
}