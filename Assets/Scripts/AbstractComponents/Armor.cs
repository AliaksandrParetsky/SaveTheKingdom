using UnityEngine;

public class Armor : Health
{
    [SerializeField] private int armor;
    public int CharacterArmor { get { return armor; } }

    public override void ReduceHealth(int damage)
    {
        damage = damage / armor;

        base.ReduceHealth(damage);
    }
}
