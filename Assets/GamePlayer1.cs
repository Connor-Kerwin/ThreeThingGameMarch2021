using UnityEngine;
using UnityEngine.Events;

public class GamePlayer : MonoBehaviour
{
    public UnityEvent OnSpawn;
    public UnityEvent OnDespawn;

    public void Spawn(Pose pose)
    {
        transform.SetPositionAndRotation(pose.position, pose.rotation);

        GetComponent<Rigidbody>().velocity = Vector3.zero;

        OnSpawn.Invoke();
    }

    public void Despawn()
    {
        OnDespawn.Invoke();
    }
}
