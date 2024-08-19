using System;
using UnityEngine;

[RequireComponent (typeof(MovementComponent))]
public class Enemy : BaseCharacter
{
    private Health mainTarget;
    public Health MainTarget { get { return mainTarget; } private set { mainTarget = value; } }

    private IMovable movable;

    public override void OnEnable()
    {
        base.OnEnable();

        if(FindObjectOfType<MinionesSpawner>())
        {
            MainTarget = FindObjectOfType<MinionesSpawner>().GetComponent<Health>();
        }

        movable = GetComponent<IMovable>();
    }

    private void Start()
    {
        if(MainTarget != null)
        {
            movable.Move(MainTarget.transform.position);
        }
    }
}
