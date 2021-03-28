using UnityEngine;

public class ChickenSystemInterface : GameSystemInterface<ChickenSystem>
{
    protected override ChickenSystem GetTarget()
    {
        return ChickenSystem.Instance;
    }

    public void SpawnChicken(Vector3 position)
    {
        Target.SpawnChicken(position, Quaternion.identity);
    }

    public void DespawnChicken(GameObject instance)
    {
        Target.DespawnChicken(instance);
    }

    public void CleanupChickens()
    {
        Target.CleanupChickens();
    }
}
