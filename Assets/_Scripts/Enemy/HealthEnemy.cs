using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private int _maxHealt;

    private int _currentHealt;

    public event Action Died;
    public event Action<int> ChangedHealt;

    private void OnEnable()
    {
        _currentHealt = _maxHealt;
    }

    public void TakeDamage(int damage)
    {
        _currentHealt -= damage;
        ChangedHealt?.Invoke(_currentHealt);
        if (_currentHealt <= 0)
        {
            Died?.Invoke();
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
