using UnityEngine;

[RequireComponent (typeof(MovementComponent))]
public class Enemy : BaseCharacter
{
    private Health mainTarget;
    public Health MainTarget { get { return mainTarget; } private set { mainTarget = value; } }

    private IMovable movable;

    private Health health;

    private void OnEnable()
    {
        health = GetComponent<Health>();

        health.diedEvent += SetEnabled;

        MainTarget = FindObjectOfType<MinionesSpawner>().GetComponent<Health>();

        movable = GetComponent<IMovable>();
    }

    private void Start()
    {
        movable.Move(MainTarget.transform.position);
    }
    private void SetEnabled()
    {
        enabled = false;
    }

    private void OnDisable()
    {
        health.diedEvent -= SetEnabled;
    }
}
