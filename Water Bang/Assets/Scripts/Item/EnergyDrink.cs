using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink : Item
{
    private AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private IEnumerator InfinityMode()
    {
        inUse = true;
        yield return new WaitForSeconds(5f);
        GameManager.instance.waterGun.isInfinite = false;
        inUse = false;
    }

    public override void UseItem()
    {
        audioSource.PlayOneShot(clip);
        GameManager.instance.waterGun.FillWater();
        GameManager.instance.waterGun.isInfinite = true;
        StartCoroutine(InfinityMode());
    }
}