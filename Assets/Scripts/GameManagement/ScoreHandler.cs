using Mirror;

public class ScoreHandler : NetworkBehaviour
{
    [SyncVar]
    public int RedScore;
    [SyncVar]
    public int BlueScore;

    private void Start()
    {
        ScoreSystem.Instance.SetHandler(this);
    }
}