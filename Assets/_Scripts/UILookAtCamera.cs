using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAtCamera : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.current;
    }

    private void Update()
    {
        Vector3 targetLook = _camera.transform.position - transform.position;
        targetLook.x = 0;

        transform.forward = -targetLook;
    }
}
