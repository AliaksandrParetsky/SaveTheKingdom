using UnityEngine;

public class Armor : Health
{
    [SerializeField] private float armor;

    public override void ReduceHealth(float damage)
    {
        if (armor == 0)
        {
            base.ReduceHealth(damage);

            Debug.Log($"{gameObject.name} take {damage} damage");

            return;
        }
        else
        {
            damage = damage / armor;
        }

        Debug.Log($"{gameObject.name} take {damage} damage");

        base.ReduceHealth(damage);
    }
}
