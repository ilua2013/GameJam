using System;

public class ValueMaxParameterStrength : ValueMaxParameter
{
    private void OnEnable()
    {
        _textMesh.text = Convert.ToString(_playerParameter.MaxStrength);
        _playerParameter.ChangedMaxStrength += ShowParameter;
    }
    private void OnDisable()
    {
        _playerParameter.ChangedMaxStrength -= ShowParameter;
    }
}
