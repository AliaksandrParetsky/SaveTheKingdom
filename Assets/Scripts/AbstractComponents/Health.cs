using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
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

            if (health <= 0)
            {
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
            yield return new WaitForSeconds(1.5f);
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
