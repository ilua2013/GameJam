using UnityEngine;
using UnityEngine.AI;
using System;

public class Mover : MonoBehaviour, IPauseHandler
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Inventory _inventory;

    public event Action Stoped;
    public event Action Moved;

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
        _agent.SetDestination(position);
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
