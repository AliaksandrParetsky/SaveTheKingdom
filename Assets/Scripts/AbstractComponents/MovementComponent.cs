using UnityEngine;
using UnityEngine.AI;

public class MovementComponent : MonoBehaviour, IMovable
{
    public void Move(Vector3 target)
    {
        if(TryGetComponent<NavMeshAgent>(out var agent))
        {
            agent.SetDestination(target);
        }
    }
}
