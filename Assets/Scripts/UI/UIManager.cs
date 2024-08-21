using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject uiPanelGameOver;

    private void OnEnable()
    {
        EndGameState.onUIGameOver += EndGameState_onUIGameOver;
    }

    private void EndGameState_onUIGameOver()
    {
        uiPanelGameOver.SetActive(true);
    }

    private void OnDisable()
    {
        EndGameState.onUIGameOver -= EndGameState_onUIGameOver;
    }
}
