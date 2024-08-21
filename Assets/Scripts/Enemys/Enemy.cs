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

        if(FindObjectOfType<CharactersSpawner>())
        {
            MainTarget = FindObjectOfType<CharactersSpawner>().GetComponent<Health>();
        }

        movable = GetComponent<IMovable>();

        EnemyList.enemies.Add(this);
    }

    private void Start()
    {
        if(MainTarget != null)
        {
            movable.Move(MainTarget.transform.position);
        }
    }

    public override void OnDisable()
    {
        EnemyList.enemies.Remove(this);
    }
}
