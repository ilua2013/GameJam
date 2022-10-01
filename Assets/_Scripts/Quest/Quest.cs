using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest/New Quest", order = 49)]
public class Quest : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private List<GameObject> _enemyKill;
    [SerializeField] private List<ItemTemplate> _itemDelivery;
    [SerializeField] private List<GameObject> _npcSpeak;

    public event Action<Quest> Completed;

    public void InvokeCompleted()
    {
        Completed?.Invoke(this);
    }

    public void FollowQuestComplete(Inventory inventory)
    {
        inventory.AddedItem_get += OnAddItem;
    }

    private void OnAddItem(ItemTemplate itemTemplate)
    {
        if (_itemDelivery.Contains(itemTemplate))
        {
            _itemDelivery.Remove(itemTemplate);

            CheckCompleted();
        }
    }

    private void CheckCompleted()
    {
        if (_enemyKill.Count == 0 && _itemDelivery.Count == 0 && _npcSpeak.Count == 0)
            Completed?.Invoke(this);
    }
}
