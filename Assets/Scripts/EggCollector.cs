using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EggCollector : MonoBehaviour, ICollector
{
    public UnityEvent OnEggCollected;
    public int ScoreForEgg = 10;

    public bool TryCollect(Collectable target)
    {
        if (target.CollectableType == CollectableTypes.EGG)
        {
            var flowSystem = GameFlowSystem.Instance;
            if (flowSystem.State != GameFlowState.Game) // Cannot collect if not in game
            {
                return false;
            }

            // Add score upon collection
            var scoreSystem = ScoreSystem.Instance;
            scoreSystem.AddScore(ScoreForEgg);

            return true;
        }

        return false;
    }
}