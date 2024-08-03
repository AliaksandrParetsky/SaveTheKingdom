using UnityEngine;

public class Agility : Health
{
    [SerializeField] private int agility;
    public int CharacterAgility {  get { return agility; } }

    public override void ReduceHealth(int damage)
    {
        damage = damage - agility;

        base.ReduceHealth(damage);
    }
}
