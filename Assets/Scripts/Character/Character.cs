using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    private Health health;
    private AttackBehavior attackBehavior;

    public bool Selected { get; set; }

    private void OnEnable()
    {
        health = GetComponent<Health>();
        attackBehavior = GetComponent<AttackBehavior>();

        Squad.characters.Add(this);
    }

    public void TakeDamage(int damage)
    {
        health.ReduceHealth(damage);
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public override string ToString()
    {
        return $"Character Name: {gameObject.name}, Helth: {health.ToString()}, Attack: {attackBehavior.ToString()}";
    }

    private void OnDisable()
    {
        Squad.characters.Remove(this);
    }

    
}
