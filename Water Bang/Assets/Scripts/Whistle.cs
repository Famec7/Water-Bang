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
        ObjectPool.instance.Reset();
    }
}