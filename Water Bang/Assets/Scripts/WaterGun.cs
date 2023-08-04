using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour
{
    private int reloadDelay = 3;
    public int waterTank = 100;
    private int waterQuantity;
    public bool isReloading = false;
    [SerializeField]
    GameObject pause;

    public void ShootWater()
    {
        if (!isReloading && Input.GetMouseButton(0))
        {
            waterQuantity -= 1;
            //Debug.Log(waterQuantity);
        }
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadDelay);
        Debug.Log("Reload Complete");
        waterQuantity = waterTank;
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
        if (!pause.GetComponent<Pause>().isPause)
        {
            if (waterQuantity <= 0 && !isReloading) { StartReload(); }
            else ShootWater();

            if (Input.GetKeyDown(KeyCode.R) && !isReloading) { StartReload(); }
        }
    }
}