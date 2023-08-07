using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;

    void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }

    [SerializeField]
    GameObject scoreManager;
    public GameObject StartScreen;
    public GameObject SelectScreen;

    public void OnClickStartButton()
    {
        StartScreen.SetActive(false);
        SelectScreen.SetActive(true);
    }

    public void OnClickRestartButton() { SceneManager.LoadScene(1); }
    public void GoToOverScene() { SceneManager.LoadScene(2); }
    public void ButtonStage1() {
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
        SelectScreen.SetActive(false);
    }
    public void ButtonStage2() { SceneManager.LoadScene(4, LoadSceneMode.Additive); }
    public void ButtonStage3() { SceneManager.LoadScene(5, LoadSceneMode.Additive); }

    void Update()
    {
        if (scoreManager.GetComponent<ScoreManager>().Score <= 0) GoToOverScene();
    }
}