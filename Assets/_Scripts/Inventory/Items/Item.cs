using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _maximumAmount;
    [SerializeField] private string _description;

    public string Name => _name;
    public int MaximumAmount => _maximumAmount;
    public string Description => _description;
}
