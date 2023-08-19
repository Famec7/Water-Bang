using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDrink : Item
{
    private AudioSource audioSource;
    public AudioClip clip;

    private float time = 5.0f;
    public Text timeText;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        timeText.gameObject.SetActive(false);
    }
    private IEnumerator InfinityMode()
    {
        inUse = true;
        time = 5.0f;
        timeText.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        GameManager.instance.waterGun.isInfinite = false;
        inUse = false;
        timeText.gameObject.SetActive(false);
    }

    public override void UseItem()
    {
        audioSource.PlayOneShot(clip);
        GameManager.instance.waterGun.FillWater();
        GameManager.instance.waterGun.isInfinite = true;
        StartCoroutine(InfinityMode());
    }

    private void Update()
    {
        if (inUse && GameManager.instance.currentState == GameStates.inGame)
        {
            timeText.text = time.ToString("F1");
            time -= Time.unscaledDeltaTime;
        }

        else if (!inUse)
            timeText.gameObject.SetActive(false);
    }
}