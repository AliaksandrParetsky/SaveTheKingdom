using System;
using UnityEngine;

public class StartGameState :MonoBehaviour, IGameState
{
    private TouchManagers touchManagers;
    private IEnemySpawn enemySpawn;
    private Health health;

    private bool isDestroy;

    private void Awake()
    {
        touchManagers = TouchManagers.Instance;
    }

    private void MinionesSpawner_OnDestroyEvent()
    {
        isDestroy = true;
    }

    public void EnterState(StateManager stateManager)
    {
        health = FindObjectOfType<CharactersSpawner>().GetComponent<Health>();
        health.diedEvent += MinionesSpawner_OnDestroyEvent;
        health.GetComponent<ICharactersSpawn>().CharactersSpawn();

        enemySpawn = FindObjectOfType<EnemySpawner>().GetComponent<IEnemySpawn>();
        enemySpawn.StartSpawn();
    }

    public void UpdateState(StateManager stateManager)
    {
        if (isDestroy)
        {
            stateManager.SetState(stateManager.gameObject.AddComponent<EndGameState>());
        }
    }

    public void ExitState(StateManager stateManager)
    {
        Destroy(this);
    }

    private void OnDisable()
    {
        health.diedEvent -= MinionesSpawner_OnDestroyEvent;
    }
}
