using System;

public class PlayerSystem : GameSystem<PlayerSystem>
{
    public GamePlayer Player { get; private set; }

    public event Action<GamePlayer> OnPlayerChanged;

    public void SetPlayer(GamePlayer player)
    {
        Player = player;
    }
}