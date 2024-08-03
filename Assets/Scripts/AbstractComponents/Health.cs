using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<int> changed;
    public event Action died;

    [SerializeField] private int health;

    public virtual void ReduceHealth(int damage)
    {
        health = health - damage;

        changed?.Invoke(health);

        if(health <= 0)
        {
            died?.Invoke();
        }
    }

    public override string ToString()
    {
        if(this is Armor armor)
        {
            return $"Health: {health}, Armor: {armor.CharacterArmor}";
        }
        if(this is Agility agility)
        {
            return $"Health: {health}, Armor: {agility.CharacterAgility}";
        }

        return base.ToString();
    }
}
