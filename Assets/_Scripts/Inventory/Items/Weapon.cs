using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Healer Item", menuName = "Inventory/Items/New Weapon Item")]
public class Weapon : ItemTemplate
{
    [SerializeField] private int _damage;
}
