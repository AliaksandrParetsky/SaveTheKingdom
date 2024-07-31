using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(MovementComponent))]
public abstract class Character : MonoBehaviour
{
    private NavMeshAgent agent;
    public NavMeshAgent Agent
    {
        get { return agent = agent ?? GetComponent<NavMeshAgent>(); }
    }
    public bool Selected { get; set; }
    
    private void OnEnable()
    {
        Squad.characters.Add(this);
    }

    public override string ToString()
    {
        return gameObject.name;
    }

    private void OnDisable()
    {
        Squad.characters.Remove(this);
    }

}
