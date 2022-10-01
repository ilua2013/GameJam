using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    private void OnValidate()
    {
        _agent = _agent == null ? GetComponent<NavMeshAgent>() : _agent;
    }

    public void MoveTo(Vector3 position)
    {
        _agent.SetDestination(position);
    }
}
