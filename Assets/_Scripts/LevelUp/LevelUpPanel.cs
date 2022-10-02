using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelUpPanel : MonoBehaviour
{
    [SerializeField] private List<ButtonUp> _buttonsUp;
    [SerializeField] private PlayerParameter _playerParameter;
    [SerializeField] private int _increaseValue;
    [SerializeField] private GameObject _panel;
    [SerializeField] private LevelUp _levelUp;
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private HealthBar _healthBar;

    private bool _isOpened;

    private void OnEnable()
    {
        foreach (var button in _buttonsUp)
        {
            button.ClickedButtonUp += IncreasingParameter;
        }
        _levelUp.ChangedValueExperiencePoint += ShowExperiencePoint;
    }

    private void OnDisable()
    {
        foreach (var button in _buttonsUp)
        {
            button.ClickedButtonUp -= IncreasingParameter;
        }
        _levelUp.ChangedValueExperiencePoint -= ShowExperiencePoint;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (_isOpened)
                Close();

            else
                Open();
        }
    }

    public void Open()
    {
        PauseManager.Instance.Pause(true);
        _healthBar.gameObject.SetActive(false);
        _panel.gameObject.SetActive(true);
        _isOpened = true;
    }

    public void Close()
    {
        PauseManager.Instance.Pause(false);
        _healthBar.gameObject.SetActive(true);
        _panel.gameObject.SetActive(false);
        _isOpened = false;
    }

    private void IncreasingParameter(int index)
    {
        if (_levelUp.CurrentExpriencePoint == 0)
        {
            _textMesh.text = "No Points ";
            return;
        }
        _levelUp.RemoveExperiencePoint();
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

    private void ShowExperiencePoint(int point)
    {
        _textMesh.text = Convert.ToString(point);
    }
}
