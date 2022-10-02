using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColliderEnemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public event Action<PlayerFighter> ViewPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerFighter playerFighter))
        {
            _animator.SetBool("isEnemy", true);
            ViewPlayer?.Invoke(playerFighter);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerFighter playerFighter))
        {
            _animator.SetBool("isEnemy", false);           
        }
    }
}
