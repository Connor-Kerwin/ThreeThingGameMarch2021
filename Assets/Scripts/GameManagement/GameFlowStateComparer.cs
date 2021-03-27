using UnityEngine;
using UnityEngine.Events;

public class GameFlowStateComparer : MonoBehaviour
{
    public GameFlowState TargetState;

    public UnityEvent OnStateMatch;
    public UnityEvent OnStateNotMatch;

    public void Compare(GameFlowState state)
    {
        if (state == TargetState)
        {
            OnStateMatch?.Invoke();
        }
        else
        {
            OnStateNotMatch?.Invoke();
        }
    }
}