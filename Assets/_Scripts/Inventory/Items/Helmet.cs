using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Healer Item", menuName = "Inventory/Items/New Helmet Item")]
public class Helmet : ItemTemplate
{
    [SerializeField] private int _armor;
}
