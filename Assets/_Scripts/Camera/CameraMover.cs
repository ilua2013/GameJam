using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _follow;
    [SerializeField] private Vector3 _positionOffset;
    [SerializeField] private Vector3 _eulerOffset;

    private void OnValidate()
    {
        transform.position = _follow.position + _positionOffset;
        transform.eulerAngles = _eulerOffset;
    }

    private void Awake()
    {
        transform.eulerAngles = _eulerOffset;
    }

    private void Update()
    {
        transform.position = _follow.position + _positionOffset;
    }
}
