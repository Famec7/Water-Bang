using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public static int nextScene;
    private float loadTime = 4.0f;

    private void Start()
    {
        StartCoroutine("LoadingScene");
    }
    public static void LoadScene(int index)
    {
        nextScene = index;
        SceneManager.LoadScene("LoadingScene", LoadSceneMode.Additive);
    }

    private IEnumerator LoadingScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
        op.allowSceneActivation = false;
        float time = 0.0f;

        while (!op.isDone)
        {
            yield return null;
            if (op.progress >= 0.9f)
            {
                time += Time.unscaledDeltaTime;
                if (time >= loadTime)
                {
                    op.allowSceneActivation = true;
                    SceneManager.UnloadSceneAsync("LoadingScene");
                    GameManager.instance.playerObject.SetActive(true);
                    GameManager.instance.inGameUI.SetActive(true);
                    SoundManager.instance.PlayBgm();
                    Time.timeScale = 1f;
                    yield break;
                }
            }
        }
    }
}
