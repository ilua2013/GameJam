using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputClickHandler : MonoBehaviour, IItemPicker
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Inventory _inventory;

    private Coroutine _checkDistance;

    public event Action<Item> PickedUp;

    private void OnValidate()
    {
        _playerMover = FindObjectOfType<PlayerMover>();
        _inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            ShootRaycast();
    }

    private void ShootRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000) == false)
            return;

        if (_checkDistance != null)
        {
            StopCoroutine(_checkDistance);

            _checkDistance = null;
        }

        if(hit.collider.TryGetComponent(out Item item))
        {
            _playerMover.MoveTo(item.transform.position);
            _checkDistance = StartCoroutine(CheckDistance(item.transform, _inventory.DistanceToAddItem,() => OnReachedItem(item)));
            return;
        }

        _playerMover.MoveTo(hit.point);
    }

    private IEnumerator CheckDistance(Transform target, float distance, Action onComplete = null)
    {
        while (Vector3.Distance(transform.position, target.position) > distance)
            yield return null;

        onComplete?.Invoke();

        _checkDistance = null;
    }

    private void OnReachedItem(Item item)
    {
        PickedUp?.Invoke(item);
    }
}
