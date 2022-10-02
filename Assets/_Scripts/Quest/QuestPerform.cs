using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestPerform : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private PlayerFighter _fighter;
    [SerializeField] private List<Quest> _quests;
    [SerializeField] private float _distanceToSpeak;

    public float DistanceToSpeak => _distanceToSpeak;

    public event Action AddedQuest;
    public event Action CompletedQuest;

    public void AddQuest(Quest quest)
    {
        if (_quests.Contains(quest))
            return;

        _quests.Add(quest);

        quest.FollowOnTakeItem(_inventory);
        quest.FollowOnKill(_fighter);
        quest.FollowOnSpeak();

        quest.Completed += RemoveQuest;

        AddedQuest?.Invoke();
    }

    private void RemoveQuest(Quest quest)
    {
        print("Quest finish");
        _quests.Remove(quest);
        quest.Completed -= RemoveQuest;

        CompletedQuest?.Invoke();
    }
}
