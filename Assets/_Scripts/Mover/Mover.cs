using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour, IPauseHandler
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Inventory _inventory;

    private void OnValidate()
    {
        _agent = _agent == null ? GetComponent<NavMeshAgent>() : _agent;
    }

    private void OnEnable()
    {
        Register(this);
        _inventory.AddedItem += StopMove;
    }

    private void OnDisable()
    {
        UnRegister(this);
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
    }

    public void Pause(bool isPaused)
    {
        _agent.isStopped = isPaused;
        StopMove();
    }

    public void StopMove()
    {
        _agent.SetDestination(transform.position);
    }
}
