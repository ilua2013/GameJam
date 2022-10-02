using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpell : Spell
{
    [SerializeField] private int _healAmount;
    [SerializeField] private HealtPlayer _playerHealth;
    [SerializeField] private ParticleSystem _visualEffectTemplate;

    private void OnValidate()
    {
        if (_playerHealth == null)
            _playerHealth = FindObjectOfType<HealtPlayer>();
    }

    public override void Cast(EnemyFighter target)
    {

    }

    public override void Cast()
    {
        if (IsCooldown == false)
            return;

        _playerHealth.RecoveryHealt(_healAmount);

        var effect = Instantiate(_visualEffectTemplate, SpawnPoint.position, SpawnPoint.rotation, SpawnPoint);
        Destroy(effect.gameObject, effect.main.duration);

        Cooldown();
    }
}
