using System;

public class EndGameState : IGameState
{
    public static event Action onUIGameOver;

    public void EnterState(StateManager stateManager)
    {
        StateManager.enemySpawn.StopSpawn();

        if (EnemyList.enemies.Count > 0)
        {
            for (int i = EnemyList.enemies.Count - 1; i >= 0; i--)
            {
                EnemyList.enemies[i].gameObject.SetActive(false);
            }
        }

        if (Squad.characters.Count > 0)
        {
            for (int i = Squad.characters.Count - 1; i >= 0; i--)
            {
                Squad.characters[i].gameObject.SetActive(false);
            }
        }

        onUIGameOver?.Invoke();
    }

    public void ExitState(StateManager stateManager)
    {

    }
}
