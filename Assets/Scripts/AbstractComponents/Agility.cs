using UnityEngine;

public class Agility : Health
{
    [SerializeField] private int agility;
    public int CharacterAgility {  get { return agility; } }

    public override void ReduceHealth(int damage)
    {
        damage = damage - CharacterAgility;

        base.ReduceHealth(damage);

        Debug.Log($"{gameObject.name} take {damage} damage");
    }
}
