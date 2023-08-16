using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour
{
    private int reloadDelay = 3;
    public int waterTank = 100;
    public int waterQuantity;
    public bool isReloading = false;
    public bool isInfinite = false;

    public AudioClip reloadSound;
    private AudioSource sfx;

    public void ShootWater()
    {
        if (!isReloading && Input.GetMouseButton(0))
        {
            waterQuantity -= 1;
            //Debug.Log(waterQuantity);
        }
    }

    public void FillWater() { waterQuantity = waterTank; }

    private IEnumerator Reload()
    {
        yield return new WaitForSecondsRealtime(reloadDelay);
        Debug.Log("Reload Complete");
        FillWater();
        isReloading = false;
    }

    private void StartReload()
    {
        Debug.Log("Reload Start");
        StartCoroutine(Reload());
        isReloading = true;
    }

    private void Awake()
    {
        sfx = GetComponent<AudioSource>();
    }
    private void Start()
    {
        waterQuantity = waterTank;
    }

    private void Update()
    {
        if (GameManager.instance.currentState == GameStates.inGame && !isInfinite)
        {
            if (waterQuantity <= 0) {
                if (Input.GetMouseButton(0))
                {
                    if (!sfx.isPlaying)
                        sfx.PlayOneShot(reloadSound);
                }
                if(!isReloading)
                    StartReload(); 
            }
            else ShootWater();
        }
    }
}