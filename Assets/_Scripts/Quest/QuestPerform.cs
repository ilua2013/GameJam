using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestPerform : MonoBehaviour
{
    [SerializeField] private List<Quest> _quests;
    [SerializeField] private float _distanceToSpeak;

    public float DistanceToSpeak => _distanceToSpeak;

    public event Action AddedQuest;

    public void AddQuest(Quest quest)
    {
        if (_quests.Contains(quest))
            return;

        _quests.Add(quest);
        AddedQuest?.Invoke();
    }
}
