using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PlayerFighter : MonoBehaviour
{
    [SerializeField] private HealtPlayer _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _distanceToAttack;
    [SerializeField] private float _delayBetweenAttack;
    [SerializeField] private ParticleSystem _particleSystem;

    private Coroutine _fight = null;
    private EnemyFighter _currentFighter = null;

    public event UnityAction<EnemyFighter> BattleBegun;
    public event Action Attacked;
    public event Action Killed;
    public event Action<EnemyFighter> Killed_get;

    public float DistanceAttack => _distanceToAttack;
    public bool IsFight => _currentFighter != null;

    public EnemyFighter CurrentFighter => _currentFighter;

    private void OnEnable()
    {
        _particleSystem.Stop();
    }

    public void StartFight(EnemyFighter enemyFighter)
    {
        _currentFighter = enemyFighter;

        if (_fight == null)
            _fight = StartCoroutine(Fight());

        BattleBegun?.Invoke(enemyFighter);
    }

    public void StopFight()
    {
        _fight = null;
        _currentFighter = null;
    }

    public IEnumerator Fight()
    {
        float time = 0;
        while (_currentFighter != null)
        {
            time += Time.deltaTime;

            if (time >= _delayBetweenAttack)
            {
                TryAttack(_currentFighter);
                time = 0;
            }

            yield return null;
        }

        _fight = null;
        _currentFighter = null;
    }

    public void SetDamage(int damage)
    {
        if (damage < 0)
            Debug.LogError("Damage < 0");

        _damage = damage;
    }

    public void TryAttack(EnemyFighter enemyFighter)
    {
        if (Vector3.Distance(transform.position, enemyFighter.transform.position) > _distanceToAttack)
            return;

        enemyFighter.ApplyDamage(_damage, () => OnKill(enemyFighter));
        Attacked?.Invoke();
    }

    public void ApplyDamage(int damage)
    {
        _particleSystem.Play();
        _health.TakeDamage(damage);
    }

    private void OnKill(EnemyFighter enemyFighter)
    {
        if (_currentFighter == enemyFighter)
            _currentFighter = null;

        Killed?.Invoke();
        Killed_get?.Invoke(enemyFighter);
    }
}
