using UnityEngine;
using UnityEngine.AI;

public class MovementComponent : MonoBehaviour, IMovable
{
    private Animator animator;
    private NavMeshAgent agent;
    private Health targetHealth;
    private bool isMoveToCharacter;

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isMoveToCharacter && !agent.isStopped)
        {
            agent.destination = targetHealth.transform.position;
        }
    }

    public void Move(Vector3 target)
    {
        isMoveToCharacter = false;

        if (agent != null)
        {
            agent.destination = target;
        }
    }

    public void MoveToEnemy(Health target)
    {
        targetHealth = target;

        isMoveToCharacter = true;
    }

    public void StopMoveDistanceCharacter()
    {
        isMoveToCharacter = false;

        agent.isStopped = true;
    }
}
