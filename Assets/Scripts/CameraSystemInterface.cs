public class CameraSystemInterface : GameSystemInterface<CameraSystem>
{
    protected override CameraSystem GetTarget()
    {
        return CameraSystem.Instance;
    }
}