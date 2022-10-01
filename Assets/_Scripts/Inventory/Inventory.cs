using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemCell[] _itemCells;
    [SerializeField] private Transform _content;
    
    private bool _isOpened;

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

    public void AddItem(Item item)
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
