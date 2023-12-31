using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ASyncLoader : MonoBehaviour
{
    [Header("MenuScreens")]
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private GameObject MainMenuPanel;

    [Header("Slider")]
    [SerializeField] private Slider LoadingSlider;

    public void LoadLevelBtn(string levelToLoad)
    {
        MainMenuPanel.SetActive(false);
        LoadingScreen.SetActive(true);

        StartCoroutine(LoadLevelASync(levelToLoad));
    }

    IEnumerator LoadLevelASync(string levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            LoadingSlider.value = progressValue;
            yield return null;
        }
    }
}
