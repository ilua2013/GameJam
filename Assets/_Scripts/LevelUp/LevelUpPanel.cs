using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelUpPanel : MonoBehaviour
{
    [SerializeField] private List<ButtonUp> _buttonsUp;
    [SerializeField] private PlayerParameter _playerParameter;
    [SerializeField] private int _increaseValue;

    private void OnEnable()
    {
        foreach (var button in _buttonsUp)
        {
            button.ClickedButtonUp += IncreasingParameter;
        }
    }

    private void OnDisable()
    {
        foreach (var button in _buttonsUp)
        {
            button.ClickedButtonUp -= IncreasingParameter;
        }
    }

    private void IncreasingParameter(int index)
    {
        switch (index)
        {
            case 0:
                _playerParameter.IncreaseMaxHealt(_increaseValue);
                break;
            case 1:
                _playerParameter.IncreaseMaxStrenght(_increaseValue);
                break;
            case 2:
                _playerParameter.IncreaseAgilityMax(_increaseValue);
                break;
        }
    }
}
