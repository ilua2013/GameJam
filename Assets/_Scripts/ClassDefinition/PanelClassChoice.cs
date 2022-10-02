using System.Collections;
using UnityEngine;

public class PanelClassChoice : MonoBehaviour
{
    [SerializeField] private ClassDefinition _classDefinition;
    [SerializeField] private HealthBar _healthBar;

    private void OnEnable()
    {
        _classDefinition.ChoiceOver += ClosePanel;
    }

    private void OnDisable()
    {
        _classDefinition.ChoiceOver -= ClosePanel;
    }

    private void ClosePanel()
    {
        StartCoroutine(DelayClosePanel());
    }

    private IEnumerator DelayClosePanel()
    {
        WaitForSeconds delay = new WaitForSeconds(0.1f);
        yield return delay;
        _healthBar.gameObject.SetActive(true);
        gameObject.SetActive(false);

    }
}
