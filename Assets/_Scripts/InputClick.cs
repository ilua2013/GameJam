using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputClick : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;

    private void OnValidate()
    {
        _playerMover = FindObjectOfType<PlayerMover>();
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

        if (Physics.Raycast(ray, out hit, 1000))
        {
            _playerMover.MoveTo(hit.point);
        }
    }
}
