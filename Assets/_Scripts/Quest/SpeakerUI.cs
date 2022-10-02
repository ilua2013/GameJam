using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeakerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Speaker _speaker;
    [SerializeField] private RectTransform _panelDialog;
    [SerializeField] private Button _buttonNextDialog;
    [SerializeField] private Button _buttonAddQuest;
    [SerializeField] private Button _buttonRefusQuest;

    private void OnValidate()
    {
        _panelDialog.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _buttonRefusQuest.onClick.AddListener(CloseDialogPanel);
        _buttonNextDialog.onClick.AddListener(NextDialog);
        _buttonAddQuest.onClick.AddListener(AddQuest);
        _speaker.ReadyAddedQuest += ShowButtonAddQuest;
        _speaker.StartedSpeak += OpenDialogPanel;
    }

    private void OnDisable()
    {
        _buttonRefusQuest.onClick.RemoveListener(CloseDialogPanel);
        _buttonNextDialog.onClick.RemoveListener(NextDialog);
        _buttonAddQuest.onClick.RemoveListener(AddQuest);
        _speaker.ReadyAddedQuest -= ShowButtonAddQuest;
        _speaker.StartedSpeak -= OpenDialogPanel;
    }

    private void OpenDialogPanel()
    {
        _panelDialog.gameObject.SetActive(true);
        _buttonNextDialog.gameObject.SetActive(true);
        _buttonAddQuest.gameObject.SetActive(false);
        _buttonRefusQuest.gameObject.SetActive(false);

        if(_speaker.e_StateQuest == Speaker.StateQuest.Add || _speaker.e_StateQuest == Speaker.StateQuest.Comleted)
            _buttonNextDialog.onClick.AddListener(CloseDialogPanel);

        NextDialog();
    }

    private void ShowButtonAddQuest()
    {
        _buttonNextDialog.gameObject.SetActive(false);
        _buttonAddQuest.gameObject.SetActive(true);
        _buttonRefusQuest.gameObject.SetActive(true);
    }

    private void CloseDialogPanel()
    {
        _panelDialog.gameObject.SetActive(false);
        _buttonNextDialog.onClick.RemoveListener(CloseDialogPanel);
    }

    private void NextDialog()
    {
        _text.text = _speaker.Speak();
    }

    private void AddQuest()
    {
        _speaker.AddQuestToPerform();
        CloseDialogPanel();
    }
}
