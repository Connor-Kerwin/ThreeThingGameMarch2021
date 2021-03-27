using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public Transform Target;

    public void SetTarget(Transform target)
    {
        Target = target;
    }

    private void LateUpdate()
    {
        if (Target != null)
        {
            transform.position = Target.position;
            transform.rotation = Target.rotation;
        }
    }
}