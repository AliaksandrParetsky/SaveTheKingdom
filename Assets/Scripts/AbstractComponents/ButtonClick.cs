using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] string nameScene;

    private Button button;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Load);
    }

    private void Load()
    {
        SceneManager.LoadScene(nameScene);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(Load);
    }
}
