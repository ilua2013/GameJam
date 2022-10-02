using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ImpulseSpell : Spell
{
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _visualEffectTemplate;
    
    private Collider _impulseArea;
    private List<IPushable> _enemies = new List<IPushable>();

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
            Vector3 direction = (enemy.Rigidbody.position - transform.position) / 2 + Vector3.up * 3;
            enemy.Push(direction * 150f, _damage);
        }

        var effect = Instantiate(_visualEffectTemplate, SpawnPoint.position, SpawnPoint.rotation, SpawnPoint);
        Destroy(effect.gameObject, effect.main.duration);

        Cooldown();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IPushable enemy))
            _enemies.Add(enemy);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IPushable enemy))
            if (_enemies.Contains(enemy))
                _enemies.Remove(enemy);
    }
}
