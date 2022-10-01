using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemCell[] _itemCells;
    [SerializeField] private Transform _content;
    [SerializeField] private GameObject _itemPicker;
    [SerializeField] private float _distanceTakeItem;

    private IItemPicker _picker;
    private bool _isOpened;

    public float DistanceToAddItem => _distanceTakeItem;

    private void OnValidate()
    {
        _picker = _itemPicker.GetComponent<IItemPicker>();

        if (_picker == null) 
            _itemPicker = null;
    }

    private void OnEnable()
    {
        _picker.PickedUp += OnPickUp;
    }

    private void OnDisable()
    {
        _picker.PickedUp -= OnPickUp;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (_isOpened)
                Close();
            else
                Open();
        }
    }

    private void Open()
    {
        _content.gameObject.SetActive(true);
        _isOpened = true;
    }

    private void Close()
    {
        _content.gameObject.SetActive(false);
        _isOpened = false;
    }

    private void OnPickUp(Item item)
    {
        AddItem(item.ItemTemplate);
    }

    private void AddItem(ItemTemplate item)
    {
        foreach (var cell in _itemCells)
        {
            if (cell.Item == item)
            {
                cell.Put(item);
                return;
            }
        }

        foreach (var cell in _itemCells)
        {
            if (cell.IsEmpty)
            {
                cell.Put(item);
                return;
            }
        }
    }
}
