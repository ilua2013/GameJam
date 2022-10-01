using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour
{
    [SerializeField] private Image _image;

    public ItemTemplate Item { get; private set; }
    public int Amount { get; private set; }
    public bool IsEmpty { get; private set; } = true;

    public void Put(ItemTemplate item)
    {
        if (IsEmpty)
        {
            Item = item;
            IsEmpty = false;
            Debug.Log(item.Sprite);
            _image.sprite = item.Sprite;
        }
        else if (Item == item)
        {
            Amount++;
            IsEmpty = false;
        }
        else
            throw new InvalidOperationException($"You can't put an {item} here");
    }
}
