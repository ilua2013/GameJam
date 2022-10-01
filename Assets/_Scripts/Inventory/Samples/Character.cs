using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IItemPicker
{
    public event Action<Item> PickedUp;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000))
            {
                Debug.Log("Raycast");
                if (hit.collider.TryGetComponent(out Item item))
                    PickedUp?.Invoke(item);
            }
        }
    }
}
