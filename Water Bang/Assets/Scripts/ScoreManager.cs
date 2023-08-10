using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }

    private float score = 10;
    public float staticDecay = 1;

    public float Score
    {
        get { return score; }
        set
        {
            if (value > 100) score = 100;
            else if (value <= 0) GameManager.instance.currentState = GameStates.gameOver;
            else score = value;
        }
    }

    private int combo = 0;
    public int Combo
    {
        get { return combo; }
        set
        {
            if (value > 10) combo = 10;
            else combo = value;
        }
    }

    float comboTime = 0f;
    float breakTime = 5f;
    public bool isComboUp = false;

    private IEnumerator Timer(float currentTime)
    {
        yield return null;
        if (isComboUp) { currentTime = 0f; isComboUp = false; }
        else currentTime += Time.deltaTime;

        if (currentTime >= breakTime)
        {
            currentTime = 0f;
            Combo = 0;
        }

        //Debug.Log(currentTime);
        StartCoroutine(Timer(currentTime));
    }

    private IEnumerator StaticDecrease()
    {
        yield return new WaitForSeconds(1f);
        Score -= staticDecay;
        Debug.Log(score);
        StartCoroutine(StaticDecrease());
    }

    void Start()
    {
        StartCoroutine(StaticDecrease());
        StartCoroutine(Timer(comboTime));
    }
}