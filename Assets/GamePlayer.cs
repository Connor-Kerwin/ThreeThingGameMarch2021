using System;
using UnityEngine;

[RequireComponent(typeof(PlayerSystemInterface), typeof(Health))]
public class GamePlayer : MonoBehaviour
{
    public PlayerSystemInterface Interface;
    public Health Health;

    private void Awake()
    {
        Health.OnDamaged += OnPlayerDamaged;
        Health.OnHealed += OnPlayerHealed;
        Health.OnRespawn += OnPlayerRespawn;
    }

    public IHealth GetHealth()
    {
        return Health;
    }

    private void OnPlayerRespawn()
    {
        throw new NotImplementedException();
    }

    private void OnPlayerHealed()
    {
        throw new NotImplementedException();
    }

    private void OnPlayerDamaged()
    {
        throw new NotImplementedException();
    }

    private void Start()
    {
        Interface.Target.SetPlayer(this);
    }

    private void Reset()
    {
        Interface = GetComponent<PlayerSystemInterface>();
    }
}