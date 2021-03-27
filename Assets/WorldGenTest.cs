using UnityEngine;

public class WorldGenTest : MonoBehaviour
{
    public WorldLookup Lookup;
    public WorldTile TilePrefab;

    WorldGenerator generator;

    private void Start()
    {
        byte[,] data = new byte[10, 10];
        data[4, 4] = 1;
        data[5, 4] = 1;
        data[6, 4] = 1;
        data[7, 4] = 1;
        data[7, 5] = 1;
        data[6, 5] = 1;

        generator = new WorldGenerator(TilePrefab);
        generator.Generate(data, Lookup);
    }
}
