using System;
using TMPro;
using UnityEngine;

abstract public class ValueMaxParameter : MonoBehaviour
{
    [SerializeField] protected PlayerParameter _playerParameter;
    [SerializeField] protected TextMeshProUGUI _textMesh;   

    protected void ShowParameter(int value)
    {
        _textMesh.text = Convert.ToString(value);
    }
}
