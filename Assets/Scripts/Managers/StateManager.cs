
public class StateManager : Singleton<StateManager>
{
    private IGameState currentState;

    private void Start()
    {
        SetState(gameObject.AddComponent<StartGameState>());
    }

    public void SetState(IGameState newState)
    {
        if(currentState != null)
        {
            currentState.ExitState(this);
        }

        currentState = newState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
        }
    }

}
