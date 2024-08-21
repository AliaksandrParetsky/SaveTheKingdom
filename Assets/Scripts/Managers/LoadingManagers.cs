using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManagers : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] TMP_Text precentageText;
    [SerializeField] TMP_Text message;

    [SerializeField] string enterSceneName;

    private bool isTouch;

    private InputManager inputManager;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        inputManager.OnUITouch += InputManager_OnUITouch;
    }

    private void InputManager_OnUITouch()
    {
        isTouch = true;
    }

    private void Start()
    {
        StartCoroutine(LoadSceneAsync(enterSceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;

            precentageText.text = (progress * 100.0f).ToString("F0") + "%";

            if(operation.progress >= 0.9f)
            {
                message.gameObject.SetActive(true);

                operation.allowSceneActivation = GetTouch();
            }

            yield return null;
        }
    }

    private bool GetTouch()
    {
        if (isTouch)
        {
            return true;
        }

        return false;
    }

    private void OnDisable()
    {
        inputManager.OnUITouch -= InputManager_OnUITouch;
    }
}
