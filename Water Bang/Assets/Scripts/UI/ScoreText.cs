using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text text;
    private Color color;

    private void Awake()
    {
        text = GetComponent<Text>();
        color = text.color;
    }

    private void Update()
    {
        if (GameManager.instance.currentState == GameStates.inGame)
        {
            if (color.a > 0)
            {
                color.a -= Time.unscaledDeltaTime * 0.7f;
                text.color = color;
            }
            else
                Destroy(this.gameObject);
        }

        else if(GameManager.instance.currentState == GameStates.gameClear || GameManager.instance.currentState == GameStates.gameOver)
            Destroy(this.gameObject);
    }

    public void SetText(int score)
    {
        if (score > 0)
            text.text = "+" + score.ToString();
        else
            text.text = score.ToString();
    }
}
