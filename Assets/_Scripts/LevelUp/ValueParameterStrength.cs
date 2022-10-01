using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ValueParameterStrength : MonoBehaviour
{
    [SerializeField] private PlayerParameter _playerParameter;    
    [SerializeField] private TextMeshProUGUI _textMesh;

    private void OnEnable()
    {
        _textMesh.text = Convert.ToString(_playerParameter.MaxStrength); 
        _playerParameter.ChangedMaxStrength += ShowParameter;
    }
    private void OnDisable()
    {
        _playerParameter.ChangedMaxStrength -= ShowParameter;
    }

    private void ShowParameter(int strength)
    {
        _textMesh.text = Convert.ToString( strength);
    }
}
