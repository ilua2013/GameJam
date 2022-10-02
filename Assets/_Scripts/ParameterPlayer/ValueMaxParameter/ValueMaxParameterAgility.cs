using System;

public class ValueMaxParameterAgility : ValueMaxParameter
{
    private void OnEnable()
    {
        _textMesh.text = Convert.ToString(_playerParameter.MaxAgility);
        _playerParameter.ChangedMaxAgility += ShowParameter;
    }
    private void OnDisable()
    {
        _playerParameter.ChangedMaxAgility -= ShowParameter;
    }
}
