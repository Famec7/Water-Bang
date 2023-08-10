using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterUI : MonoBehaviour
{
    public WaterGun waterGun;
    private Slider waterSlider;

    private void Awake()
    {
        waterSlider = GetComponent<Slider>();
    }
    private void Update()
    {
        waterSlider.value = (float)GameManager.instance.waterGun.waterQuantity / GameManager.instance.waterGun.waterTank;
    }
}
