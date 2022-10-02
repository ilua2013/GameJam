using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private QuestPerform _questPerform;
    [SerializeField] private List<string> _textDialog;
    [SerializeField] private string _textPerfomedQuest;
    [SerializeField] private string _textCompleteQuest;
    [SerializeField] private Quest _quest;

    private StateQuest _stateQuest;
    private int _indexDialog = 0;

    public event Action<string> Speaked;
    public event Action ReadyAddedQuest;
    public event Action StartedSpeak;
    public event Action<Speaker> StartedSpeak_getThis;

    public StateQuest e_StateQuest => _stateQuest;
    public string Name => _name;

    public enum StateQuest
    {
        DontAdd, Add, Comleted
    }

    private void Awake()
    {
        _stateQuest = StateQuest.DontAdd;
    }

    public void StartSpeak()
    {
        StartedSpeak?.Invoke();
        StartedSpeak_getThis?.Invoke(this);
    }

    public string Speak()
    {
        switch (_stateQuest)
        {
            case StateQuest.DontAdd:
                string dialog = _textDialog[_indexDialog];
                Speaked?.Invoke(dialog);

                if (_indexDialog == _textDialog.Count - 1)
                    ReadyAddedQuest?.Invoke();

                _indexDialog = _indexDialog >= _textDialog.Count - 1 ? 0 : _indexDialog + 1;

                return dialog;
                break;

            case StateQuest.Add:
                return _textPerfomedQuest;
                break;

            case StateQuest.Comleted:
                return _textCompleteQuest;
                break;
        }

        return null;
    }

    public void AddQuestToPerform()
    {
        _stateQuest = StateQuest.Add;
        _questPerform.AddQuest(_quest);

        _quest.Completed += OnCompletedQuest;
    }

    private void OnCompletedQuest(Quest quest)
    {
        _stateQuest = StateQuest.Comleted;
        quest.Completed -= OnCompletedQuest;
    }
}
