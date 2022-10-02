using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealtPlayer _healthPlayer;
    [SerializeField] private MonoBehaviour _playerDamageable;
    [SerializeField] private Image _slider;

    private IDamageable _damageable;

    private void OnValidate()
    {
        if (_playerDamageable is IDamageable)
        {
            _damageable = (IDamageable)_playerDamageable;
        }
        else
        {
            _damageable = null;
            _playerDamageable = null;
        }

        if (_healthPlayer == null)
            _healthPlayer = FindObjectOfType<HealtPlayer>();
    }

    private void OnEnable()
    {
        _damageable.Damaged += OnTakeDamage;
        _healthPlayer.ChangedHealt += OnRecovery;
    }

    private void OnDisable()
    {
        _damageable.Damaged -= OnTakeDamage;
        _healthPlayer.ChangedHealt -= OnRecovery;
    }

    private void OnTakeDamage(int current)
    {
        float remain = (float)current / _damageable.MaxHealth;
        StartCoroutine(LerpValue(remain, 1f));
    }

    private void OnRecovery(int current)
    {
        Debug.Log(current);
        float remain = (float)current / _damageable.MaxHealth;
        StartCoroutine(LerpValue(remain, 1f));
    }

    private IEnumerator LerpValue(float to, float time)
    {
        while (MathF.Abs(_slider.fillAmount - to) > 0.01f)
        {
            _slider.fillAmount = Mathf.MoveTowards(_slider.fillAmount, to, time * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
