using UnityEngine;

public class Agility : Health
{
    [SerializeField] private float agility;

    public override void ReduceHealth(float damage)
    {
        damage = damage - agility;

        base.ReduceHealth(damage);

        Debug.Log($"{gameObject.name} take {damage} damage");
    }
}
