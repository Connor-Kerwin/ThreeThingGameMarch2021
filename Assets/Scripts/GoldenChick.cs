using UnityEngine;

[RequireComponent(typeof(Collectable))]
public class GoldenChick : MonoBehaviour
{
    [SerializeField]
    protected Collectable collectable;

    private void Reset()
    {
        collectable = GetComponent<Collectable>();
        collectable.CollectableType = CollectableTypes.EGG;
    }

    private void Awake()
    {
        collectable.OnCollected.AddListener(OnCollected);
    }

    private void OnCollected()
    {
        Debug.Log("Golden chick collected!");
    }
}