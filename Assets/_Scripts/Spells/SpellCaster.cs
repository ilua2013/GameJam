using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    [SerializeField] private PlayerFighter _playerFighter;

    private Spell[] _spells;
    private EnemyFighter _currentTarget;

    private KeyCode _firstKey = KeyCode.Alpha1;
    private KeyCode _lastKey;

    private void OnValidate()
    {
        _spells = GetComponentsInChildren<Spell>();

        if (_playerFighter == null)
            _playerFighter = FindObjectOfType<PlayerFighter>();
    }

    private void OnEnable()
    {
        _playerFighter.BattleBegun += OnBattleBegun;
    }

    private void OnDisable()
    {
        _playerFighter.BattleBegun -= OnBattleBegun;
    }

    private void Awake()
    {
        _lastKey = _firstKey + _spells.Length;
    }

    private void Update()
    {
        for (KeyCode i = _firstKey; i < _lastKey; i++)
        {
            if (Input.GetKeyDown(i))
            {
                Cast(_spells[(int)(i - KeyCode.Alpha1)]);
            }
        }
    }

    private void OnBattleBegun(EnemyFighter enemy)
    {
        _currentTarget = enemy;
    }

    private void Cast(Spell spell)
    {
        spell.Cast();

        if (_currentTarget != null)
            spell.Cast(_currentTarget);
    }
}
