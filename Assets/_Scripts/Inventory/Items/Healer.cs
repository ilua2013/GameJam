using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Healer Item", menuName = "Inventory/Items/New Healer Item")]
public class Healer : Item
{
    [SerializeField] private int _volume;
}
