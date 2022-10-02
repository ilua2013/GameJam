using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPushable
{
    Rigidbody Rigidbody { get; }
    void Push(Vector3 direction);
}
