using UnityEngine;

public class Armor : Health
{
    [SerializeField] private int armor;
    public int CharacterArmor { get { return armor; } }

    public override void ReduceHealth(int damage)
    {
        damage = damage - CharacterArmor;

        base.ReduceHealth(damage);

        Debug.Log($"{gameObject.name} take {damage} damage");
    }
}
