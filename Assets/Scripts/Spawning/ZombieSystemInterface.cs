public class ZombieSystemInterface : GameSystemInterface<ZombieSystem>
{
    protected override ZombieSystem GetTarget()
    {
        return ZombieSystem.Instance;
    }
}