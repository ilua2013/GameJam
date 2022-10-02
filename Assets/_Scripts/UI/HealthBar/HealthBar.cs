using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject _playerDamageable;
    [SerializeField] private Image _slider;

    private IDamageable _damageable;

    private void OnValidate()
    {
        _damageable = _playerDamageable.GetComponent<IDamageable>();

        if (_damageable == null)
            _playerDamageable = null;
    }

    private void OnEnable()
    {
        _damageable.Damaged += OnTakeDamage;
    }

    private void OnDisable()
    {
        _damageable.Damaged -= OnTakeDamage;
    }

    private void OnTakeDamage(int current)
    {
        float remain = (float)current / _damageable.MaxHealth;
        StartCoroutine(LerpValue(remain, 1f));
    }

    private IEnumerator LerpValue(float to, float time)
    {
        while ((_slider.fillAmount - to) > 0.01f)
        {
            _slider.fillAmount = Mathf.MoveTowards(_slider.fillAmount, to, time * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
