using System.Collections;
using UnityEngine;

public class MeleeAttack : AttackBehavior
{
    public override void Attack()
    {
        Debug.Log("Ѕлижн€€ атака");
    }

    public override void StopAttack()
    {
        Debug.Log("Ѕлижн€€ атака остановлена");
    }

    //private IEnumerator AttackDelay()
    //{
        
    //}
}
