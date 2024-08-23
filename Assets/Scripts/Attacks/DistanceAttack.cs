using UnityEngine;

public class DistanceAttack : AttackBehavior
{
    protected override bool CanAttack()
    {
        var distance = Vector3.Distance(transform.position, CurrentTarget.transform.position);

        if (distance <= radiusAttack)
        {
            if(TryGetComponent<IMovable>(out var movable))
            {
                movable.StopMoveDistanceCharacter();
            }

            return true;
        }

        return false;
    }
}
