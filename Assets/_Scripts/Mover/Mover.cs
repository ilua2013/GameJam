using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Mover : MonoBehaviour, IPauseHandler
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Inventory _inventory;

    public event Action Stoped;
    public event Action Moved;
    public event Action<Vector3> Moved_getPos;

    public bool IsStop => _agent.velocity == Vector3.zero;

    private void OnValidate()
    {
        _agent = _agent == null ? GetComponent<NavMeshAgent>() : _agent;
    }

    private void OnEnable()
    {
        Register(this);

        if(_inventory != null)
        _inventory.AddedItem += StopMove;
    }

    private void OnDisable()
    {
        UnRegister(this);
        if (_inventory != null)
            _inventory.AddedItem -= StopMove;
    }

    public void Register(IPauseHandler handler)
    {
        PauseManager.Instance.Register(handler);
    }

    public void UnRegister(IPauseHandler handler)
    {
        PauseManager.Instance.UnRegister(handler);
    }

    public void MoveTo(Vector3 position)
    {
        if (_agent.enabled == false)
            return;

        _agent.SetDestination(position);

        Moved_getPos?.Invoke(position);
        Moved?.Invoke();
    }

    public void Pause(bool isPaused)
    {
        _agent.isStopped = isPaused;
        StopMove();
    }

    public void StopMove()
    {
        _agent.SetDestination(transform.position);
        Stoped?.Invoke();
    }
}
