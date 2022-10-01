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

    public void FollowQuestComplete(Inventory inventory)
    {
        inventory.AddedItem_get += OnAddItem;
        Debug.Log("Quest Follow");
    }

    private void OnAddItem(Item item)
    {
        foreach (var items in _itemDelivery)
        {
            if (item.ItemTemplate.Name == items.ItemTemplate.Name)
            {
                _itemDelivery.Remove(items);
                Debug.Log("Quest - AddItem");

                break;
            }
        }

        CheckCompleted();
    }

    private void CheckCompleted()
    {
        if (_enemyKill.Count == 0 && _itemDelivery.Count == 0 && _npcSpeak.Count == 0)
        {
            Completed?.Invoke(this);
            Debug.Log("Completed");
        }
    }
}
