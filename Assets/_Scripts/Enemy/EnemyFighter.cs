using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyFighter : MonoBehaviour, IPushable
{
    [SerializeField] private HealthEnemy _health;
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private ColliderEnemy _collider;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private int _damage;
    [SerializeField] private float _distanceToAttack;
    [SerializeField] private float _delayBetweenAttack;
    [SerializeField] private Animator _animator;

    private Coroutine _fight;
    private PlayerFighter _currentFighter;

    public float DistanceAttack => _distanceToAttack;

    public Rigidbody Rigidbody => _rigidbody;

    private void OnEnable()
    {
        _collider.ViewPlayer += StartFight;
    }

    private void OnDisable()
    {
        _collider.ViewPlayer -= StartFight;
    }

    public void StartFight(PlayerFighter enemyFighter)
    {
        _currentFighter = enemyFighter;

        if (_fight == null)
            _fight = StartCoroutine(Fight());
    }

    public void StopFight()
    {
        _fight = null;
        _currentFighter = null;
    }

    public IEnumerator Fight()
    {
        float time = _delayBetweenAttack;

        while (_currentFighter != null)
        {
            _mover.MoveTo(_currentFighter.transform.position);

            time += Time.deltaTime;

            if (time >= _delayBetweenAttack)
            {
                _animator.SetBool("isFight", true);
                TryAttack(_currentFighter);
                time = 0;
            }

            yield return null;
        }

        _currentFighter = null;
        _fight = null;
    }

    public void SetDamage(int damage)
    {
        if (damage < 0)
            Debug.LogError("Damage < 0");

        _damage = damage;
    }

    public void TryAttack(PlayerFighter enemyFighter)
    {
        if (Vector3.Distance(transform.position, enemyFighter.transform.position) > _distanceToAttack)
        {
            _animator.SetBool("isFight", false);
            return;
        }
        _animator.SetBool("isFight", true);
        enemyFighter.ApplyDamage(_damage);
    }

    public void ApplyDamage(int damage, Action onKill = null)
    {
        if(_health.Health > 0)
        _health.TakeDamage(damage, onKill);
    }

    public void Push(Vector3 direction, int damage)
    {
        Debug.Log("Push");
        ApplyDamage(damage);
        _rigidbody.AddForce(direction);
    }
}
