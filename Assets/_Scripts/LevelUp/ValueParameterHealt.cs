using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ValueParameterHealt : MonoBehaviour
{
    [SerializeField] private PlayerParameter _playerParameter;
    [SerializeField] private TextMeshProUGUI _textMesh;

    private void OnEnable()
    {
        _textMesh.text = Convert.ToString(_playerParameter.MaxHealt);
        _playerParameter.ChangedMaxHealt += ShowParameter;
    }
    private void OnDisable()
    {
        _playerParameter.ChangedMaxHealt -= ShowParameter;
    }

    private void ShowParameter(int healt)
    {
        _textMesh.text = Convert.ToString(healt);
    }
}
