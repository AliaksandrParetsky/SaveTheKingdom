using UnityEngine;

public class DistanceAttack : AttackBehavior
{
    public override void Attack()
    {
        Debug.Log("������������� �����");
    }

    public override void StopAttack()
    {
        Debug.Log("������������� ����� �����������");
    }
}
