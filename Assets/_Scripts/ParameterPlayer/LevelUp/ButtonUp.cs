using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonUp : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int _index;

    public event UnityAction<int> ClickedButtonUp;

    private void OnEnable()
    {
        _button.onClick.AddListener(PassingClicks);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PassingClicks);
    }

    private void PassingClicks()
    {
        ClickedButtonUp?.Invoke(_index);
    }
}
