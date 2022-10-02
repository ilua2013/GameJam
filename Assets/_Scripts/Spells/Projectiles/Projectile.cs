using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public EnemyFighter Enemy { get; private set; }

    public void Init(EnemyFighter enemy, Action onTargetReached)
    {
        Enemy = enemy;
        Cast(Enemy.transform.position, onTargetReached);
    }

    protected abstract void Cast(Vector3 target, Action onTargetReached);
}
