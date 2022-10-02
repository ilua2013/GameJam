using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : MonoBehaviour, IPushable
{
    [SerializeField] private HealthEnemy _health;
    [SerializeField] private EnemyMover _enemy;
    [SerializeField] private ColliderEnemy _collider;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private int _damage;
    [SerializeField] private float _distanceToAttack;
    [SerializeField] private float _delayBetweenAttack;

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
        _enemy.MoveTo(enemyFighter.transform.position);
        print("StartFight");
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
        print("111");
        while (_currentFighter != null)
        {
            time += Time.deltaTime;
            print("222");

            if (time >= _delayBetweenAttack)
            {
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
            return;

        enemyFighter.ApplyDamage(_damage);
    }

    public void ApplyDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    public void Push(Vector3 direction)
    {
        _rigidbody.AddForce(direction);
    }
}
