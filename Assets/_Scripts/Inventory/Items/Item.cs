using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    All,
    Healer,
    Weapon,
    Helmet,
    Gloves,
    Armor,
    Leggings
}

public class Item : MonoBehaviour
{
    [SerializeField] private ItemTemplate _itemTemplate;
    [SerializeField] private ItemType _itemType;

    public ItemTemplate ItemTemplate => _itemTemplate;
    public ItemType ItemType => _itemType;

    public void PickUp()
    {
        gameObject.SetActive(false);
    }
}
