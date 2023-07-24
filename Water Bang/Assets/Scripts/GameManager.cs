using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject StartScreen;
    public GameObject SelectScreen;

    void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }

    public void OnClickStartButton()
    {
        StartScreen.SetActive(false);
        SelectScreen.SetActive(true);
    }
    public void OnClickRestartButton() { SceneManager.LoadScene(1);}
    public void GoToOverScene() { SceneManager.LoadScene(2); }
    public void ButtonStage1() { SceneManager.LoadScene(3); }
    public void ButtonStage2() { SceneManager.LoadScene(4); }
    public void ButtonStage3() { SceneManager.LoadScene(5); }
}