using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Whistle whistle;
    private WaterBomb bomb;

    private void Awake()
    {
        whistle = GetComponent<Whistle>();
        bomb = GetComponent<WaterBomb>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            whistle.UseItem();
        else if (Input.GetKey(KeyCode.Alpha2))
            bomb.UseItem();
        else
            bomb.range.SetActive(false);
    }
}
