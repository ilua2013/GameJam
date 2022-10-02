using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    int MaxHealth { get; }

    event Action<int> Damaged;
}
