using UnityEngine;
using UnityEngine.Events;

public class OnStart : MonoBehaviour
{
    public UnityEvent OnStartInvoked;

    private void Start()
    {
        OnStartInvoked.Invoke();
    }
}
