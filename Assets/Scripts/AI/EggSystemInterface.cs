using UnityEngine;

public class EggSystemInterface : GameSystemInterface<EggSystem>
{
    public bool TrySpawnEgg(Vector3 position)
    {
        return Target.TrySpawnEgg(position);
    }

    protected override EggSystem GetTarget()
    {
        return EggSystem.Instance;
    }

    public void ClearEggs()
    {
        Target.ClearEggs();
    }
}
