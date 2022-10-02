using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets._Scripts.Extensions;

public class ItemCell : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private Transform _dragParent;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private Sprite _defaultSprite;

    public ItemTemplate Item { get; private set; }
    public int Amount { get; private set; }
    public bool IsEmpty { get; private set; } = true;
    public ItemType ItemType => _itemType;

    public event Action<ItemTemplate> ItemDropped;

    public bool CanPut(ItemTemplate item)
    {
        if (item == null)
            return true;
        else if (item.ItemType != _itemType && _itemType != ItemType.All)
            return false;
        else if (IsEmpty)
            return true;
        else if (Item == item)
            return true;
        else
            return false;
    }

    public void Put(ItemTemplate item)
    {
        if (item == null)
        {
            Item = item;
            IsEmpty = true;

            _image.sprite = _defaultSprite;
        }
        else if (IsEmpty)
        {
            Item = item;
            IsEmpty = false;

            _image.sprite = item.Sprite;
        }
        else if (Item == item)
        {
            Amount++;
            IsEmpty = false;
        }
    }

    public ItemTemplate Remove()
    {
        var item = Item;

        Item = null;
        IsEmpty = true;
        _image.sprite = _defaultSprite;

        return item;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (IsEmpty) return;

        _image.transform.parent = _dragParent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (IsEmpty) return;

        _image.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsEmpty) return;

        var swapCell = EventSystem.current.GetFirstUnderPointer<ItemCell>(eventData);

        if (swapCell)
            SwapItems(swapCell);
        else
            TryDropItem(eventData);

        ResetItemPosition();
    }

    private void TryDropItem(PointerEventData eventData)
    {
        _image.raycastTarget = false;

        if (!EventSystem.current.IsMouseOverUI(eventData))
        {
            var item = Remove();
            ItemDropped?.Invoke(item);
        }

        _image.raycastTarget = true;
    }

    private void SwapItems(ItemCell swapCell)
    {
        if (swapCell.CanPut(Item))
        {
            if (CanPut(swapCell.Item))
            {
                var item = Remove();
                var swapItem = swapCell.Remove();

                swapCell.Put(item);
                CanPut(swapItem);
            }
        }
    }

    private void ResetItemPosition()
    {
        _image.transform.parent = transform;
        _image.transform.localPosition = Vector3.zero;
    }
}
