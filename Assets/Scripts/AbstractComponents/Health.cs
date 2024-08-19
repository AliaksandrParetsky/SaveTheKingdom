using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    //public event Action<int> changed;
    public event Action diedEvent;

    [SerializeField] private float health;

    private Animator animator;
    private NavMeshAgent meshAgent;
    private bool isDeid;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();

        meshAgent = GetComponent<NavMeshAgent>();
    }

    public virtual void ReduceHealth(float damage)
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

        Destroy(gameObject);
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
