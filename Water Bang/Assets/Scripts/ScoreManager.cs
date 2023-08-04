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

    private float score = 50;
    public float staticDecay = 1;

    public float Score
    {
        get { return score; }
        set {
            if (value > 100) score = 100;
            else score = value;
        }
    }

    public int combo = 0;
    private int deltaCombo;
    private int resetCombo;

    private IEnumerator StaticDecrease()
    {
        yield return new WaitForSecondsRealtime(1f);
        score -= staticDecay;
        Debug.Log(score);
        StartCoroutine(StaticDecrease());
    }

    void Start()
    {
        StartCoroutine(StaticDecrease());
    }

    void Update()
    {

    }
}