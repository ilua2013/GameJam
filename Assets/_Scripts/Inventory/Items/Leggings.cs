using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Healer Item", menuName = "Inventory/Items/New Leggings Item")]
public class Leggings : ItemTemplate
{
    [SerializeField] private int _armor;
}
