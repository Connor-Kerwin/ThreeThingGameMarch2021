using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public Transform Target;
    public float LerpRate;

    public Vector3 Offset;
    public Vector3 RotationalOffset;

    public void SetTarget(Transform target)
    {
        Target = target;
    }

    public void SetLerp(float lerp)
    {
        LerpRate = lerp;
    }

    public void SetCameraOffset(Vector3 offset)
    {
        Offset = offset;
    }

    public void SetCameraRotationalOffset(Vector3 rotationalOffset)
    {
        RotationalOffset = rotationalOffset;
    }

    private void LateUpdate()
    {
        if (Target != null)
        {
            Vector3 cPos = transform.position;
            Quaternion cRot = transform.rotation;

            Vector3 tPos = Target.position;
            Quaternion tRot = Target.rotation;

            tPos += Offset;
            tRot = Quaternion.Euler(RotationalOffset);

            transform.position = Vector3.Lerp(cPos, tPos, LerpRate);
            transform.rotation = Quaternion.Lerp(cRot, tRot, LerpRate);
        }
    }
}