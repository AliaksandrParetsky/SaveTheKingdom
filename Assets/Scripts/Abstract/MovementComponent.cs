using UnityEngine;

public class MovementComponent : MonoBehaviour, IMovable
{
    public void Move(Vector3 target)
    {
        if(TryGetComponent<Character>(out var character))
        {
            character.Agent.SetDestination(target);
        }
    }
}
