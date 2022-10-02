using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private int _maxHealt;
    [SerializeField] private int _experience;

    private int _currentHealt;  

    public event Action<int> Died;
    public event Action<int> ChangedHealt;

    public int Health => _currentHealt;

    private void OnEnable()
    {
        _currentHealt = _maxHealt;
    }

    public void TakeDamage(int damage, Action onKill = null)
    {
        _currentHealt -= damage;
        ChangedHealt?.Invoke(_currentHealt);
        if (_currentHealt <= 0)
        {
            Died?.Invoke(_experience);
            onKill?.Invoke();
            gameObject.SetActive(false);
        }
    }

    public void RecoveryHealt(int healt)
    {
        if (_maxHealt - _currentHealt > healt)
            _currentHealt += healt;
        else
            _currentHealt += _maxHealt - _currentHealt;
        ChangedHealt?.Invoke(_currentHealt);
    }
}
