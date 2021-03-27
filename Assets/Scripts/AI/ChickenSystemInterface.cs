using UnityEngine;

public class ChickenSystemInterface : GameSystemInterface<ChickenSystem>
{
    public bool TrySpawnEgg(Vector3 position)
    {
        return Target.TrySpawnEgg(position);
    }

    protected override ChickenSystem GetTarget()
    {
        return ChickenSystem.Instance;
    }
}
