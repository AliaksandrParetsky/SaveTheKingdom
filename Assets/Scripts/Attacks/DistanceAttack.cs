using UnityEngine;

public class DistanceAttack : AttackBehavior
{
    public override void Attack()
    {
        Debug.Log("Дистанционная атака");
    }

    public override void StopAttack()
    {
        Debug.Log("Дистанционная атака остановлина");
    }
}
