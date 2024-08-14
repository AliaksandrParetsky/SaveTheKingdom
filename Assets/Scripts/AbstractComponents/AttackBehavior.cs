using System.Collections;
using UnityEngine;

public abstract class AttackBehavior : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected float attackDelay;
    [SerializeField] protected float radiusAttack;
    private bool isAttack;
    public bool IsAttack { get { return isAttack; } private set { isAttack = value; } }

    private Health currentTarget;
    public Health CurrentTarget { get { return currentTarget; } set { currentTarget = value; } }

    private void OnEnable()
    {
        StartCoroutine(CheckAttack());
    }

    private IEnumerator CheckAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            if (CurrentTarget != null && !IsAttack && CanAttack())
            {
                IsAttack = true;

                print($"{gameObject.name} - Attacked!");

                StartCoroutine(CoroutineAttack());
            }
        }
    }

    private IEnumerator CoroutineAttack()
    {
        WaitForSeconds delay = new (attackDelay);

        while (CurrentTarget != null && CanAttack())
        {
            CurrentTarget.ReduceHealth(damage);

            if (DisableTargets(CurrentTarget))
            {
                CurrentTarget = null;
            }

            yield return delay;
        }

        IsAttack = false;

        print($"{gameObject.name} - Exite Attacked!");
    }

    protected virtual bool CanAttack()
    {
        var distance = Vector3.Distance(transform.position, CurrentTarget.transform.position);

        if (distance <= radiusAttack)
        {
            return true;
        }

        return false;
    }

    private bool DisableTargets(Health target)
    {
        if (target != null && !target.gameObject.activeSelf)
        {
            return true;
        }

        return false;
    }

    private void OnDisable()
    {
        StopCoroutine(CoroutineAttack());
        StopCoroutine(CheckAttack());
    }
}
