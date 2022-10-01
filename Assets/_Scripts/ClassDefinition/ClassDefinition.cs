using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClassDefinition : MonoBehaviour
{
    [SerializeField] private List<ClassButton> _selectionButtons;

    public event UnityAction<ClassPlayer> ClassSelected;
    public event UnityAction ChoiceOver;

    private void OnEnable()
    {
        foreach (var button in _selectionButtons)
        {
            button.SelectedClass += PassClass;
        }
    }

    private void OnDisable()
    {
        foreach (var button in _selectionButtons)
        {
            button.SelectedClass -= PassClass;
        }
    }

    private void PassClass(ClassPlayer classPlayer)
    {
        ChoiceOver?.Invoke();
        ClassSelected?.Invoke(classPlayer);
        PlayerPrefs.SetInt("classSelected", 1);
    }
}
