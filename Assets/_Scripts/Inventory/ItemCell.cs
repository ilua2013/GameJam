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

    private Sprite _defaultSprite;

    public ItemTemplate Item { get; private set; }
    public int Amount { get; private set; }
    public bool IsEmpty { get; private set; } = true;

    private void Awake()
    {
        _defaultSprite = _image.sprite;
    }

    public void Put(ItemTemplate item)
    {
        if (item == null)
        {
            Item = null;
            IsEmpty = true;

            _image.sprite = _defaultSprite;
        }
        else if(IsEmpty)
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
        else
            throw new InvalidOperationException($"You can't put an {item} here");
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

        var result = new List<RaycastResult>();
        var container = EventSystem.current.GetFirstUnderPointer<ItemCell>(eventData);

        if (container)
        {
            var swapItem = container.Remove();
            Debug.Log(container);

            container.Put(Remove());
            Put(swapItem);
        }

        _image.transform.parent = transform;
        _image.transform.localPosition = Vector3.zero;
    }
}
