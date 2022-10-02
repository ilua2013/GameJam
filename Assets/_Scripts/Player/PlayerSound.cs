using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private PlayerFighter _fighter;
    [SerializeField] private InputClickHandler _clickHandler;
    [SerializeField] private QuestPerform _quest;
    [SerializeField] private float _delayBeetweenSoundWalk;
    [Header("Sounds")]
    [SerializeField] private AudioClip _onAttack;
    [SerializeField] private AudioClip _onKill;
    [SerializeField] private AudioClip _onAddQuest;
    [SerializeField] private AudioClip _onQuestCompleted;
    [SerializeField] private AudioClip _startSpeak;
    [SerializeField] private AudioClip _awakeSound;
    [SerializeField] private List<AudioClip> _onWalk;

    private AudioSource _source;
    private float _time;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _time = _delayBeetweenSoundWalk;

        PlaySound(_awakeSound);
    }

    private void Update()
    {
        _time += Time.deltaTime;
    }

    private void OnEnable()
    {
        _fighter.Killed += PlayOnKill;
        _clickHandler.ClickEnemy += PlayOnAttack;
        _clickHandler.ClickSpeaker += PlayOnSpeak;
        _quest.AddedQuest += PlayOnAddQuest;
        _clickHandler.NewDo += PlayOnWalk;
        _quest.CompletedQuest += PlayOnQuestCompleted;
    }

    private void OnDisable()
    {
        _fighter.Killed -= PlayOnKill;
        _clickHandler.ClickEnemy -= PlayOnAttack;
        _clickHandler.ClickSpeaker -= PlayOnSpeak;
        _quest.AddedQuest -= PlayOnAddQuest;
        _clickHandler.NewDo -= PlayOnWalk;
        _quest.CompletedQuest -= PlayOnQuestCompleted;
    }

    private void PlayOnQuestCompleted()
    {
        PlaySound(_onQuestCompleted);
    }

    private void PlayOnAddQuest()
    {
        PlaySound(_onAddQuest);
    }

    private void PlayOnWalk()
    {
        if (_time >= _delayBeetweenSoundWalk)
        {
            PlaySound(_onWalk[Random.Range(0, _onWalk.Count)]);
            _time = 0;
        }
    }

    private void PlayOnAttack()
    {
        PlaySound(_onAttack);
    } 

    private void PlayOnKill()
    {
        PlaySound(_onKill);
    }

    private void PlayOnSpeak()
    {
        PlaySound(_startSpeak);
    }

    private void PlaySound(AudioClip audioClip)
    {
        if(_source.isPlaying == false)
        {
            _source.PlayOneShot(audioClip);
        }
        else
        {
            StartCoroutine(WaitToPlaySound(audioClip));
        }
    }

    private IEnumerator WaitToPlaySound(AudioClip audioClip)
    {
        while (_source.isPlaying)
            yield return null;

        print("WaitComplete");
        _source.PlayOneShot(audioClip);
    }
}
