using UnityEngine;

public class WorldTile : MonoBehaviour
{
    public MeshFilter mFilter;

    public void Apply(TileData data)
    {
        mFilter.sharedMesh = data.Mesh;
        transform.rotation = data.GetActualRotation();
    }
}
