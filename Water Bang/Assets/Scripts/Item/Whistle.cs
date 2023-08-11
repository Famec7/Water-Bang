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
        audioSource.PlayOneShot(clip);
    }

    private IEnumerator ExitAll()
    {
        ObjectPool.instance.Reset();
        yield return new WaitForSeconds(5f);
    }
}