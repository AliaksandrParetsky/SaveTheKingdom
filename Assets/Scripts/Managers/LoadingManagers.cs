using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManagers : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] TMP_Text precentageText;

    [SerializeField] string enterSceneName;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync("GameScene"));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;

            precentageText.text = (progress * 100.0f).ToString("F0") + "%";

            yield return null;
        }
    }
}
