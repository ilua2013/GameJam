using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingPushable : MonoBehaviour, IPushable
{
    [SerializeField] private Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;

    public void Push(Vector3 direction, int damage)
    {
        _rigidbody.AddForce(direction);
    }
}
