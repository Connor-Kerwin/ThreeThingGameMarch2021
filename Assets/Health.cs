using System;
using UnityEngine;

public interface IHealth
{
    // NOTE: Potentially move health events to interface

    int CurrentHealth { get; }
    int MaxHealth { get; }
    bool IsAlive { get; }
    void Heal(int number);
    bool TakeDamage(int number); // <-- Returns whether death occurred from this damage?
    void SetHealth(int number);
    void SetMaxHealth(int number);
    void Respawn();
}

public class Health : MonoBehaviour, IHealth
{
    [SerializeField]
    protected int currentHealth;
    [SerializeField]
    protected int maxHealth;

    public int CurrentHealth { get { return currentHealth; } private set { currentHealth = value; } }
    public int MaxHealth { get { return maxHealth; } private set { maxHealth = value; } }
    public bool IsAlive { get { return CurrentHealth > 0; } }

    public event Action OnDamaged;
    public event Action OnHealed;
    public event Action OnRespawn;

    public void Heal(int number)
    {
        throw new System.NotImplementedException();
    }

    public void Respawn()
    {
        throw new System.NotImplementedException();
    }

    public bool TakeDamage(int number)
    {
        CurrentHealth -= number;
        return false;
    }

    public void SetHealth(int number)
    {
        throw new System.NotImplementedException();
    }

    public void SetMaxHealth(int number)
    {
        throw new System.NotImplementedException();
    }
}