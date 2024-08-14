using UnityEngine;

[RequireComponent (typeof(MovementComponent))]
public class Enemy : BaseCharacter
{
    public Vector3 mainTarget;

    private IMovable movable;

    private void OnEnable()
    {
        mainTarget = FindObjectOfType<MinionesSpawner>().transform.position;
        health = GetComponent<Health>();

        movable = GetComponent<IMovable>();
    }

    private void Start()
    {
        movable.Move(mainTarget);
    }
}
