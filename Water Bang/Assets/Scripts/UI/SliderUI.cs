using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{
    private Slider slider;
    private float maxScore;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        maxScore = ScoreManager.instance.Score;
    }

    private void Update()
    {
        slider.value = ScoreManager.instance.Score / maxScore;
    }
}
