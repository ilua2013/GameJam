using System.Collections;
using UnityEngine;

public class PanelClassChoice : MonoBehaviour
{
    [SerializeField] private ClassDefinition _classDefinition;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private GameObject _spellPanel;
 
    private void OnEnable()
    {
        _spellPanel.gameObject.SetActive(false);
        _healthBar.gameObject.SetActive(false);
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
        _spellPanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
