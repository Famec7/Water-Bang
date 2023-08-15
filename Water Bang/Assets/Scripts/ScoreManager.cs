using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public GameObject canvas;
    public GameObject scoreText;
    void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }

    public float maxScore = 100;
    private float score;
    public float staticDecay = 1;

    public float Score
    {
        get { return score; }
        set
        {
            if (value > maxScore) score = maxScore;
            else if (value <= 0)
                score = 0;
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

    public GameObject CreateScoreText(Vector3 pos, int score)
    {
        GameObject obj = Instantiate(scoreText);
        obj.transform.position = Camera.main.WorldToScreenPoint(pos);
        obj.transform.SetParent(canvas.transform);
        obj.GetComponent<ScoreText>().SetText(score);

        return obj;
    }

    void Start()
    {
        StartCoroutine(StaticDecrease());
        StartCoroutine(Timer(comboTime));
    }
}