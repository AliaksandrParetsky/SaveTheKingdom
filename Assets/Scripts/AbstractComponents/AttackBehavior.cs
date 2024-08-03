using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider))]
public abstract class AttackBehavior : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected float attackDelay;

    private Queue<IDamageable> targets = new Queue<IDamageable>();

    //public event Action<IDamageable> attackEvent;

    public abstract void Attack();
    public abstract void StopAttack();

    private void OnTriggerEnter(Collider other)
    {
        IDamageable target = other?.GetComponent<IDamageable>();

        if (target != null)
        {
            targets.Enqueue(target);

            if (this is MeleeAttack meleeAttack)
            {
                meleeAttack.Attack();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IDamageable target = other?.GetComponent<IDamageable>();

        if(target != null)
        {
            targets.TryDequeue(out target);

            if (this is MeleeAttack meleeAttack)
            {
                meleeAttack.StopAttack();
            }
        }
    }
}
