using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public GameObject loadingScene;
    public Slider loadingBar;

    public void LoadScene(int index)
    {
        StartCoroutine(LoadSceneAsynchronously(index));
    }

    IEnumerator LoadSceneAsynchronously(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        loadingScene.SetActive(true);
        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;
            yield return null;
        }
    }
}
