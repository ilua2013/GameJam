using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemCell : MonoBehaviour
{
    public Item Item { get; private set; }
    public int Amount { get; private set; }
    public bool IsEmpty { get; private set; } = true;

    public void Put(Item item)
    {
        if (IsEmpty)
        {
            Item = item;
            IsEmpty = false;
        }
        else if (Item == item)
        {
            Amount += item.MaximumAmount;
            IsEmpty = false;
        }
        else
            throw new InvalidOperationException($"You can't put an {item} here");
    }
}
