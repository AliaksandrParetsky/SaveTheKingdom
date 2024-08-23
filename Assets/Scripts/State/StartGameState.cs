using System;

public class StartGameState : IGameState
{
    public static event Action onUIChangeCountEnemy;

    private void MinionesSpawner_OnDestroyEvent()
    {
        StateManager.SetState(new EndGameState());
    }

    public void EnterState(StateManager stateManager)
    {
        StateManager.health.diedEvent += MinionesSpawner_OnDestroyEvent;
        StateManager.enemySpawn.StartSpawn();

        Enemy.onChangeCountEnemy += Enemy_onChangeCountEnemy;
    }

    private void Enemy_onChangeCountEnemy()
    {
        EnemyList.totalValueEnemies -= 1;

        onUIChangeCountEnemy?.Invoke();

        if (EnemyList.totalValueEnemies == 0)
        {
            StateManager.SetState(new EndGameState());
        }
    }

    public void ExitState(StateManager stateManager)
    {
        StateManager.health.diedEvent -= MinionesSpawner_OnDestroyEvent;

        Enemy.onChangeCountEnemy -= Enemy_onChangeCountEnemy;
    }
}
