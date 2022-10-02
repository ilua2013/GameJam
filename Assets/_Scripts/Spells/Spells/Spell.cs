using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    [SerializeField] private int _cooldownTime;
    [SerializeField] private Transform _spawnPoint;

    private bool _isCooldown = true;

    public int CooldownTime => _cooldownTime;
    public bool IsCooldown => _isCooldown;
    public Transform SpawnPoint => _spawnPoint;

    public event Action<int> StartCooldown;

    public abstract void Cast(EnemyFighter target);
    public abstract void Cast();

    public void Cooldown()
    {
        _isCooldown = false;

        StartCoroutine(WaitForCooldown(_cooldownTime));
        StartCooldown?.Invoke(_cooldownTime);
    }

    private IEnumerator WaitForCooldown(int time)
    {
        yield return new WaitForSeconds(time);

        _isCooldown = true;
    }
} 
