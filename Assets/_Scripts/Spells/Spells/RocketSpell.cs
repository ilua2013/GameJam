using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpell : Spell
{
    [SerializeField] private int _damage;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private FireballProjectile _projectile;
    [SerializeField] private ParticleSystem _explosionEffect;

    public override void Cast(EnemyFighter target)
    {

    }

    public override void Cast()
    {
        if (IsCooldown == false)
            return;

        var projectile = Instantiate(_projectile, SpawnPoint.position, SpawnPoint.rotation);
        projectile.Cast(_targetPoint.position, OnReached);

        Cooldown();
    }

    private void OnReached(Vector3 target)
    {
        var effect = Instantiate(_explosionEffect, target, _targetPoint.rotation);
        Destroy(effect.gameObject, effect.main.duration);

        foreach (var hit in Physics.SphereCastAll(new Ray(target, target), 5f))
            if (hit.collider.TryGetComponent(out EnemyFighter enemyFighter))
                enemyFighter.ApplyDamage(_damage);
    }
}
