using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Healer Item", menuName = "Inventory/Items/New Armor Item")]
public class Armor : ItemTemplate
{
    [SerializeField] private int _armor;
}
