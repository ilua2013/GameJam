using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Quest", menuName = "Quest/New Quest", order = 49)]
public class Quest : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private List<EnemyFighter> _enemyKill;
    [SerializeField] private List<Item> _itemDelivery;
    [SerializeField] private List<Speaker> _npcSpeak;

    public event Action<Quest> Completed;

    public void FollowOnTakeItem(Inventory inventory)
    {
        if (_itemDelivery.Count == 0)
            return;

        inventory.AddedItem_get += OnAddItem;
        Debug.Log("Quest Follow");
    }

    public void FollowOnKill(PlayerFighter player)
    {
        if (_enemyKill.Count == 0)
            return;

        player.Killed_get += OnKill;
    }

    public void FollowOnSpeak()
    {
        if (_npcSpeak.Count == 0)
            return;

        foreach (var item in _npcSpeak)
            item.StartedSpeak_getThis += OnSpeak;
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

    private void OnKill(EnemyFighter enemyFighter)
    {
        foreach (var items in _enemyKill)
        {
            if (enemyFighter.GetType() == items.GetType())
            {
                _enemyKill.Remove(items);
                Debug.Log("Quest - Kill");

                break;
            }
        }

        CheckCompleted();
    }

    private void OnSpeak(Speaker speaker)
    {
        foreach (var items in _npcSpeak)
        {
            if (speaker.Name == items.Name)
            {
                items.StartedSpeak_getThis -= OnSpeak;
                _npcSpeak.Remove(items);
                Debug.Log("Quest - Kill");

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
