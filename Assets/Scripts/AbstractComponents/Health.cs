using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    //public event Action<int> changed;
    public event Action diedEvent;

    [SerializeField] private int health;

    private Animator animator;
    private NavMeshAgent meshAgent;
    private bool isDeid;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();

        meshAgent = GetComponent<NavMeshAgent>();
    }

    public virtual void ReduceHealth(int damage)
    {
        if (!isDeid)
        {
            health = health - damage;

            //changed?.Invoke(health);

            if (health <= 0)
            {
                print($"{gameObject.name} died");

                StartCoroutine(Death());
            }
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

    private IEnumerator Death()
    {
        isDeid = true;

        if(animator != null && meshAgent != null)
        {
            animator.SetTrigger("isDied");

            meshAgent.enabled = false;
        }
        
        diedEvent?.Invoke();

        enabled = false;

        for(int i = 0; i < 1; i++)
        {
            yield return new WaitForSeconds(3);
        }

        gameObject.SetActive(false);
    }

    public bool CheckDied()
    {
        if (isDeid)
        {
            return true;
        }

        return false;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
