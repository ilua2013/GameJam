using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExperenceAttracte : MonoBehaviour, IAddExperience
{
    [SerializeField] private int _maxExperince;

    private int _level = 0;
    private int _experience;

    public event UnityAction<int> Collected;
    public event UnityAction LevelReceived;

    public void TakeExperience(int experience)
    {
        _experience += experience;
        LevelUp();
        Collected?.Invoke(_experience);
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
}
