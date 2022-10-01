using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ItemCell))]
public class OnItemUIHover : MonoBehaviour, IPointerEnterHandler
{
    private ItemCell _itemCell;

    private void Awake()
    {
        _itemCell = GetComponent<ItemCell>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_itemCell.IsEmpty == false)
            Debug.Log(_itemCell.Item.Name);
    }
}
