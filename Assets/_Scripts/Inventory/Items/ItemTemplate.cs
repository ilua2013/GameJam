using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTemplate : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Item _itemPrefab;
    [SerializeField] private ItemType _itemType;

    public string Name => _name;
    public string Description => _description;
    public Sprite Sprite => _sprite;
    public Item ItemPrefab => _itemPrefab;
    public ItemType ItemType => _itemType;
}
