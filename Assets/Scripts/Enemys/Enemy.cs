using UnityEngine;

[RequireComponent (typeof(MovementComponent))]
public class Enemy : MonoBehaviour, IDamageable
{
    private Health health;

    public bool EnemySelected { get; set; }

    private void OnEnable()
    {
        health = GetComponent<Health>();

        IMovable movable = GetComponent<IMovable>();

        Transform target = FindObjectOfType<MinionesSpawner>().transform;

        movable.Move(target.transform.position);
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void TakeDamage(int damage)
    {
        health.ReduceHealth(damage);
    }
}
