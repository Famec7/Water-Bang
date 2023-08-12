using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whistle : Item
{
    private AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public override void UseItem()
    {
        StartCoroutine("ExitAll");
    }

    private IEnumerator ExitAll()
    {
        inUse = true;
        audioSource.PlayOneShot(clip);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(2f);
        Debug.Log("fin");
        Time.timeScale = 1f;
        inUse = false;
    }
}