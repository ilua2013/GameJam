using System;

public class ValueMaxParameterHealt : ValueMaxParameter
{
    private void OnEnable()
    {
        _textMesh.text = Convert.ToString(_playerParameter.MaxHealt);
        _playerParameter.ChangedMaxHealt += ShowParameter;
    }
    private void OnDisable()
    {
        _playerParameter.ChangedMaxHealt -= ShowParameter;
    }
}
