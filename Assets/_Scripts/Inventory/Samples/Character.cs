using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : IItemPicker
{
    [SerializeField] private Inventory _inventory;

    public event Action<Item> PickedUp;

    
}
