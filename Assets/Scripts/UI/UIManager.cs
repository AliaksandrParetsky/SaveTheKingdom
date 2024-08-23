using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform uiPanelGameOver;
    [SerializeField] private Image gameOverImage;
    [SerializeField] private Image victoryImage;
    [SerializeField] private TMP_Text counterEnemeis;

    private void OnEnable()
    {
        EndGameState.onUIGameOver += EndGameState_onUIGameOver;

        StartGameState.onUIChangeCountEnemy += StartGameState_onUIChangeCountEnemy;
    }

    private void StartGameState_onUIChangeCountEnemy()
    {
        counterEnemeis.text = EnemyList.totalValueEnemies.ToString();
    }

    private void Start()
    {
        counterEnemeis.text = EnemyList.totalValueEnemies.ToString();
    }

    private void EndGameState_onUIGameOver()
    {
        if(EnemyList.totalValueEnemies == 0)
        {
            uiPanelGameOver.gameObject.SetActive(true);
            victoryImage.gameObject.SetActive(true);

            return;
        }

        uiPanelGameOver.gameObject.SetActive(true);
        gameOverImage.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void CancelGame()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void OnDisable()
    {
        EndGameState.onUIGameOver -= EndGameState_onUIGameOver;

        StartGameState.onUIChangeCountEnemy -= StartGameState_onUIChangeCountEnemy;
    }
}
