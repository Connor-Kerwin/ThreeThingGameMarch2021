using UnityEngine;

public class WorldLookup : MonoBehaviour, IWorldLookup
{
    private TileData[] lookup;

    public Mesh wallMesh;
    public Mesh cornerMesh;
    public Mesh doubleMesh;
    public Mesh uMesh;
    public Mesh squareMesh;
    public Mesh emptyMesh;

    private void Awake()
    {
        /*
         Ignore -->[0000]0000
         0000 = Left,Bottom,Right,Top
         Top = 1
         Right = 2
         Bottom = 4
         Left = 8

         --- Rotation ---
         Top = 0
         Right = 1
         Bottom = 2
         Left = 3
         */

        lookup = new TileData[16];
        lookup[0] = new TileData(emptyMesh, 0);
        lookup[15] = new TileData(squareMesh, 0);

        // Single wall
        lookup[1] = new TileData(wallMesh, 2);
        lookup[2] = new TileData(wallMesh, 3);
        lookup[4] = new TileData(wallMesh, 0);
        lookup[8] = new TileData(wallMesh, 1);

        // Double wall
        lookup[5] = new TileData(doubleMesh, 0);
        lookup[10] = new TileData(doubleMesh, 1);

        // U wall
        lookup[11] = new TileData(uMesh, 0);
        lookup[7] = new TileData(uMesh, 1);
        lookup[14] = new TileData(uMesh, 2);
        lookup[13] = new TileData(uMesh, 3);

        // Corner wall
        lookup[3] = new TileData(cornerMesh, 2);
        lookup[6] = new TileData(cornerMesh, 3);
        lookup[12] = new TileData(cornerMesh, 0);
        lookup[9] = new TileData(cornerMesh, 1);
    }

    public TileData GetTileData(byte[] neighbors)
    {
        /*
         Input order:
         0 = top
         1 = right
         2 = bottom
         3 = left

         Input value:
         0 = empty
         1 = full
         */

        byte sum = 0;
        sum |= (byte)(neighbors[0] << 0);
        sum |= (byte)(neighbors[1] << 1);
        sum |= (byte)(neighbors[2] << 2);
        sum |= (byte)(neighbors[3] << 3);

        return lookup[sum];
    }
}
