using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShieldSpell : Spell
{
    [SerializeField] private int _armor;
    [SerializeField] private int _duration;
    [SerializeField] private ParticleSystem _visualEffectTemplate;

    public event Action<int> ShieldActivated;

    public override void Cast(EnemyFighter target)
    {
        
    }

    public override void Cast()
    {
        if (IsCooldown == false)
            return;

        var effect = Instantiate(_visualEffectTemplate, SpawnPoint.position, SpawnPoint.rotation, SpawnPoint);
        Destroy(effect.gameObject, _duration);

        ShieldActivated?.Invoke(_duration);

        Cooldown();
    }
}
