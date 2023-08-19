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
        satisfactionImage.sprite = satisfactionImages[9];
    }
    private void Start()
    {
        maxScore = ScoreManager.instance.Score;
    }

    private void Update()
    {
        int currentScore = (int)(ScoreManager.instance.Score / maxScore * 10);
        if (currentScore >= 0 && currentScore < 10)
            satisfactionImage.sprite = satisfactionImages[currentScore];
    }

    private void OnDisable()
    {
        satisfactionImage.sprite = satisfactionImages[9];
    }
}
