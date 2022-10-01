using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Healer Item", menuName = "Inventory/Items/New Gloves Item")]
public class Gloves : ItemTemplate
{
    [SerializeField] private int _armor;
}
