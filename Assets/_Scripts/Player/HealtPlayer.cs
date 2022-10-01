using UnityEngine;
using UnityEngine.Events;

public class HealtPlayer : MonoBehaviour
{
    [SerializeField] private PlayerParameter _playerParameter;

    private int _currentHealt;
    private int _maxHealt;

    public event UnityAction PlayerDied;
    public event UnityAction<int> ChangedHealt;

    private void OnEnable()
    {
        _maxHealt = _playerParameter.MaxHealt;
        _currentHealt = _maxHealt;

        _playerParameter.ChangedMaxHealt += IncreaseMaxHealt; 
    }

    private void OnDisable()
    {
        _playerParameter.ChangedMaxHealt -= IncreaseMaxHealt;
    }

    public void TakeDamage(int damage)
    {
        _currentHealt -= damage;
        ChangedHealt?.Invoke(_currentHealt);
        if (_currentHealt <= 0)
        {
            PlayerDied?.Invoke();
            gameObject.SetActive(false);
        }
    }

    public void RecoveryHealt(int healt)
    {
        if (_maxHealt - _currentHealt > healt)
            _currentHealt += healt;
        else
            _currentHealt += _maxHealt - _currentHealt;
        ChangedHealt?.Invoke(_currentHealt);
    }

    private void IncreaseMaxHealt(int maxHealt)
    {
        _maxHealt = maxHealt;
    }
}
