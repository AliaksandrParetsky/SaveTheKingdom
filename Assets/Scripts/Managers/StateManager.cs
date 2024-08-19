
public enum GameState
{
    StartGame,
    EndGame
}

public class StateManager : Singleton<StateManager>
{
    public GameState currentState;

    private TouchManagers touchManagers;

    private void Awake()
    {
        touchManagers = TouchManagers.Instance;
    }

    private void OnEnable()
    {
        StartGame();
    }

    private void StartGame()
    {
        currentState = GameState.StartGame;
    }

    private void Update()
    {
        if(currentState == GameState.StartGame)
        {

        }
        else if(currentState == GameState.EndGame)
        {

        }
    }

    private void EndGame()
    {
        currentState = GameState.EndGame;
    }
}
