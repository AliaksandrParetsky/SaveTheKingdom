using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<int> changed;
    public event Action diedEvent;

    [SerializeField] private int health;

    public virtual void ReduceHealth(int damage)
    {
        health = health - damage;

        changed?.Invoke(health);

        if(health <= 0)
        {
            diedEvent?.Invoke();
            print($"{gameObject.name} died");

            Death();
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

    private void Death()
    {
        StopAllCoroutines();
        gameObject.SetActive(false);
    }
}
