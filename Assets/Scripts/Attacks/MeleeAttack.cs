using System.Collections;
using UnityEngine;

public class MeleeAttack : AttackBehavior
{
    public override void Attack()
    {
        Debug.Log("������� �����");
    }

    public override void StopAttack()
    {
        Debug.Log("������� ����� �����������");
    }

    //private IEnumerator AttackDelay()
    //{
        
    //}
}
