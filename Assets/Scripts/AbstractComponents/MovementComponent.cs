using System;
using UnityEngine;
using UnityEngine.AI;

public class MovementComponent : MonoBehaviour, IMovable
{
    private Animator animator;
    private NavMeshAgent agent;
    private Health targetHealth;
    private Health health;
    private bool isMoveToCharacter;

    private bool isMove;

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();

        health.diedEvent += SetEnabled;
    }

    private void SetEnabled()
    {
        enabled = false;
    }

    private void Update()
    {
        if (agent.velocity.magnitude < 0.1f)
        {
            if (!isMove)
            {
                animator.SetBool("isMove", false);
                isMove = true;
            }
        }
        if (agent.velocity.magnitude > 0.1f && isMove)
        {
            if (isMove)
            {
                animator.SetBool("isMove", true);
                isMove= false;
            }
        }
        if (isMoveToCharacter && !agent.isStopped)
        {
            if(targetHealth != null)
            {
                agent.destination = targetHealth.transform.position;
            }
        }
    }

    public void Move(Vector3 target)
    {
        isMoveToCharacter = false;

        agent.isStopped = false;

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

    private void OnDisable()
    {
        health.diedEvent -= SetEnabled;
    }
}
