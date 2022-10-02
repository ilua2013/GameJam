using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioClip _onAttack;
    [SerializeField] private AudioClip _onKill;
    [SerializeField] private PlayerFighter _fighter;
    [SerializeField] private InputClickHandler _clickHandler;

    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _fighter.Killed += PlayOnKill;
        _clickHandler.ClickEnemy += PlayOnAttack;
    }

    private void OnDisable()
    {
        _fighter.Killed += PlayOnKill;
        _clickHandler.ClickEnemy += PlayOnAttack;
    }

    private void PlayOnAttack()
    {
        _source.PlayOneShot(_onAttack);
    }

    private void PlayOnKill()
    {
        _source.PlayOneShot(_onKill);
    }
}
