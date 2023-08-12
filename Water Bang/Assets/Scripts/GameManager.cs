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
    gameOver,
    gameClear
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
    [Header ("Main Screen")]
    public GameObject StartScreen;
    public GameObject SettingScreen;
    public GameObject SelectScreen;

    [Header ("InGameObject")]
    // 인게임 화면에 필요한 요소들
    public GameObject playerObject;
    public GameObject inGameUI;
    public GameObject pauseUI;
    public GameObject gameOverUI;
    public GameObject gameClearUI;
    public Text scoreText;
    public GameObject perk;

    public int npcCount = 0;
    public int enemyCount = 0;
    public int specialEnemy1Count = 0;
    public int specialEnemy2Count = 0;
    public int specialEnemy3Count = 0;
    public int specialEnemy4Count = 0;
    private int allCount = 0;

    public int AllCount
    {
        get { return allCount; }
        set
        {
            if (allCount < 0) allCount = 0;
            else allCount = value;
        }
    }

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
        gameClearUI.SetActive(false);
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
        npcCount = 0;
        enemyCount = 2;
        specialEnemy1Count = 0;
        specialEnemy2Count = 0;
        specialEnemy3Count = 0;
        specialEnemy4Count = 00;
        allCount = enemyCount + specialEnemy1Count + specialEnemy2Count + specialEnemy3Count + specialEnemy4Count;

        SceneControl();
    }
    public void ButtonStage2()
    {
        currentStage = 1;
        currentState = GameStates.inGame;
        npcCount = 0;
        enemyCount = 2;
        specialEnemy1Count = 0;
        specialEnemy2Count = 0;
        specialEnemy3Count = 0;
        specialEnemy4Count = 0;
        allCount = enemyCount + specialEnemy1Count + specialEnemy2Count + specialEnemy3Count + specialEnemy4Count;

        SceneControl();
    }
    public void ButtonStage3()
    {
        currentStage = 2;
        currentState = GameStates.inGame;
        npcCount = 25;
        enemyCount = 15;
        specialEnemy1Count = 0;
        specialEnemy2Count = 15;
        specialEnemy3Count = 0;
        specialEnemy4Count = 15;
        allCount = enemyCount + specialEnemy1Count + specialEnemy2Count + specialEnemy3Count + specialEnemy4Count;

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
    public void GameOver()
    {
        currentState = GameStates.gameOver;
        SoundManager.instance.audioBgm.Stop();
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
    public void GameClear()
    {
        currentState = GameStates.gameClear;
        SoundManager.instance.audioBgm.Stop();
        scoreText.text = "점수:       " + ScoreManager.instance.Score.ToString();
        if(ScoreManager.instance.Score == 100)
            perk.SetActive(true);
        else
            perk.SetActive(false);
        SceneControl();
    }

    void Update()
    {
        if(currentState == GameStates.inGame)
        {
            // 게임 오버
            if (ScoreManager.instance.Score <= 0 || !SoundManager.instance.audioBgm.isPlaying)
                GameOver();
            // 게임 클리어
            else if (AllCount == 0)
                GameClear();
        }

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
                SoundManager.instance.PlayMainBgm();
                playerObject.SetActive(false);
                inGameUI.SetActive(false);
                pauseUI.SetActive(false);
                gameOverUI.SetActive(false);
                if (SceneManager.loadedSceneCount >= 2 && SceneManager.GetSceneAt(1).buildIndex == currentStage)
                    SceneManager.UnloadSceneAsync(currentStage);
                break;
            case GameStates.gameOver:
                Time.timeScale = 0f;
                inGameUI.SetActive(false);
                gameOverUI.SetActive(true);
                SoundManager.instance.PlayGameOverSfx();
                if (SceneManager.loadedSceneCount >= 2 && SceneManager.GetSceneAt(1).buildIndex == currentStage)
                    SceneManager.UnloadSceneAsync(currentStage);
                break;
            case GameStates.gameClear:
                Time.timeScale = 0f;
                inGameUI.SetActive(false);
                gameClearUI.SetActive(true);
                SoundManager.instance.PlayGameClearSfx();
                //게임 클리어 효과음
                if (SceneManager.loadedSceneCount >= 2 && SceneManager.GetSceneAt(1).buildIndex == currentStage)
                    SceneManager.UnloadSceneAsync(currentStage);
                break;
            default:
                break;
        }
    }

    private void Reset()
    {
        ScoreManager.instance.Score = ScoreManager.instance.maxScore;
        waterGun.waterQuantity = waterGun.waterTank;
        player.Reset();
    }
}