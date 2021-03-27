using UnityEngine;

public class CameraSystemInterface : GameSystemInterface<CameraSystem>
{
    protected override CameraSystem GetTarget()
    {
        return CameraSystem.Instance;
    }

    public void SetCameraTarget(Transform target)
    {
        Target.Camera.SetTarget(target);
    }

    public void SetCameraLerp(float lerpRate)
    {
        Target.Camera.SetLerp(lerpRate);
    }
}