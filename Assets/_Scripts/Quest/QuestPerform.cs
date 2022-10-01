using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestPerform : MonoBehaviour
{
    [SerializeField] private List<Quest> _quests;

    public event Action AddedQuest;

    public void AddQuest(Quest quest)
    {
        if (_quests.Contains(quest))
            return;

        _quests.Add(quest);
        AddedQuest?.Invoke();
    }
}
