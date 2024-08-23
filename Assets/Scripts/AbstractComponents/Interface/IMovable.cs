using UnityEngine;

public interface IMovable 
{
    public void Move(Vector3 target);
    public void MoveToEnemy(Health target);
    public void StopMoveDistanceCharacter();
}
