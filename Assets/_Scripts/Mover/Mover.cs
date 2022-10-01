using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour, IPauseHandler
{
    [SerializeField] private NavMeshAgent _agent;

    private void OnValidate()
    {
        _agent = _agent == null ? GetComponent<NavMeshAgent>() : _agent;
    }

    private void OnEnable()
    {
        Register(this);
    }

    private void OnDisable()
    {
        UnRegister(this);
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
        MoveTo(transform.position);
    }
}
