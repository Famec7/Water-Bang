using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPause;
    public GameObject pauseUI;

    void Start()
    {
        isPause = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause == false)
            {
                Time.timeScale = 0;
                isPause = true;
                pauseUI.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                isPause = false;
                pauseUI.SetActive(false);
            }
        }
    }
}