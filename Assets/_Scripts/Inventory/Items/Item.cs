using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemTemplate _itemTemplate;

    public ItemTemplate ItemTemplate => _itemTemplate;
}
