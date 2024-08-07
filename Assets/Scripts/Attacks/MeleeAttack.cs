using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MeleeAttack : AttackBehavior
{
    private float distanceToTarget;

    public override void Attack()
    {
        StartCoroutine(CoroutineAttack());
    }

    public override void StopAttack()
    {
        StopCoroutine(CoroutineAttack());
    }

    private IEnumerator CoroutineAttack()
    {
        WaitForSeconds delay = new WaitForSeconds(attackDelay);

        yield return delay;

        while (currentTarget != null)
        {
            agent.SetDestination(currentTarget.GetComponent<Transform>().position);

            currentTarget.GetComponent<Enemy>().TakeDamage(damage);

            if (DisableTargets(currentTarget))
            {
                currentTarget = null;
            }

            yield return delay;
        }

        CheckEnemy();
        isAttacked = false;
        StopAttack();
    }

    private bool DisableTargets(NavMeshAgent target)
    {
        if(target != null && !target.gameObject.activeSelf)
        {
            return true;
        }

        return false;
    }
}
