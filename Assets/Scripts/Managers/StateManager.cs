using UnityEngine;

public class StateManager : Singleton<StateManager>
{
    private static IGameState currentState;

    public static IEnemySpawn enemySpawn;
    public static Health health;

    private TouchManagers touchManagers;

    private void Awake()
    {
        touchManagers = TouchManagers.Instance;
    }

    private void Start()
    {
        health = GameObject.FindObjectOfType<CharactersSpawner>().GetComponent<Health>();
        enemySpawn = GameObject.FindObjectOfType<EnemySpawner>().GetComponent<IEnemySpawn>();
        
        health.GetComponent<ICharactersSpawn>().CharactersSpawn();

        SetState(new StartGameState());
    }

    public static void SetState(IGameState newState)
    {
        if(currentState != null)
        {
            currentState.ExitState(Instance);
        }

        currentState = newState;
        currentState.EnterState(Instance);
    }
}
