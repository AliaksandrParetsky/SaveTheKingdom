using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(Collider))]
public abstract class AttackBehavior : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected float attackDelay;
    [SerializeField] protected float enemySearchRadius;

    protected List<NavMeshAgent> targets = new List<NavMeshAgent>();

    protected NavMeshAgent currentTarget;
    protected NavMeshAgent agent;

    protected bool isAttacked;

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public abstract void Attack();
    public abstract void StopAttack();

    private void OnTriggerEnter(Collider other)
    {
        if (!isAttacked)
        {
            CheckEnemy();

            Attack();

            isAttacked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        currentTarget = null;
        targets.Clear();
    }

    protected IEnumerator GetClosestTarget()
    {
        float closestDistance = float.MaxValue;
        currentTarget = null;
        for (int i = 0; i < targets.Count; i++)
        {
            if (agent.SetDestination(targets[i].transform.position))
            {
                while (agent.pathPending)
                {
                    yield return null;
                }

                Debug.Log(agent.pathStatus.ToString());

                if (agent.pathStatus != NavMeshPathStatus.PathInvalid)
                {
                    float pathDistance = 0;
                    pathDistance += Vector3.Distance(transform.position, agent.path.corners[0]);
                    for (int j = 1; j < agent.path.corners.Length; j++)
                    {
                        pathDistance += Vector3.Distance(agent.path.corners[j - 1], agent.path.corners[j]);
                    }

                    if (closestDistance > pathDistance)
                    {
                        closestDistance = pathDistance;
                        currentTarget = targets[i];
                        agent.ResetPath();
                    }
                }
                else
                {
                    Debug.Log("невозможно дойти до " + targets[i].name);
                }
            }
        }
        if (currentTarget != null)
        {
            agent.SetDestination(currentTarget.transform.position);
        }
    }

    protected void CheckEnemy()
    {
        targets.Clear();

        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, enemySearchRadius);
        foreach (Collider collider in hitColliders)
        {
            if (collider.gameObject.TryGetComponent<Enemy>(out var enemyAgent))
            {
                NavMeshAgent agent = enemyAgent.gameObject.GetComponent<NavMeshAgent>();
                targets.Add(agent);
            }
        }

        StartCoroutine(GetClosestTarget());
    }
}
