using System.Collections;
using UnityEngine;

public abstract class AttackBehavior : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected float attackDelay;
    [SerializeField] protected float radiusAttack;
    private bool isAttack;

    private Animator animator;
    private Health health;

    public bool IsAttack { get { return isAttack; } private set { isAttack = value; } }

    private Health currentTarget;
    public Health CurrentTarget { get { return currentTarget; } set { currentTarget = value; } }

    private void OnEnable()
    {
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();

        health.diedEvent += SetEnabled;

        StartCoroutine(CheckAttack());
    }

    private void SetEnabled()
    {
        enabled = false;
        StopAllCoroutines();
    }

    private IEnumerator CheckAttack()
    {
        while (enabled)
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
            animator.SetBool("isAttack", true);

            CurrentTarget.ReduceHealth(damage);

            if (CurrentTarget.CheckDied())
            {
                CurrentTarget = null;
            }

            yield return delay;
        }

        animator.SetBool("isAttack", false);

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

    

    private void OnDisable()
    {
        health.diedEvent += SetEnabled;

        StopCoroutine(CoroutineAttack());
        StopCoroutine(CheckAttack());
    }
}
