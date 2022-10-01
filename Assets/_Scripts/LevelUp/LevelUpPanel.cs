using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelUpPanel : MonoBehaviour
{
    [SerializeField] private List <ButtonUp> _buttonsUp;
    [SerializeField] private List<int> _parametrs;

    private void OnEnable()
    {
        foreach (var button in _buttonsUp)
        {
            button.ClickedButtonUp += IncreasingParameter; 
        }        
    }

    private void OnDisable()
    {
        foreach (var button in _buttonsUp)
        {
            button.ClickedButtonUp -= IncreasingParameter;
         }
    }

    private void IncreasingParameter(int index)
    {
        _parametrs[index] += 1;
    }

    

}
