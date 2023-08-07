using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderImage : MonoBehaviour
{
    public Sprite[] satisfactionImages;
    private Image satisfactionImage;
    private float maxScore;

    private void Awake()
    {
        satisfactionImage = GetComponent<Image>();
    }
    private void Start()
    {
        maxScore = ScoreManager.instance.Score;
    }

    private void Update()
    {
        int currentScore = (int)(ScoreManager.instance.Score / maxScore * 10);
        satisfactionImage.sprite = satisfactionImages[currentScore];
    }
}
