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
        yield return new WaitForSeconds(reloadDelay);
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

    void Start()
    {
        waterQuantity = waterTank;
    }

    void Update()
    {
        if (GameManager.instance.currentState == GameStates.inGame && !isInfinite)
        {
            if (waterQuantity <= 0 && !isReloading) { StartReload(); }
            else ShootWater();

            if (Input.GetKeyDown(KeyCode.R) && !isReloading) { StartReload(); }
        }
    }
}