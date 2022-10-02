using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerParameter : MonoBehaviour
{
    [SerializeField] private LevelUpPanel _upPanel;
    [SerializeField] private PlayerClassed _playerClassed;

    private string _nameClass;
    private int _healtMax;
    private int _strengthMax;
    private int _agilityMax;

    public string NameClass => _nameClass;
    public int MaxHealt => _healtMax;
    public int MaxStrength => _strengthMax;
    public int MaxAgility => _agilityMax;

    public event UnityAction<int> ChangedMaxStrength;
    public event UnityAction<int> ChangedMaxAgility;
    public event UnityAction<int> ChangedMaxHealt;

    public void Init(string name, int healt, int strength, int agility)
    {
        _nameClass = name;
        _healtMax = healt;
        _strengthMax = strength;
        _agilityMax = agility;
        ChangedMaxHealt?.Invoke(_healtMax);
        ChangedMaxStrength?.Invoke(_strengthMax);
        ChangedMaxAgility?.Invoke(_agilityMax);
    }

    public void IncreaseMaxHealt(int value)
    {
        _healtMax += value;
        ChangedMaxHealt?.Invoke(_healtMax);
    }

    public void IncreaseMaxStrenght(int value)
    {
        _strengthMax += value;
        ChangedMaxStrength?.Invoke(_strengthMax);
    }

    public void IncreaseAgilityMax(int value)
    {
        _agilityMax += value;
        ChangedMaxAgility?.Invoke(_agilityMax);
    }
}
