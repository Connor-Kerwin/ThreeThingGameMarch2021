using System;
using UnityEngine;

public class PlayerSystem : GameSystem<PlayerSystem>
{
    private GamePlayer player;

    public GamePlayer PlayerPrefab;

    public Transform[] PlayerSpawns;

    public event Action<GamePlayer> OnPlayerSpawned;
    public event Action<GamePlayer> OnPlayerDespawned;

    public void SpawnPlayer()
    {
        if (player != null)
        {
            Debug.LogError("Cannot spawn multiple players");
            return;
        }

        player = GameObject.Instantiate<GamePlayer>(PlayerPrefab);

        Pose pose = GetSpawnPose();
        player.Spawn(pose);
        OnPlayerSpawned?.Invoke(player);
    }

    public void DespawnPlayer()
    {
        if(player == null)
        {
            return;
        }

        player.Despawn();
        OnPlayerDespawned?.Invoke(player);
        GameObject.Destroy(player);
    }

    private Pose GetSpawnPose()
    {
        Transform spawnPoint = PlayerSpawns[0];
        return new Pose(spawnPoint.position, spawnPoint.rotation);
    }
}