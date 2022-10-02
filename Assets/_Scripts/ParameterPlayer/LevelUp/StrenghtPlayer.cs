using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StrenghtPlayer : MonoBehaviour
{
    [SerializeField] private PlayerParameter _playerParameter;

    private int _currentStrenght;
    private int _maxHealt;

    public event UnityAction PlayerDied;
    public event UnityAction<int> ChangedHealt;

    

    private void IncreaseMaxHealt(int maxHealt)
    {
        _maxHealt = maxHealt;
    }
}
