using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Whistle w;
    public WaterBomb bomb;

    private void Awake()
    {
        bomb.range = transform.GetChild(0).gameObject;
        bomb.range.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            w.UseItem();
        else if (Input.GetKey(KeyCode.Alpha2))
            bomb.UseItem();
        else
            bomb.range.SetActive(false);
    }
}
