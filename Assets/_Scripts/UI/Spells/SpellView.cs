using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellView : MonoBehaviour
{
    [SerializeField] private Image _cooldownIcon;
    [SerializeField] private Spell _spell;

    private void OnEnable()
    {
        _spell.StartCooldown += OnStartCooldwon;
    }

    private void OnDisable()
    {
        _spell.StartCooldown -= OnStartCooldwon;
    }

    private void OnStartCooldwon(int time)
    {
        StartCoroutine(CooldownIcon(time));
    }

    private IEnumerator CooldownIcon(int time)
    {
        float elapsed = 0;
        _cooldownIcon.fillAmount = 0;

        while (elapsed < time)
        {
            _cooldownIcon.fillAmount = Mathf.MoveTowards(0, 1, elapsed / time);

            elapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        _cooldownIcon.fillAmount = 1;
    }
}
