using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : Spell
{
    [SerializeField] private int _damage;
    [SerializeField] private FireballProjectile _projectile;

    public FireballProjectile Projectile => _projectile;
    public int Damage => _damage;

    public override void Cast(EnemyFighter target)
    {
        if (target.gameObject.activeInHierarchy == false)
            return;
        if (IsCooldown == false)
            return;

        var projectile = Instantiate(Projectile, SpawnPoint.position, SpawnPoint.rotation);
        projectile.Init(target, (pos) => target.ApplyDamage(Damage));

        Cooldown();
    }

    public override void Cast()
    {
        
    }
}
