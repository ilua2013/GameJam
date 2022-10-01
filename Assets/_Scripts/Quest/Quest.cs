using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest/New Quest", order = 49)]
public class Quest : ScriptableObject
{
    [SerializeField] private List<GameObject> _enemyKill;
    [SerializeField] private List<Item> _itemDelivery;
    [SerializeField] private List<GameObject> _npcSpeak;
}
