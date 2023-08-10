using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum GameStates
{
    inGame,
    inMain,
    inSelect,
    pause,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public WaterGun waterGun;

    public GameStates currentState;

    public int currentStage = 0;

    void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
        Time.timeScale = 0f;
        currentState = GameStates.inMain;
    }

    // 메인화면에 필요한 요소들
    public GameObject StartScreen;
    public GameObject SettingScreen;
    public GameObject SelectScreen;

    // 인게임 화면에 필요한 요소들
    public GameObject playerObject;
    public GameObject inGameUI;
    public GameObject pauseUI;
    public GameObject gameOverUI;

    // 시작화면
    public void MainScreen()
    {
        currentState = GameStates.inMain;
        StartScreen.SetActive(true);
        SelectScreen.SetActive(false);
        SettingScreen.SetActive(false);
    }
    public void OnClickStartButton()
    {
        currentState = GameStates.inSelect;
        StartScreen.SetActive(false);
        SelectScreen.SetActive(true);
        gameOverUI.SetActive(false);
        SceneControl();
    }

    public void OnClickSettingButton()
    {
        StartScreen.SetActive(false);
        SettingScreen.SetActive(true);
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }

    // 스테이지 선택화면
    public void ButtonStage1() {
        currentStage = 0;
        currentState = GameStates.inGame;

        SceneControl();
    }
    public void ButtonStage2()
    {
        currentStage = 1;
        currentState = GameStates.inGame;

        SceneControl();
    }
    public void ButtonStage3()
    {
        currentStage = 2;
        currentState = GameStates.inGame;

        SceneControl();
    }

    // 인게임
    public void OnClickRestartButton()
    {
        if (currentStage == 0)
            ButtonStage1();
        else if (currentStage == 1)
            ButtonStage2();
        else if (currentStage == 2)
            ButtonStage3();
    }
    public void GoToOverScene()
    {
        currentState = GameStates.gameOver;
        SceneControl();
    }

    public void Pause()
    {
        currentState = GameStates.pause;
        pauseUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Continue()
    {
        currentState = GameStates.inGame;
        pauseUI.SetActive(false);
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (currentState == GameStates.gameOver) GoToOverScene();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState != GameStates.pause)
                Pause();
            else
                Continue();
        }
    }

    private void SceneControl()
    {
        switch(currentState)
        {
            case GameStates.inGame:
                Reset();
                Time.timeScale = 1f;
                SoundManager.instance.PlayBgm();
                SelectScreen.SetActive(false);
                playerObject.SetActive(true);
                inGameUI.SetActive(true);
                gameOverUI.SetActive(false);
                SceneManager.LoadScene(currentStage, LoadSceneMode.Additive);
                break;
            case GameStates.inSelect:
                Time.timeScale = 0f;
                SoundManager.instance.StopBgm();
                playerObject.SetActive(false);
                inGameUI.SetActive(false);
                pauseUI.SetActive(false);
                gameOverUI.SetActive(false);
                if (SceneManager.loadedSceneCount >= 2 && SceneManager.GetSceneAt(1).buildIndex == currentStage)
                    SceneManager.UnloadSceneAsync(currentStage);
                break;
            case GameStates.gameOver:
                Time.timeScale = 0f;
                gameOverUI.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void Reset()
    {
        ScoreManager.instance.Score = 50f;
        waterGun.waterQuantity = waterGun.waterTank;
        player.bombCount = 0;
        player.whistleCount = 0;
        player.energyDrinkCount = 0;
    }
}