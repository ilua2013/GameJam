using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelUp : MonoBehaviour
{
    [SerializeField] private ExperenceAttracte _experenceAttracte;
    [SerializeField] private int _addExperiencePoints;

    public event UnityAction<int> ChangedValueExperiencePoint;

    private int _currentExperiencePoint;

    public int CurrentExpriencePoint => _currentExperiencePoint;

    private void OnEnable()
    {
        _experenceAttracte.LevelReceived += AddExperiencePoint; 
    }
    private void OnDisable()
    {
        _experenceAttracte.LevelReceived -= AddExperiencePoint;
    }

    private void AddExperiencePoint()
    {
        _currentExperiencePoint += _addExperiencePoints;
        ChangedValueExperiencePoint?.Invoke(_currentExperiencePoint);
    }

    public void RemoveExperiencePoint()
    {
        _currentExperiencePoint -= 1;
        ChangedValueExperiencePoint?.Invoke(_currentExperiencePoint);
    }


}
