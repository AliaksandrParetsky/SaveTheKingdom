using UnityEngine;

[RequireComponent (typeof(MovementComponent))]
public class Enemy : MonoBehaviour, IDamageable
{
    public void TakeDamage(int damage)
    {
        Debug.Log($"{gameObject.name} take damage");
    }

    private void OnEnable()
    {
        IMovable movable = GetComponent<IMovable>();

        Transform target = FindObjectOfType<MinionesSpawner>().transform;

        movable.Move(target.transform.position);
    }
}
