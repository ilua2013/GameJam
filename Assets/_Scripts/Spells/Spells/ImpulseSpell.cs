using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ImpulseSpell : Spell
{
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _visualEffectTemplate;
    
    private Collider _impulseArea;
    private List<EnemyFighter> _enemies = new List<EnemyFighter>();

    private void Awake()
    {
        _impulseArea = GetComponent<Collider>();
        _impulseArea.isTrigger = true;
    }

    public override void Cast(EnemyFighter target)
    {
        
    }

    public override void Cast()
    {
        if (IsCooldown == false)
            return;

        foreach (var enemy in _enemies)
        {
            enemy.ApplyDamage(_damage);
            //enemy.
        }

        var effect = Instantiate(_visualEffectTemplate, SpawnPoint.position, SpawnPoint.rotation, SpawnPoint);
        Destroy(effect.gameObject, effect.main.duration);

        Cooldown();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyFighter enemy))
            _enemies.Add(enemy);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out EnemyFighter enemy))
            if (_enemies.Contains(enemy))
                _enemies.Remove(enemy);
    }
}
