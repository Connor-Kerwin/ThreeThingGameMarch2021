public class ZombieSystemInterface : GameSystemInterface<ZombieSystem>
{
    public void ClearZombies()
    {
        Target.ClearZombies();
    }

    protected override ZombieSystem GetTarget()
    {
        return ZombieSystem.Instance;
    }
}