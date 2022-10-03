using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExperenceAttracte : MonoBehaviour
{
    [SerializeField] private int _maxExperince;
    [SerializeField] private PlayerFighter _playerFighter;

    private int _level = 0;
    private int _experience;
    private HealthEnemy _currentEnemyHealt;
    private bool _isActivEnemy = false;

    public event UnityAction<int> Collected;
    public event UnityAction LevelReceived;

    private void OnEnable()
    {
        _playerFighter.BattleBegun += AddBattleExperience;
    }
    private void OnDisable()
    {        
        _playerFighter.BattleBegun -= AddBattleExperience;
    }

    public void BattleTakeExperience(int experience)
    {
        if (_isActivEnemy)
        {
            TakeExperience(experience);
        }
        _currentEnemyHealt.Died -= BattleTakeExperience;
    }

    public void TakeExperience(int experience)
    {
        _experience += experience;
        LevelUp();
        Collected?.Invoke(_experience);
        _isActivEnemy = false;
    }

    private void LevelUp()
    {
        if (_experience >= _maxExperince)
        {
            _level += 1;
            _experience -= _maxExperince;
            LevelReceived?.Invoke();
        }
    }

    private void AddBattleExperience(EnemyFighter enemyFighter)
    {
        _isActivEnemy = true;
        _currentEnemyHealt = enemyFighter.GetComponent<HealthEnemy>();
        _currentEnemyHealt.Died += BattleTakeExperience;
    }
}
