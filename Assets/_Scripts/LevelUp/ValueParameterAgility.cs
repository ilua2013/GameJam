using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ValueParameterAgility : MonoBehaviour
{
    [SerializeField] private PlayerParameter _playerParameter;
    [SerializeField] private TextMeshProUGUI _textMesh;

    private void OnEnable()
    {
        _textMesh.text = Convert.ToString(_playerParameter.MaxAgility);
        _playerParameter.ChangedMaxAgility += ShowParameter;
    }
    private void OnDisable()
    {
        _playerParameter.ChangedMaxAgility -= ShowParameter;
    }

    private void ShowParameter(int agility)
    {
        _textMesh.text = Convert.ToString(agility);
    }
}
