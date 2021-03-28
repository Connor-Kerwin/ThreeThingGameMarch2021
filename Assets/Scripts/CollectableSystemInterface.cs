public class CollectableSystemInterface : GameSystemInterface<CollectableSystem>
{
    public void SpawnCollectable(string identifier)
    {
        _ = Target.SpawnCollectable(identifier);
    }

    public void DespawnCollectable(Collectable target)
    {
        Target.DespawnCollectable(target);
    }

    protected override CollectableSystem GetTarget()
    {
        return CollectableSystem.Instance;
    }
}
