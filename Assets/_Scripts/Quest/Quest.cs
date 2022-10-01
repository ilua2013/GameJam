using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest/New Quest", order = 49)]
public class Quest : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private List<GameObject> _enemyKill;
    [SerializeField] private List<Item> _itemDelivery;
    [SerializeField] private List<GameObject> _npcSpeak;

    public event Action<Quest> Completed;

    public void InvokeCompleted()
    {
        Completed?.Invoke(this);
    }
}
