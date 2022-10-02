using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FireballProjectile : Projectile
{
    [SerializeField] private float _moveSpeed = 1000f;
    [SerializeField] private float _curvature = 50f;

    private Rigidbody _rigidbody;
    
    public EnemyFighter Enemy { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(EnemyFighter enemy, Action<Vector3> onTargetReached)
    {
        Enemy = enemy;
        Cast(Enemy.transform.position, onTargetReached);
    }

    public override void Cast(Vector3 target, Action<Vector3> onTargetReached)
    {
        StartCoroutine(Casting(target, onTargetReached));
    }

    private IEnumerator Casting(Vector3 target, Action<Vector3> onTargetReached)
    {
        while (Vector3.Distance(transform.position, target) > 1f)
        {
            Vector3 from = transform.forward;
            Vector3 to = target - transform.position;
            float time = _curvature / Vector3.Distance(target, transform.position);

            transform.forward = Vector3.Slerp(from, to, time);
            _rigidbody.position += transform.forward * _moveSpeed * Time.deltaTime;

            yield return new WaitForFixedUpdate();
        }

        onTargetReached?.Invoke(_rigidbody.position);
        Destroy(gameObject);
    }
}
