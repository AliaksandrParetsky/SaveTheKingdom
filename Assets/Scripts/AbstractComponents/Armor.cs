using UnityEngine;

public class Armor : Health
{
    [SerializeField] private float armor;

    public override void ReduceHealth(float damage)
    {
        if (armor == 0)
        {
            base.ReduceHealth(damage);

            return;
        }
        else
        {
            damage = damage / armor;
        }

        base.ReduceHealth(damage);
    }
}
