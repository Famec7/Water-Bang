using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float score = 50;

    public float Score
    {
        get { return score; }
        set { score = value; }
    }

    private IEnumerator StaticDecrease()
    {
        yield return new WaitForSeconds(1f);
        score -= 1f;
        //Debug.Log(score);
        StartCoroutine(StaticDecrease());
    }

    void Start()
    {
        StartCoroutine(StaticDecrease());
    }

    void Update()
    {
        if (score <= 0)
        {
            GameManager.instance.GoToOverScene();
        }
    }
}
