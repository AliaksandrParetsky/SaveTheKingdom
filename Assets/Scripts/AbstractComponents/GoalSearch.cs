using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class GoalSearch : MonoBehaviour
{
    private List<Health> targets = new List<Health>();

    [SerializeField] private float enemySearchRadius;

    private float enemySearchDelay = 1.0f;
    private AttackBehavior attackBehavior;
    private NavMeshAgent agent;
    private IMovable movable;
    private Health health;

    private void OnEnable()
    {
        health = GetComponent<Health>();
        attackBehavior = GetComponent<AttackBehavior>();
        agent = GetComponent<NavMeshAgent>();
        movable = GetComponent<IMovable>();

        health.diedEvent += SetEnabled;

        StartCoroutine(SearchEnemy());
    }

    private void SetEnabled()
    {
        enabled = false;
        targets.Clear();
        attackBehavior.CurrentTarget = null;
        StopAllCoroutines();
    }

    private IEnumerator SearchEnemy()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(enemySearchDelay);

            if (!attackBehavior.IsAttack)
            {
                CheckEnemy();
            }
        }
    }

    public void CheckEnemy()
    {
        targets.Clear();

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, enemySearchRadius);

        List<Health> enemys = hitColliders.Where(x => x.GetComponent<Enemy>()).Select(x => x.GetComponent<Health>()).ToList();
        List<Health> characters = hitColliders.Where(x => x.GetComponent<Character>()).Select(x => x.GetComponent<Health>()).ToList();

        if (GetComponent<Enemy>())
        {
            foreach(Health character in characters)
            {
                if (character.enabled)
                {
                    targets.Add(character);
                }
            }
        }

        if (GetComponent<Character>())
        {
            foreach (Health enemy in enemys)
            {
                if (enemy.enabled)
                {
                    targets.Add(enemy);
                }
            }
        }

        if(targets.Count > 0)
        {
            StartCoroutine(GetClosestTarget());
        }
        else
        {
            attackBehavior.CurrentTarget = null;

            if(TryGetComponent<Enemy>(out var enemy))
            {
                attackBehavior.CurrentTarget = enemy.MainTarget;
                movable.MoveToEnemy(attackBehavior.CurrentTarget);
            }
        }
    }

    public IEnumerator GetClosestTarget()
    {
        float closestDistance = float.MaxValue;
        attackBehavior.CurrentTarget = null;
        for (int i = 0; i < targets.Count; i++)
        {
            if (agent.CalculatePath(targets[i].transform.position, agent.path))
            {
                while (agent.pathPending)
                {
                    yield return null;
                }

                if (agent.pathStatus != NavMeshPathStatus.PathInvalid)
                {
                    float pathDistance = 0;
                    var enemyPositionCorners = targets[i].GetComponent<NavMeshAgent>().path.corners;

                    pathDistance += Vector3.Distance(transform.position, enemyPositionCorners[0]);

                    for (int j = 1; j < enemyPositionCorners.Length; j++)
                    {
                        pathDistance += Vector3.Distance(enemyPositionCorners[j - 1], enemyPositionCorners[j]);
                    }

                    if (closestDistance > pathDistance)
                    {
                        closestDistance = pathDistance;
                        attackBehavior.CurrentTarget = targets[i];
                        agent.ResetPath();
                    }
                }
                else
                {
                    Debug.Log("невозможно дойти до " + targets[i].name);
                }
            }
        }
        if (attackBehavior.CurrentTarget != null && movable != null)
        {
            movable.MoveToEnemy(attackBehavior.CurrentTarget);
        }
    }

    private void OnDisable()
    {
        health.diedEvent -= SetEnabled;

        StopCoroutine(SearchEnemy());
        StopCoroutine(GetClosestTarget());
    }
}
