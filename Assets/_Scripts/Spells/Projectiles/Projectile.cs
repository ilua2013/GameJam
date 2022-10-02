using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public abstract void Cast(Vector3 target, Action<Vector3> onTargetReached);
}
