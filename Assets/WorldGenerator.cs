using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorldLookup
{
    TileData GetTileData(byte[] neighbors);
}

public struct TileData
{
    public Mesh Mesh;
    public byte Rotation;

    public TileData(Mesh mesh, byte rotation)
    {
        Mesh = mesh;
        Rotation = rotation;
    }

    public Quaternion GetActualRotation()
    {
        switch (Rotation)
        {
            case 0:
                return Quaternion.Euler(0, 0, 0);
            case 1:
                return Quaternion.Euler(0, 90, 0);
            case 2:
                return Quaternion.Euler(0, 180, 0);
            case 3:
                return Quaternion.Euler(0, 270, 0);
            default:
                return Quaternion.identity;
        }
    }
}

public class WorldGenerator
{
    private List<WorldTile> tiles;
    private WorldTile prefab;

    public WorldGenerator(WorldTile prefab)
    {
        tiles = new List<WorldTile>();
        this.prefab = prefab;
    }

    public void Generate(byte[,] worldData, IWorldLookup lookup)
    {
        foreach (var item in tiles)
        {
            GameObject.Destroy(item.gameObject);
        }

        tiles.Clear();

        int width = worldData.GetLength(0);
        int height = worldData.GetLength(1);

        byte[] neighbors = new byte[4];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                /*
                  Neighbor order:
                  0 = top
                  1 = right
                  2 = bottom
                  3 = left
                 */

                if (j >= height - 1)
                {
                    neighbors[0] = 1;
                }
                else
                {
                    neighbors[0] = worldData[i, j + 1];
                }

                if (j == 0)
                {
                    neighbors[2] = 1;
                }
                else
                {
                    neighbors[2] = worldData[i, j - 1];
                }

                if (i >= width - 1)
                {
                    neighbors[1] = 1;
                }
                else
                {
                    neighbors[1] = worldData[i + 1, j];
                }

                if (i == 0)
                {
                    neighbors[3] = 1;
                }
                else
                {
                    neighbors[3] = worldData[i - 1, j];
                }


                TileData tile = lookup.GetTileData(neighbors);

                var instance = GameObject.Instantiate<WorldTile>(prefab);
                instance.name = $"World Tile [{i},{j}]";

                instance.Apply(tile);
                instance.transform.position = new Vector3(i* 4.0f, 0, j * 4.0f);
            }
        }
    }
}
