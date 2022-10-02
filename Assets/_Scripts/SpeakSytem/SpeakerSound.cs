using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerSound : MonoBehaviour
{
    [SerializeField] private Speaker _speaker;
    [SerializeField] private AudioClip _sound;

    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _speaker.Speaked += PlaySound;
    }

    private void OnDisable()
    {
        _speaker.Speaked -= PlaySound;
    }

    private void PlaySound(string a)
    {
        if (_speaker.IndexDialof == 1)
            _source.PlayOneShot(_sound);
    }
}
