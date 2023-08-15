using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTimer : MonoBehaviour
{
    private Animator timer;
    private float baseSpeed;

    private void Awake()
    {
        timer = GetComponent<Animator>();
        baseSpeed = 221.0f;
    }

    private void Update()
    {
        if (this.gameObject.activeSelf)
            timer.Play("Timer");
        if (GameManager.instance.currentStage == 0)
            timer.speed = 124.0f / baseSpeed;
        else if (GameManager.instance.currentStage == 1)
            timer.speed = 149.0f / baseSpeed;
        else if (GameManager.instance.currentStage == 2)
            timer.speed = 132.0f / baseSpeed;

        if (GameManager.instance.currentState == GameStates.pause)
            timer.speed = 0f;
    }
}
