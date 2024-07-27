using UnityEngine;
using UnityEngine.AI;

public class MovementComponent : MonoBehaviour, IMovable
{
    private NavMeshAgent agent;
    public NavMeshAgent Agent
    {
        get { return agent = agent ?? GetComponent<NavMeshAgent>(); }
    }

    public void Move(Vector3 target)
    {
        Agent.SetDestination(target);
    }
}
