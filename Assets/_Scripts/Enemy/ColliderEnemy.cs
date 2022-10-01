using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColliderEnemy : MonoBehaviour
{
    public event Action<PlayerFighter> ViewPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerFighter playerFighter))
            ViewPlayer?.Invoke(playerFighter);
    }
}
