using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClassButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private ClassPlayer _classPlayer;

    public event UnityAction<ClassPlayer> SelectedClass;

    private void OnEnable()
    {
        _button.onClick.AddListener(SelectClass);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SelectClass);
    }

    private void SelectClass()
    {
        SelectedClass?.Invoke(_classPlayer);
    }
}
