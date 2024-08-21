using System;
using UnityEngine;

public class EndGameState : MonoBehaviour, IGameState
{
    public static event Action onUIGameOver;

    private IEnemySpawn enemySpawn;

    private bool isGameOver;

    public void EnterState(StateManager stateManager)
    {
        enemySpawn = FindObjectOfType<EnemySpawner>().GetComponent<IEnemySpawn>();
        enemySpawn.StopSpawn();

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

        isGameOver = true;
    }

    public void UpdateState(StateManager stateManager)
    {
        if (isGameOver)
        {
            onUIGameOver?.Invoke();
        }
    }

    public void ExitState(StateManager stateManager)
    {

    }
}
