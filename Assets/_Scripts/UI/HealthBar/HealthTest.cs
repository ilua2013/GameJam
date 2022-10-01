using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTest : MonoBehaviour, IDamageable
{
    public int MaxHealth { get; private set; } = 100;
    public int Health { get; private set; } = 100;

    public event Action<int> Damaged;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ApplyDamage(30);
        }
    }

    private void ApplyDamage(int damage)
    {
        int received = Mathf.Clamp(Health - damage, 0, MaxHealth);

        Health = received;
        Damaged?.Invoke(Health);
    }
}
